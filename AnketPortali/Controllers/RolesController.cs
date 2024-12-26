using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AnketPortali.Models;  // Projenizin doğru namespace'ini kullandığınızdan emin olun

public class RolesController : Controller
{
    private readonly RoleManager<AppRole> _roleManager;

    public RolesController(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    // Rolleri listeleme
    public async Task<IActionResult> Index()
    {
        var roles = _roleManager.Roles.ToList();  // AppRole kullanıyoruz burada
        return View(roles);
    }

    // Rol ekleme
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(string roleName)
    {
        if (!string.IsNullOrEmpty(roleName))
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                var result = await _roleManager.CreateAsync(new AppRole { Name = roleName });
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
        }

        // Hata durumunda aynı sayfayı yeniden göster
        return View();
    }
}
