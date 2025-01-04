using AgateProject.Data.Models;
using AgateProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgateProject.Controllers
{
   
    public class ClientContactController : Controller
    {
        Context c = new Context();
        ClientContactRepository clientContactRepository = new ClientContactRepository();
        public IActionResult Index()
        {
            var clientContacts  = clientContactRepository.List();
            return View(clientContacts);
        }
        [HttpGet]
        public IActionResult AddClientContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddClientContact(ClientContact clientContact)
        {
            if (!ModelState.IsValid)
            {
                return View("AddClientContact");
            }
            clientContactRepository.Add(clientContact);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetClientContact(int id)
        {
            var values = c.ClientContacts.Where(x => x.ClientContactID == id).FirstOrDefault();
            return View(values);
        }
        [HttpPost]
        public IActionResult ChangeClientContact(ClientContact clientContact)
        {
            var x = clientContactRepository.Get(clientContact.ClientContactID);
            x.ClientContactID = clientContact.ClientContactID;
            x.ClientContactName = clientContact.ClientContactName;
            x.ClientID = clientContact.ClientID;
            clientContactRepository.Update(x);
            return RedirectToAction("Index", "StaffContactLogin");

        }
    }
}
