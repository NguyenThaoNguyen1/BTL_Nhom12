using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTL_PTPMQL_NHOM12.Models
{
    public class Dichvu
    {
        [Key]

        [Required(ErrorMessage ="Mã dịch vụ không được để trống")]
        [Display(Name ="Mã DV")]
        public string? MaDV {get; set;}

       
        [Display(Name ="Mã loại DV")]
        public string? MaLoaiDV {get; set;}
        [ForeignKey("MaLoaiDV")]
        [Display(Name ="Mã loại DV")]
        public Loaidichvu? Loaidichvu {get; set;} 

        
        [Required(ErrorMessage ="Tên dịch vụ không được để trống")]
        [Display(Name ="Tên DV")]
        public string? TenDV  {get; set;} 
        
        [Display(Name ="Đơn vị tính")]
        public string? DonViTinh  {get; set;}
         

        [Required(ErrorMessage ="Đơn giá không được để trống")]
        [Display(Name ="Đơn giá")]
        public string? DonGia  {get; set;}
       

        [Display(Name ="Ghi chú")]
        public string? GhiChu {get; set;}   
    }
}