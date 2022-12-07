using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  BTL_PTPMQL_NHOM12.Models
{
    public class Nganhang
    {
        [Key]


        [Required(ErrorMessage ="Mã ngân hàng không được để trống")]
        [Display(Name ="Mã ngân hàng")]
        public string? MaNH {get; set;}


        [Display(Name ="Tên ngân hàng")]
        [Required(ErrorMessage ="Tên ngân hàng không được để trống")]
        public string? TenNH {get; set;}
    }
}