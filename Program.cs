using Microsoft.AspNetCore.Routing.Template;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
	x.LoginPath = "/Login/Index";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireCampaignManagerRole",
         policy => policy.RequireRole("CampaignManager"));
});

builder.Services.AddControllersWithViews(config =>
{
	var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build(); 
	config.Filters.Add(new AuthorizeFilter(policy));
});

var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Campaign}/{action=Index}/{id?}");

app.Run();
