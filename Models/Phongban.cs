using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  BTL_PTPMQL_NHOM12.Models
{
    public class Phongban
    {
        [Key]

        [Required(ErrorMessage ="Mã phòng ban không được để trống")]
        [Display(Name ="Mã phòng ban")]
        public string? MaPB {get; set;}

        [Required(ErrorMessage ="Tên phòng ban không được để trống")]
        [Display(Name ="Tên phòng ban")]
        public string? TenPB {get; set;}
    }
}