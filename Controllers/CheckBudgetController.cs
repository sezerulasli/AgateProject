using AgateProject.Data.Models;
using AgateProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AgateProject.Controllers
{
    public class CheckBudgetController : Controller
    {
        CampaignRepository campaignRepository = new CampaignRepository();
        ClientRepository clientRepository = new ClientRepository();
        public IActionResult Index()
        {
            var clients = clientRepository.List();
            var campaigns = campaignRepository.List();

            var model = new CampaignClientViewModel
            {
                Campaigns = campaigns,
                Clients = clients
            };

            return View(model);
        }
    }
}
