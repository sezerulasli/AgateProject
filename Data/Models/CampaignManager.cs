using System.ComponentModel.DataAnnotations;

namespace AgateProject.Data.Models
{
    public class CampaignManager
    {
        [Key]
        public int CampaignManagerID { get; set; }
        public string? CampaignManagerName { get; set; }
        public string? CampaignManagerEmail { get; set; }
        public string? CampaignManagerPassword { get; set; }

    }

}