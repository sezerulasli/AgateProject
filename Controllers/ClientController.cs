using AgateProject.Data.Models;
using AgateProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgateProject.Controllers
{
    
    public class ClientController : Controller
    {
        Context c = new Context();
        ClientRepository clientRepository = new ClientRepository();
        public IActionResult Index()
        {
            var clients = clientRepository.List();
            return View(clients);
        }
        [HttpGet]
        public IActionResult AddClient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return View("AddClient");
            }
            clientRepository.Add(client);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ClientContactDetails(int id)
        {
            var clientContacts = c.ClientContacts.Where(x=>x.ClientID == id).ToList();
            return View(clientContacts);
        }


        [HttpPost]
        public IActionResult RecordClient([FromBody] RecordClientModel model)
        {
            
            var client = c.Clients.FirstOrDefault(x => x.ClientID == model.ClientID);

            if (client != null)
            {
                client.CampaignID = model.CampaignID;

               
                var campaign = c.Campaigns.FirstOrDefault(x => x.CampaignID == model.CampaignID);
                if (campaign != null)
                {
                    DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
                    client.ClientPayment = campaign.CampaignBudget;
                    client.CompletionDate = currentDate;
                    client.CompletionState = "Yes";
                }

                c.SaveChanges();
                return Ok(new { Message = "Client updated successfully!" });
            }

            return NotFound(new { Message = "Client not found." });
        }

       
        public class RecordClientModel
        {
            public int CampaignID { get; set; }
            public int ClientID { get; set; }
        }

    }
}
