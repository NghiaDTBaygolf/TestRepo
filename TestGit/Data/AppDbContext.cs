using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestGit.Models;

namespace TestGit.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EliteClubPrivilege> EliteClubPrivileges { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-F7DLD7D;Initial Catalog=Baygolf;User ID=sa;Password=sa123;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EliteClubPrivilege>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EliteClu__3214EC07C6E640EC");

            entity.ToTable("EliteClubPrivilege", tb => tb.HasComment("Bảng quản lý các đặc quyền dành cho thành viên hạng Elite"));

            entity.HasIndex(e => e.Code, "IDX_EliteClubPrivilege_Code");

            entity.HasIndex(e => e.PrivilegeTitle, "IDX_EliteClubPrivilege_Title");

            entity.HasIndex(e => e.Code, "UC_EliteClubPrivilege_Code").IsUnique();

            entity.Property(e => e.Id).HasComment("Khóa chính tự tăng, định danh duy nhất cho mỗi đặc quyền");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Mã định danh duy nhất (không trùng lặp) cho đặc quyền");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Thời điểm tạo bản ghi (tự động điền)")
                .HasColumnType("datetime");
            entity.Property(e => e.DetailUrl)
                .IsUnicode(false)
                .HasComment("Đường dẫn đến trang chi tiết đặc quyền");
            entity.Property(e => e.DisplayStatus)
                .HasDefaultValue(true)
                .HasComment("Trạng thái hiển thị (1: Hiển thị, 0: Ẩn)");
            entity.Property(e => e.ImageUrl)
                .IsUnicode(false)
                .HasComment("Đường dẫn ảnh minh họa đặc quyền");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Thời điểm cập nhật cuối cùng (tự động cập nhật khi chỉnh sửa)")
                .HasColumnType("datetime");
            entity.Property(e => e.PrivilegeTitle)
                .HasMaxLength(250)
                .HasComment("Tiêu đề đặc quyền (hỗ trợ Unicode)");
            entity.Property(e => e.SortOrder).HasComment("Thứ tự ưu tiên hiển thị (số càng nhỏ càng hiển thị trên)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
