using System;
using System.Collections.Generic;

namespace TestGit.Models;

/// <summary>
/// Bảng quản lý các đặc quyền dành cho thành viên hạng Elite
/// </summary>
public partial class EliteClubPrivilege
{
    /// <summary>
    /// Khóa chính tự tăng, định danh duy nhất cho mỗi đặc quyền
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Mã định danh duy nhất (không trùng lặp) cho đặc quyền
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// Tiêu đề đặc quyền (hỗ trợ Unicode)
    /// </summary>
    public string PrivilegeTitle { get; set; } = null!;

    /// <summary>
    /// Đường dẫn ảnh minh họa đặc quyền
    /// </summary>
    public string ImageUrl { get; set; } = null!;

    /// <summary>
    /// Đường dẫn đến trang chi tiết đặc quyền
    /// </summary>
    public string DetailUrl { get; set; } = null!;

    /// <summary>
    /// Thứ tự ưu tiên hiển thị (số càng nhỏ càng hiển thị trên)
    /// </summary>
    public short SortOrder { get; set; }

    /// <summary>
    /// Trạng thái hiển thị (1: Hiển thị, 0: Ẩn)
    /// </summary>
    public bool DisplayStatus { get; set; }

    /// <summary>
    /// Thời điểm tạo bản ghi (tự động điền)
    /// </summary>
    public DateTime? CreatedDate { get; set; }

    /// <summary>
    /// Thời điểm cập nhật cuối cùng (tự động cập nhật khi chỉnh sửa)
    /// </summary>
    public DateTime? ModifiedDate { get; set; }
}
