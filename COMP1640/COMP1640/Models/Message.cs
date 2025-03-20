using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP1640.Models;

public class Message
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string SenderId { get; set; }

    [Required]
    public string ReceiverId { get; set; }

    [Required]
    public string Content { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    [ForeignKey("SenderId")]
    public virtual ApplicationUser Sender { get; set; }

    [ForeignKey("ReceiverId")]
    public virtual ApplicationUser Receiver { get; set; }
}
