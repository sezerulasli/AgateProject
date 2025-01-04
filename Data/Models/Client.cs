using System.ComponentModel.DataAnnotations;

namespace AgateProject.Data.Models
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        public string? ClientName { get; set; }
        public double ClientPayment {  get; set; }
        public string? ClientAddress { get; set; }
        public string? ClientEmail { get; set; }
        public string? ClientPassword { get; set; }
        public int CampaignID { get; set; }
    }
}
