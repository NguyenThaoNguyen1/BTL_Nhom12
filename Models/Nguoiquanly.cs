using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTL_PTPMQL_NHOM12.Models
{
    public class Nguoiquanli
    {
        [Key]

        [Required(ErrorMessage ="Phòng ban không được để trống")]
        [Display(Name ="Mã người quản lí")]
        public string? MaQL {get; set;}

        [Display(Name ="Tên người quản lí")]
        public string? TenQL {get; set;}


        [Display(Name ="Tên Phòng ban")]
        public string? TenPB  {get; set;} 
        [ForeignKey("TenPB")]
        [Display(Name ="Tên Phòng ban")]
        public Phongban? Phongban {get; set;} 



        [Display(Name ="Số tài khoản")]
        [Phone(ErrorMessage ="Số tài khoản không đúng")]
        public string? SoTKNQL  {get; set;} 
        

        [Display(Name ="Địa chỉ")]
        public string? DiaChiNQL {get; set;} 


        // [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
        //            ErrorMessage = "Mời bạn nhập lại số điện thoại")]
        [MinLength(9)]
        [MaxLength(11)]
        [Phone(ErrorMessage ="Mời bạn nhập lại số điện thoại")]
        [Display(Name ="Số điện thoại")]
        public string? SDTNQl {get; set;} 

        
        [StringLength(100)]
        [Required(ErrorMessage ="Email không được để trống")]
        [EmailAddress(ErrorMessage ="Phải là địa chỉ email")]
        [Display(Name ="Email")]
        public string? EmailNQL {get; set;} 
           
    }
}