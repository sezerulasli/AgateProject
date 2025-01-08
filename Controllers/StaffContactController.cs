using AgateProject.Data.Models;
using AgateProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgateProject.Controllers
{

    public class StaffContactController : Controller
    {
        StaffContactRepository staffContactRepository = new StaffContactRepository();
        public IActionResult Index()
        {
            var staffContacts = staffContactRepository.List();
            return View(staffContacts);
        }
        [HttpGet]
        public IActionResult AddStaffContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStaffContact(StaffContact staffContact)
        {
            if (!ModelState.IsValid)
            {
                return View("AddStaffContact");
            }
            staffContactRepository.Add(staffContact);
            return RedirectToAction("Index");
        }
    }
}
