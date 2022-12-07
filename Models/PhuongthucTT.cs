using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  BTL_PTPMQL_NHOM12.Models
{
    public class PhuongThucTT
    {
        [Key]
        [Required(ErrorMessage ="Mã phương thức không được để trống")]
        [Display(Name ="Mã phương thức")]
        public string? MaPT {get; set;}


        [Required(ErrorMessage ="Tên phương thức không được để trống")]
        [Display(Name ="Phương thức thanh toán")]
        public string? PhuongThucthanhToan {get; set;}
    }
}