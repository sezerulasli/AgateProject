using System.ComponentModel.DataAnnotations;

namespace AgateProject.Data.Models
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }
        public string? StaffName { get; set; }
        public int CampaignID { get; set; }
    }
}
