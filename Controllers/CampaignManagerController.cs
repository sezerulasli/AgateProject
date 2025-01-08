using AgateProject.Data.Models;
using AgateProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgateProject.Controllers
{

    public class CampaignManagerController : Controller
    {
        CampaignManagerRepository campaignManagerRepository = new CampaignManagerRepository();
        public IActionResult Index()
        {
            var campaignManagers = campaignManagerRepository.List();
            return View(campaignManagers);
        }
        [HttpGet]
        public IActionResult AddCampaignManager()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCampaignManager(CampaignManager campaignManager)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCampaignMaster");
            }
            campaignManagerRepository.Add(campaignManager);
            return RedirectToAction("Index");
        }
    }
}
