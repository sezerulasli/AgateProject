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
        public DateOnly CompletionDate { get; set; }
        public string? CompletionState { get; set; }
        public int CampaignID { get; set; }
    }
}
