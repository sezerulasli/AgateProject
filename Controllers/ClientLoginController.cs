using AgateProject.Data.Models;
using AgateProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AgateProject.Controllers
{
    public class ClientLoginController : Controller
    {
        CampaignRepository campaignRepository = new CampaignRepository();
        public IActionResult Index()
        {
            var campaigns = campaignRepository.List();
            return View(campaigns);
        }
    }
}
