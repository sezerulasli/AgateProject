namespace AgateProject.Data.Models
{
    public class CampaignClientViewModel
    {
        public List<Campaign> Campaigns { get; set; }
        public List<Client> Clients { get; set; }
        public int SelectedCampaignId { get; set; }
        public int SelectedClientId { get; set; }
    }
}
