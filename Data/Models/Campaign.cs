using System.ComponentModel.DataAnnotations;

namespace AgateProject.Data.Models
{
    public class Campaign
    {
        [Key]
        public int CampaignID { get; set; }
        public string? CampaignName { get; set; }
        public string? CampaignDescription { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly FinishDate { get; set; }
        public List<Staff>? Staffs { get; set; }
        public List<Client>? Clients { get; set; }
        public List<StaffContact>? Contacts { get; set; }
        public double CampaignBudget { get; set; }
    }
}
