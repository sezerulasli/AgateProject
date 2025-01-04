using AgateProject.Data.Models;
using AgateProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgateProject.Controllers
{
   
    public class ClientContactController : Controller
    {
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
                return View("AddClient");
            }
            clientContactRepository.Add(clientContact);
            return RedirectToAction("Index");
        }
    }
}
