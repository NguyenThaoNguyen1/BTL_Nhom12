using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTL_PTPMQL_NHOM12.Models
{
    public class Nhanvien
    {
        [Key]

        [Required(ErrorMessage ="Mã nhân viên không được để trống")]
        [Display(Name ="Mã nhân viên")]
        public string? MaNV {get; set;}


        [Required(ErrorMessage ="Tên nhân viên không được để trống")]
        [Display(Name ="Tên nhân viên")]
        public string? TenNV {get; set;}


        [Display(Name ="Giới tính")]
        public string? GioiTinhNV  {get; set;} 
    

        [Required(ErrorMessage ="Phòng ban không được để trống")]
        [Display(Name ="Phòng ban")]
        public string? TenPB  {get; set;} 
        [ForeignKey("TenPB")]
        [Display(Name ="Phòng ban")]
        public Phongban? Phongban {get; set;} 



        [Display(Name ="Địa chỉ")]
        public string? DiaChiNV {get; set;} 



        [StringLength(100)]
        [Required(ErrorMessage ="Email không được để trống")]
        [EmailAddress(ErrorMessage ="Nhập lại địa chỉ email")]
        [Display(Name ="Email")]
        public string? EmailNV {get; set;} 


        
        [Phone(ErrorMessage ="Phải là Số điện thoại")]
        [Display(Name ="Số điện thoại")]
        [MinLength(9)]
        [MaxLength(11)]

        public string? SDTNV {get; set;} 


        [Display(Name ="Chức vụ")]
        public string? ChucVuNV {get; set;} 
    }
}