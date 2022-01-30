namespace FtpService
{
    public partial class FtpForm : Form
    {
        public FtpForm()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {

        }

        private void StopBtn_Click(object sender, EventArgs e)
        {

        }

        private void FtpForm_Load(object sender, EventArgs e)
        {
            PasswordTxt.PasswordChar = '*';
            GetConfig();
        }

        private void HostnameTxt_TextChanged(object sender, EventArgs e)
        {
        }

        private void AddConfig()
        {
            using var db = new ApplicationDbContext();
            Console.WriteLine($"Database path: {db.DbPath}.");

            var config = db.Configurations.FirstOrDefault();
            if (config != null)
            {
                config.HostName = HostnameTxt.Text;
                config.UserName = UsernameTxt.Text;
                config.Password = PasswordTxt.Text;
                config.Port = int.Parse(PortTxt.Text ?? "21");
                config.PathList = PathListTxt.Text;
            }
            else
            {
                db.Add(new Configuration
                {
                    HostName = HostnameTxt.Text,
                    UserName = string.Empty,
                    Password = string.Empty,
                    Port = 21,
                    PathList = string.Empty,
                });

                Console.WriteLine("Inserting a new config");
            }

            db.SaveChanges();
        }

        private void GetConfig()
        {
            using var db = new ApplicationDbContext();
            Console.WriteLine($"Database path: {db.DbPath}.");

            var config = db.Configurations.FirstOrDefault();
            if (config != null)
            {
                HostnameTxt.Text = config.HostName;
                UsernameTxt.Text = config.UserName;
                PasswordTxt.Text = config.Password;
                PortTxt.Text = String.IsNullOrEmpty(config.Port.ToString()) ? config.Port.ToString() : "21";
                PathListTxt.Text = config.PathList;
            }
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
    }
}
