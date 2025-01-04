using AgateProject.Data.Models;
using AgateProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AgateProject.Controllers
{
    public class StaffContactLoginController : Controller
    {
        ClientContactRepository clientContactRepository = new ClientContactRepository();
        public IActionResult Index()
        {
            var clientContacts = clientContactRepository.List();
            return View(clientContacts);
        }
    }
}
