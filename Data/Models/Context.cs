using Microsoft.EntityFrameworkCore;

namespace AgateProject.Data.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=SEZER\\SQLEXPRESS; database=AgateProjectDB; integrated security=true; TrustServerCertificate = True");
        }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CampaignManager> CampaignManagers { get; set; }
        public DbSet<ClientContact> ClientContacts { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffContact> StaffContacts { get; set; }
    }
}
