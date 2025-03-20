using COMP1640.Data;
using COMP1640.Models;
using COMP1640.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP1640.Controllers;

[Authorize(Roles = "Teacher")]
public class TeacherController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public TeacherController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Dashboard()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return RedirectToAction("Login", "Account");

        // Get students assigned to this teacher
        var students = await _context.Users
            .Where(s => s.TutorId == user.Id) // Students assigned to this teacher
            .Select(s => new StudentMessageViewModel
            {
                StudentId = s.Id,
                StudentName = s.FullName,
                LastMessage = _context.Messages
                    .Where(m => (m.SenderId == s.Id && m.ReceiverId == user.Id) || (m.SenderId == user.Id && m.ReceiverId == s.Id))
                    .OrderByDescending(m => m.Timestamp)
                    .Select(m => m.Content)
                    .FirstOrDefault() ?? "No messages yet"
            })
            .ToListAsync();

        return View(students);
    }

    public IActionResult Document()
    {
        return View();
    }
}
