using COMP1640.Data;
using COMP1640.Models;
using COMP1640.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP1640.Controllers;

[Authorize(Roles = "Student")]
public class StudentController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public StudentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
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

        var tutor = await _context.Users
            .Where(t => t.Id == user.TutorId)
            .Select(t => new TutorMessageViewModel
            {
                TutorId = t.Id,
                TutorName = t.FullName,
                LastMessage = _context.Messages
                    .Where(m => (m.SenderId == user.Id && m.ReceiverId == t.Id) || (m.SenderId == t.Id && m.ReceiverId == user.Id))
                    .OrderByDescending(m => m.Timestamp)
                    .Select(m => m.Content)
                    .FirstOrDefault() ?? "No messages yet",
                Interactions = _context.Interactions
                .Where(i => i.TutorId == t.Id && i.StudentId == user.Id)  // Get only interactions related to this student
                .OrderByDescending(i => i.Timestamp)
                .Select(i => new InteractionViewModel
                {
                    Type = i.Type,
                    TutorName = t.FullName,
                    Timestamp = i.Timestamp
                })
                .Take(5)
                .ToList()
            })
            .FirstOrDefaultAsync();

        return View(tutor);
    }

    public IActionResult Document()
    {
        var documents = new List<DocumentViewModel>
            {
                new DocumentViewModel
                {
                    Author = "Bui Minh",
                    DocumentName = "COMP1786_001428450_Logbook_Exercise1.pdf",
                    DateUploaded = new DateTime(2022, 12, 6, 10, 35, 0),
                    Comments = new List<CommentViewModel>
                    {
                        new CommentViewModel { Author = "Ms. Tra", Content = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." }
                    }
                },
                new DocumentViewModel
                {
                    Author = "Bui Minh",
                    DocumentName = "COMP1786_001428450_Logbook_Exercise2.pdf",
                    DateUploaded = new DateTime(2022, 12, 6, 10, 35, 0),
                    Comments = new List<CommentViewModel>
                    {
                        new CommentViewModel { Author = "Ms. Tra", Content = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." },
                        new CommentViewModel { Author = "Ms. Tra", Content = "Another comment goes here." }
                    }
                }
            };

        return View(documents);
    }
}
