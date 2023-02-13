using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simmakers.Test.ArtsiomLyshchyk.Models;
using Simmakers.Test.ArtsiomLyshchyk.Services;

namespace Simmakers.Test.ArtsiomLyshchyk.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BaseUserManager _userManager;
    
    public HomeController(BaseUserManager userManager, ILogger<HomeController> logger)
    {
        _userManager = userManager;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userManager.Users.ToArrayAsync();

        var viewModels = users.Select(BaseUserViewModel.From).ToArray();
        var viewModel = new UsersViewModel()
        {
            Users = viewModels
        };
        
        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}