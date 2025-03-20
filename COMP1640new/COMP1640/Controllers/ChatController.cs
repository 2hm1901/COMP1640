using COMP1640.Data;
using COMP1640.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP1640.Controllers;
public class ChatController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public ChatController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index(string userId)
    {
        var currentUser = await _userManager.GetUserAsync(User);
        //var messages = await _chatService.GetConversationAsync(currentUser.Id, userId);

        var messages = await _context.Messages
            .Where(m => (m.SenderId == currentUser.Id && m.ReceiverId == userId) ||
                       (m.SenderId == userId && m.ReceiverId == currentUser.Id))
            .OrderBy(m => m.Timestamp)
            .Include(m => m.Sender)
            .Include(m => m.Receiver)
            .ToListAsync();

        ViewBag.ReceiverId = userId;
        return View(messages);
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage(string receiverId, string message)
    {
        var sender = await _userManager.GetUserAsync(User);

        var newMessage = new Message
        {
            SenderId = sender.Id,
            ReceiverId = receiverId,
            Content = message
        };

        _context.Messages.Add(newMessage);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
