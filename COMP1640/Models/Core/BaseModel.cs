namespace Models.Core;
public abstract class BaseModel
{
    public int Id { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Today;
    public DateTime UpdatedDate { get; set; } = DateTime.Today;

    public bool IsOwner(int currentUserId)
    {
        return CreatedBy == currentUserId;
    }
}
