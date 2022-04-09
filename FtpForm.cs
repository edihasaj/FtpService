using System.Globalization;
using System.Text.Json;
using FluentFTP;
using Serilog;

namespace FtpService
{
    public partial class FtpForm : Form
    {
        private Configuration _configuration;
        private FtpClient _ftpClient;
        
        public FtpForm()
        {
            _configuration = new Configuration();
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            Backup();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            if (_ftpClient.IsConnected)
                _ftpClient.Disconnect();
        }

        private void FtpForm_Load(object sender, EventArgs e)
        {
            PasswordTxt.PasswordChar = '*';
            GetConfig();
            GetLastBackup();
        }

        private void HostnameTxt_TextChanged(object sender, EventArgs e)
        {
        }

        private void AddConfig()
        {
            using var db = new ApplicationDbContext();
            Log.Information("Database path: {db.DbPath}", db.DbPath);

            var config = db.Configurations.FirstOrDefault();
            if (config != null)
            {
                config.HostName = HostnameTxt.Text;
                config.UserName = UsernameTxt.Text;
                config.Password = PasswordTxt.Text;
                config.Port = string.IsNullOrEmpty(config.Port.ToString()) ? config.Port : 21;
                config.PathList = PathListTxt.Text;
            }
            else
            {
                var data = new Configuration
                {
                    HostName = HostnameTxt.Text,
                    UserName = string.Empty,
                    Password = string.Empty,
                    Port = 21,
                    PathList = string.Empty,
                };
                db.Add(data);
                config = data;

                Log.Information("Inserting a new config: {Json}", JsonSerializer.Serialize(data));
            }

            db.SaveChanges();
            _configuration = config;

            SetupClientFtp();
        }

        private void SetupClientFtp()
        {
            _ftpClient = new FtpClient(_configuration.HostName, _configuration.Port, 
                _configuration.UserName, _configuration.Password);
            _ftpClient.EncryptionMode = FtpEncryptionMode.Auto;
            _ftpClient.ValidateAnyCertificate = true;
            _ftpClient.DataConnectionType = FtpDataConnectionType.PASV;
        }

        private void GetConfig()
        {
            using var db = new ApplicationDbContext();
            Log.Information("Database path: {db.DbPath}", db.DbPath);

            var config = db.Configurations.FirstOrDefault();
            if (config == null) return;

            HostnameTxt.Text = config.HostName;
            UsernameTxt.Text = config.UserName;
            PasswordTxt.Text = config.Password;
            PortTxt.Text = string.IsNullOrEmpty(config.Port.ToString()) ? config.Port.ToString() : "21";
            PathListTxt.Text = config.PathList;
            _configuration = config;
            
            if (string.IsNullOrEmpty(_configuration.HostName) || string.IsNullOrEmpty(_configuration.UserName) ||
                string.IsNullOrEmpty(_configuration.Password)) return;

            SetupClientFtp();
        }

        private void GetLastBackup()
        {
            using var db = new ApplicationDbContext();
            Log.Information("Database path: {db.DbPath}", db.DbPath);

            var backup = db.Backups.OrderByDescending(c => c.CreatedAt).FirstOrDefault();
            if (backup == null) return;

            ResponseTxt.Text = backup.Response;
            LastBackupLbl.Text = backup.CreatedAt.ToString(CultureInfo.InvariantCulture);
            StatusLbl.Text = backup.Status;
        }

        private void UsernameTxt_TextChanged(object sender, EventArgs e)
        {
        }

        private void PasswordTxt_TextChanged(object sender, EventArgs e)
        {
        }

        private void PortTxt_TextChanged(object sender, EventArgs e)
        {
        }

        private void PathListTxt_TextChanged(object sender, EventArgs e)
        {
        }

        private void ResponseTxt_TextChanged(object sender, EventArgs e)
        {
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            AddConfig();
        }

        private void Backup()
        {
            if (string.IsNullOrEmpty(_configuration.HostName) || string.IsNullOrEmpty(_configuration.UserName) ||
                string.IsNullOrEmpty(_configuration.Password))
            {
                MessageBox.Show("Please provide FTP configuration");
                Log.Warning("Please provide FTP configuration");
                return;
            }
            
            if (string.IsNullOrEmpty(_configuration.PathList) || _configuration.PathList.Length <= 0)
            {
                MessageBox.Show("Please provide valid path");
                Log.Warning("Please provide valid path");
                return;
            }

            var pathList = _configuration.PathList.Split(";").ToList();
            if (0 >= pathList.Count)
            {
                MessageBox.Show("Please provide valid path");
                Log.Warning("Please provide valid path");
                return;
            }
            
            try
            {
                Log.Information("Connecting ftp");
                
                if (!_ftpClient.IsConnected)
                    _ftpClient.Connect();
                if (!_ftpClient.IsConnected)
                {
                    Log.Warning("Ftp not connected, try again. Config: {Config}", 
                        JsonSerializer.Serialize(_configuration));
                    ResponseTxt.Text = "Ftp could not be connected. Try again";
                    return;
                }

                ResponseTxt.Text = "Ftp is connected. Starting the backup";
                ResponseTxt.Refresh();
                var results = new List<FtpResult>();

                foreach (var path in pathList)
                {
                    var pathFolder = path.Split("/");
                    if (pathFolder.Length <= 1)
                        pathFolder = path.Split("\\");
                    if (pathFolder.Length <= 0)
                    {
                        Log.Information("Path: {Path} is not valid. continuing further", path);
                        continue;
                    }
                    
                    Log.Information("Uploading path: {Path}", path);
                    ResponseTxt.Text = $"Uploading path: {path}";

                    var directory = $"files/{pathFolder[^1]}";
                    if (!_ftpClient.DirectoryExists(directory))
                    {
                        var createResponse = _ftpClient.CreateDirectory(directory);
                        if (!createResponse)
                        {
                            Log.Warning("Could not create folder in FTP");
                            MessageBox.Show("Could not create folder in FTP");
                            return;
                        }
                    }

                    var count = 10;
                    ResponseTxt.Text = $@"Backing up: {directory}";
                    ResponseTxt.Refresh();
                    
                    results = _ftpClient.UploadDirectory(path,
                        directory, progress: progress =>
                    {
                        if (count == 0)
                        {
                            StatusLbl.Text = progress.Progress.ToString(CultureInfo.InvariantCulture);
                            StatusLbl.Refresh();
                            count = 2;
                        }

                        count--;
                    });

                    if (results.Any(r => r.IsFailed))
                    {
                        ResponseTxt.Text = string.Join(";   ", results.Where(r => r.IsFailed)
                            .Select(r => r.Exception.Message));
                        Log.Error(ResponseTxt.Text, results);
                    }

                    ResponseTxt.Text = "Successfully uploaded folder";
                    ResponseTxt.Refresh();
                    
                    Log.Information("Uploading path: {Path} successful", path);
                    Thread.Sleep(1000);
                }
                
                ResponseTxt.Text = "Backup done 👌😁";
                ResponseTxt.Refresh();
                InsertBackup(string.Join(";  ", JsonSerializer.Serialize(
                        results.Select(r => r.ToListItem(true)))),
                    StatusLbl.Text);
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                MessageBox.Show(e.Message);
            }
            finally
            {
                Log.Information("Disconnecting ftp");
                if (_ftpClient.IsConnected)
                    _ftpClient.Disconnect();
            }
        }

        private void InsertBackup(string response, string status)
        {
            using var db = new ApplicationDbContext();
            var backup = new Backup()
            {
                Response = response,
                Status = status,
                CreatedAt = DateTime.Now
            };
            db.Backups.Add(backup);
            db.SaveChanges();
            LastBackupLbl.Text = backup.CreatedAt.ToString(CultureInfo.InvariantCulture);
        }
    }
}