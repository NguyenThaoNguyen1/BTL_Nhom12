using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  BTL_PTPMQL_NHOM12.Models
{
    public class Giaonhan
    {
        [Key]

        public string? MaQL {get; set;}
        [ForeignKey("MaQL")]
        [Display(Name ="Mã quản lí")]
        public Nguoiquanli? Nguoiquanli {get; set;} 


        public string? MaNV {get; set;}
        [ForeignKey("MaNV")]
        [Display(Name ="Mã nhân viên")]
        public Nhanvien? Nhanvien {get; set;} 


        public string? MaDV {get; set;}
        [ForeignKey("MaDV")]
        [Display(Name ="Mã dịch vụ")]
        public Dichvu? Dichvu {get; set;}


        [Display(Name ="Trạng thái hiện")]
        public string? TrangThaiHienTai {get; set;}


        [Display(Name ="Ngày giao")]
        [DataType(DataType.Date)]
        public DateTime NgayGiao { get; set; }
        
        
        [Display(Name ="Ngày hoàn thành")]
        [DataType(DataType.Date)]
        public DateTime NgayHoanThanh { get; set; }
    }
}