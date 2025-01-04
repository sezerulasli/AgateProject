using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using AgateProject.Data.Models;
using System.Security.Claims;
    
namespace AgateProject.Controllers
{
    [AllowAnonymous]    
    public class LoginController : Controller
    {
        Context c = new Context();
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
      /* public async Task<IActionResult> Index(string email, string password)
        {
            // CampaignManager tablosunda arama yap
            var campaignManagerData = c.CampaignManagers.FirstOrDefault(x => x.CampaignManagerEmail == email && x.CampaignManagerPassword == password);

            if (campaignManagerData != null)
            {
                // Kullanıcı CampaignManager rolüyle giriş yaptı
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, email),
            new Claim(ClaimTypes.Role, "CampaignManager")
        };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Campaign");
            }

            // Client tablosunda arama yap
            var clientData = c.Clients.FirstOrDefault(x => x.ClientEmail == email && x.ClientPassword == password);

            if (clientData != null)
            {
                // Kullanıcı Client rolüyle giriş yaptı
                var claimsClient = new List<Claim>
        {
            new Claim(ClaimTypes.Name, email),
            new Claim(ClaimTypes.Role, "Client")
        };
                var useridentityClient = new ClaimsIdentity(claimsClient, "Login");
                ClaimsPrincipal principalClient = new ClaimsPrincipal(useridentityClient);
                await HttpContext.SignInAsync(principalClient);
                return RedirectToAction("Index", "ClientLogin");
            }

            // Eğer giriş başarısız olursa
            ModelState.AddModelError("", "Email veya şifre hatalı.");
            return View();
        } */

         [HttpPost]
         public async Task<IActionResult> Index(string email, string password)
         {
             var loginData = c.CampaignManagers.FirstOrDefault(x => x.CampaignManagerEmail == email && x.CampaignManagerPassword == password);
             if (loginData != null)
             {
                 var claims = new List<Claim>
                 {
                     new Claim(ClaimTypes.Name, email)
                 };
                 var useridentity = new ClaimsIdentity(claims, "Login");
                 ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                 await HttpContext.SignInAsync(principal);
                 return RedirectToAction("Index", "Campaign");
             }
             var loginStaffContactData = c.StaffContacts.FirstOrDefault(x => x.StaffContactEmail == email && x.StaffContactPassword == password);
             if (loginStaffContactData != null)
             {
                 var claimsStaffContact = new List<Claim>
                 {
                     new Claim(ClaimTypes.Name, email)
                 };
                 var useridentityStaffContact = new ClaimsIdentity(claimsStaffContact, "Login");
                 ClaimsPrincipal principalStaffContact = new ClaimsPrincipal(useridentityStaffContact);
                 await HttpContext.SignInAsync(principalStaffContact);
                 return RedirectToAction("Index", "StaffContactLogin");
             }
             return View();
         } 
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
       /* [HttpPost]
        public async Task<IActionResult> Index(Client p)
        {
            var loginData = c.Clients.FirstOrDefault(x => x.ClientEmail == p.ClientEmail && x.ClientPassword == p.ClientPassword);
            if (loginData != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.ClientEmail)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("CampaignListForClient", "Login");
            }
            return View();
        }*/
    }
}
