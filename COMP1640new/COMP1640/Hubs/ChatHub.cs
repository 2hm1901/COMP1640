using COMP1640.Data;
using COMP1640.Models;
using Microsoft.AspNetCore.SignalR;

namespace COMP1640.Hubs;

public class ChatHub : Hub
{
    private readonly ApplicationDbContext _context;

    public ChatHub(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SendMessage(string receiverId, string content)
    {
        var senderId = Context.UserIdentifier;

        if (string.IsNullOrEmpty(senderId))
        {
            throw new HubException("Sender ID is missing.");
        }

        if (string.IsNullOrEmpty(receiverId))
        {
            throw new HubException("Receiver ID is missing.");
        }

        if (string.IsNullOrEmpty(content))
        {
            throw new HubException("Message content is missing.");
        }

        var message = new Message
        {
            SenderId = senderId,
            ReceiverId = receiverId,
            Content = content
        };

        _context.Messages.Add(message);
        await _context.SaveChangesAsync();

        await Clients.User(receiverId).SendAsync("ReceiveMessage", senderId, receiverId, content);
        await Clients.Caller.SendAsync("ReceiveMessage", senderId, receiverId, content);
    }
}