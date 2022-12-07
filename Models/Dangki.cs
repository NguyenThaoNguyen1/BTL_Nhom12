using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTL_PTPMQL_NHOM12.Models
{
    public class Dangki
    {
        [Key]


        [Required(ErrorMessage ="Mã đăng kí không được để trống")]
        [Display(Name ="Mã ĐK")]
        public string? MaDK {get; set;}



        [Required(ErrorMessage ="Mã khách hàng không được để trống")]
        public string? MaKH {get; set;}
        [ForeignKey("MaKH")]
        [Display(Name ="Mã KH")]
        public Khachhang? Khachhang {get; set;} 


        [Required(ErrorMessage ="Mã dịch vụ không được để trống")]   
        public string? MaDV  {get; set;} 
        [ForeignKey("MaDV")]
        [Display(Name ="Mã DV")]
        public Dichvu? Dichvu {get; set;} 


        [Display(Name ="Ngày đăng kí")]
        [DataType(DataType.Date)]
        public DateTime NgayDangKi { get; set; }

        // public string? NgayDangKi  {get; set;}
         
        [Required(ErrorMessage ="Số lượng không được để trống")]
        [Display(Name ="Số lượng")]
        public string? SoLuong  {get; set;}
         
        
    }
}