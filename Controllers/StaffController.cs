using AgateProject.Data.Models;
using AgateProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgateProject.Controllers
{

    public class StaffController : Controller
    {
        Context c = new Context();
        StaffRepository staffRepository = new StaffRepository();
        StaffContactRepository staffContactRepository = new StaffContactRepository();
        public IActionResult Index()
        {
            var staffs = staffRepository.List();
            return View(staffs);
        }
        [HttpGet]
        public IActionResult AddStaff()
        {
            List<SelectListItem> list = (from item in c.Campaigns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = item.CampaignName,
                                             Value = item.CampaignID.ToString()
                                         }).ToList();
            ViewBag.l1 = list;
            return View();
        }
        [HttpPost]
        public IActionResult AddStaff(Staff Staff)
        {
            if (!ModelState.IsValid)
            {
                return View("AddStaff");
            }
            staffRepository.Add(Staff);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult GetStaffForContact(int id)
        {
            List<SelectListItem> list = (from item in c.Campaigns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = item.CampaignName,
                                             Value = item.CampaignID.ToString()
                                         }).ToList();
            ViewBag.l1 = list;
            var x = staffRepository.Get(id);
            Staff st = new Staff()
            {
                StaffID = x.StaffID,
                StaffName = x.StaffName,
                StaffPassword = x.StaffPassword,
                StaffEmail = x.StaffEmail,
                CampaignID = x.CampaignID,
            };
            return View(st);
        }
        [HttpGet]
        public IActionResult GetStaffForAssign(int id)
        {
            List<SelectListItem> list = (from item in c.Campaigns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = item.CampaignName,
                                             Value = item.CampaignID.ToString()
                                         }).ToList();
            ViewBag.l1 = list;
            var x = staffRepository.Get(id);
            Staff st = new Staff()
            {
                StaffID = x.StaffID,
                StaffName = x.StaffName,
                StaffEmail = x.StaffEmail,
                StaffPassword = x.StaffPassword,
                CampaignID = x.CampaignID,
            };
            return View(st);
        }
        [HttpPost]
        public IActionResult AssignStaff(Staff staff)
        {
            var x = staffRepository.Get(staff.StaffID);
            x.StaffID = staff.StaffID;
            x.StaffName = staff.StaffName;
            x.StaffEmail = staff.StaffEmail;
            x.StaffPassword = staff.StaffPassword;
            x.CampaignID = staff.CampaignID;
            staffRepository.Update(x);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AssignStaffContact(Staff staff)
        {
            var x = staffRepository.Get(staff.StaffID);
            StaffContact st = new StaffContact()
            {
                StaffContactName = x.StaffName,
                StaffContactEmail = x.StaffEmail,
                StaffContactPassword = x.StaffPassword,
                CampaignID = x.CampaignID,
            };
            staffContactRepository.Add(st);
            return RedirectToAction("Index");
        }
    }
}
