using Microsoft.AspNetCore.Mvc;
using AgateProject.Data.Models;
using AgateProject.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace AgateProject.Controllers
{
    
    public class CampaignController : Controller
    {
        Context c = new Context();
        CampaignRepository campaignRepository = new CampaignRepository();
        public IActionResult Index()
        {
            var campaigns = campaignRepository.List();
            return View(campaigns);
        }
        [HttpGet]
        public IActionResult AddCampaign()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetCampaign(int id)
        {
            var values = c.Campaigns.Where(x => x.CampaignID == id).FirstOrDefault();
            return Json(new
            {
                CampaignID = values.CampaignID,
                CampaignBudget = values.CampaignBudget,
                CampaignName = values.CampaignName
            });
        }
        [HttpPost]
        public IActionResult AddCampaign(Campaign campaign)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCampaign");
            }
            campaignRepository.Add(campaign);
            return RedirectToAction("Index");
        }
        public IActionResult CampaignClientDetails(int id)
        {
            var campaignName = c.Campaigns.Where(x => x.CampaignID == id).Select(y => y.CampaignName).FirstOrDefault();
            var values = c.Clients.Where(x => x.CampaignID == id).ToList();
            ViewBag.CampaignName = campaignName;
            return View(values);
        }
        public IActionResult CampaignStaffDetails(int id)
        {
            var campaignName = c.Campaigns.Where(x => x.CampaignID == id).Select(y => y.CampaignName).FirstOrDefault();
            var values = c.Staffs.Where(x => x.CampaignID == id).ToList();
            ViewBag.CampaignName = campaignName;
            return View(values);
        }
        public IActionResult CampaignContactDetails(int id)
        {
            var campaignName = c.Campaigns.Where(x => x.CampaignID == id).Select(y => y.CampaignName).FirstOrDefault();
            var values = c.StaffContacts.Where(x => x.CampaignID == id).ToList();
            ViewBag.CampaignName = campaignName;
            return View(values);
        }
    }
}
