using AgateProject.Data.Models;
using AgateProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgateProject.Controllers
{

    public class StaffController : Controller
    {
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
            var x = staffRepository.Get(id);
            Staff st = new Staff()
            {
                StaffID = x.StaffID,
                StaffName = x.StaffName,
                CampaignID = x.CampaignID,
            };
            return View(st);
        }
        [HttpGet]
        public IActionResult GetStaffForAssign(int id)
        {
            var x = staffRepository.Get(id);
            Staff st = new Staff()
            {
                StaffID = x.StaffID,
                StaffName = x.StaffName,
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
                CampaignID = x.CampaignID,
            };
            staffContactRepository.Add(st);
            return RedirectToAction("Index"); 
        }
    }
}
