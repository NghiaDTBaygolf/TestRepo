using System;
using System.ComponentModel.DataAnnotations;

namespace TestGit.ModelsRequest
{
    public class NewEliteClubPrivilegeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã đặc quyền không được để trống")]
        [Display(Name = "Mã đặc quyền Elite Club")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [Display(Name = "Tiêu đề đặc quyền Elite Club")]
        public string PrivilegeTitle { get; set; }
        [Required(ErrorMessage = "Phải có đường dấn chi tiết")]
        [Display(Name = "Đường dẫn chi tiết")]
        public string DetailUrl { get; set; }
        [Required(ErrorMessage = "Cần có ảnh mô tả đi kèm")]
        [Display(Name = "Ảnh mô tả")]
        public string ImageUrl { get; set; }
        public short SortOrder { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool DisplayStatus { get; set; } = true;
    }
}
