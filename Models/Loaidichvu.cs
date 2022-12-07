using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  BTL_PTPMQL_NHOM12.Models
{
    public class Loaidichvu
    {
        [Key]
        [Required(ErrorMessage ="Mã Loại dịch vụ không được để trống")]
        [Display(Name ="Mã Loại dịch vụ")]
        public string? MaLoaiDV {get; set;}

        
        [Required(ErrorMessage ="Tên Loại dịch vụ không được để trống")]
        [Display(Name ="Tên Loại dịch vụ")]
        public string? TenLoaiDV {get; set;}

        [Display(Name ="Yêu cầu đi kèm")]
        public string? YeuCaudikem {get; set;}

    }
}