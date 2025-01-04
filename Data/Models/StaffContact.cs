using System.ComponentModel.DataAnnotations;

namespace AgateProject.Data.Models
{
    public class StaffContact
    {
        [Key]
        public int StaffContactID { get; set; }
        public string? StaffContactName { get; set; }
        public int CampaignID { get; set; }
        public string? StaffContactEmail { get; set; }
        public string? StaffContactPassword { get; set; }
    }
}
