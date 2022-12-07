using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTL_PTPMQL_NHOM12.Models
{
    public class Khachhang
    {
        [Key]

        [Required(ErrorMessage ="Mã khách hàng không được để trống")]
        [Display(Name ="Mã KH")]
        public string? MaKH {get; set;}


        [Required(ErrorMessage ="Tên khách hàng không được để trống")]
        [Display(Name ="Tên KH")]
        public string? TenKH {get; set;}


        [Display(Name ="Cơ quan")]
        public string? CoQuanKH  {get; set;} 


        [StringLength(50)]
        [Phone(ErrorMessage ="Phải là Số tài khoản")]
        [Display(Name ="Số tài khoản")]
        public string? SoTKKH  {get; set;} 
         

        [Display(Name ="Ngân hàng")]
        public string? TenNH {get; set;} 
        [ForeignKey("TenNH")]
        [Display(Name ="Ngân hàng")]
        public Nganhang? Nganhang {get; set;} 


        [Required(ErrorMessage ="Địa chỉ không được để trống")]
        [Display(Name ="Địa chỉ")]
        public string? DiaChiKH {get; set;} 


        [StringLength(50)]
        [Phone(ErrorMessage ="Xin mời bạn nhập lại số điện thoại ")]
        [Display(Name ="Số điện thoại")]
        public string? SDTKH {get; set;} 


        [StringLength(100)]
        [Required(ErrorMessage ="Email không được để trống")]
        [EmailAddress(ErrorMessage ="Phải là địa chỉ email")]
        [Display(Name ="Email")]
        public string? EmailKH {get; set;} 
    }
}