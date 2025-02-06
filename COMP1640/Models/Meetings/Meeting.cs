using Models.Accounts;
using Models.Core;

namespace Models.Meetings;
public class Meeting : BaseModel
{
    // Tiêu đề của cuộc họp
    public string Title { get; set; }

    // Mô tả về cuộc họp
    public string Description { get; set; }

    // Thời gian bắt đầu cuộc họp
    public DateTime StartTime { get; set; }

    // Thời gian kết thúc cuộc họp
    public DateTime EndTime { get; set; }

    // Đường dẫn đến phòng họp
    public string RoomLink { get; set; }

    // Đường dẫn đến video ghi âm cuộc họp
    public string RecordingLink { get; set; }

    // Relationships

    // Người tổ chức cuộc họp
    public int HostId { get; set; }
    public Account Host { get; set; }

    // Người tham dự cuộc họp
    public int GuestId { get; set; }
    public Account Guest { get; set; }

}
