using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTL_PTPMQL_NHOM12.Models
{
    public class Kyhopdong
    {
        [Key]
        [Required(ErrorMessage ="Số hợp đồng không được để trống")]
        [Display(Name ="Số HĐ")]
        public string? SoHD {get; set;}

        
        
        [Display(Name ="Mã QL")]
        public string? MaQL {get; set;}
        [ForeignKey("MaQL")]
        [Display(Name ="Mã QL")]
        public Nguoiquanli? Nguoiquanli {get; set;}

       
       
        [Display(Name ="Mã KH")]     
        public string? MaKH  {get; set;} 
        [ForeignKey("MaKH")]
        [Display(Name ="Mã KH")]
        public Khachhang? Khachhang {get; set;} 



        [Display(Name ="Mã DV")]
        public string? MaDV  {get; set;}
        [ForeignKey("MaDV")]
        [Display(Name ="Mã DV")]
        public Dichvu? Dichvu {get; set;}  


        [Required(ErrorMessage ="Nội dung không được để trống")]
        [Display(Name ="Nội dung")]
        public string? NoiDung  {get; set;}


        [Required(ErrorMessage ="Địa điểm không được để trống")]
        [Display(Name ="Địa điểm")]
        public string? DiaDiem  {get; set;}


        [Display(Name ="Ngày kí")]
        [DataType(DataType.Date)]
        public DateTime NgayKi { get; set; }


        [Display(Name ="Thời gian TT")]
        [DataType(DataType.Date)]
        public DateTime ThoiGianThanhToan { get; set; }
    


        [Display(Name ="Phương thức TT")]
        public string? PhuongThucThanhToan  {get; set;}
        [ForeignKey("PhuongThucThanhToan")]
        [Display(Name ="Phương thức TT")]
        public PhuongThucTT? PhuongThucTT {get; set;}


        [Display(Name ="Trách nhiệm chung")]
        public string? TrachNhiemChung  {get; set;}

        
    }
}