using Microsoft.EntityFrameworkCore;

namespace FtpService;

public class ApplicationDbContext : DbContext
{
    public string DbPath { get; }
    public DbSet<Backup> Backups { get; set; }

    public ApplicationDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "backup.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}