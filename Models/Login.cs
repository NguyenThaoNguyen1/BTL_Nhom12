using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  BTL_PTPMQL_NHOM12.Models
{
    public class login
    {
        [Key]

        [Required(ErrorMessage ="Tên đăng nhập không được để trống")]
        [Display(Name ="Tên đăng nhập")]
        public string? User {get; set;}

        
        [Required(ErrorMessage ="Mật khẩu không được để trống")]
        [Display(Name ="Mật khẩu")]
        [DataType(DataType.Password)]
        public string? Password {get; set;}
    }
}