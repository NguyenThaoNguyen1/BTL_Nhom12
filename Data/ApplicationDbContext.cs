using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BTL_PTPMQL_NHOM12.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BTL_PTPMQL_NHOM12.Models.Phongban> Phongban { get; set; } = default!;

        public DbSet<BTL_PTPMQL_NHOM12.Models.PhuongThucTT> PhuongThucTT { get; set; } = default!;

        public DbSet<BTL_PTPMQL_NHOM12.Models.Nganhang> Nganhang { get; set; } = default!;

        public DbSet<BTL_PTPMQL_NHOM12.Models.Loaidichvu> Loaidichvu { get; set; } = default!;

        public DbSet<BTL_PTPMQL_NHOM12.Models.Nhanvien> Nhanvien { get; set; } = default!;

        public DbSet<BTL_PTPMQL_NHOM12.Models.Nguoiquanli> Nguoiquanli { get; set; } = default!;

        public DbSet<BTL_PTPMQL_NHOM12.Models.Dichvu> Dichvu { get; set; } = default!;

        public DbSet<BTL_PTPMQL_NHOM12.Models.Khachhang> Khachhang { get; set; } = default!;

        public DbSet<BTL_PTPMQL_NHOM12.Models.Kyhopdong> Kyhopdong { get; set; } = default!;

        public DbSet<BTL_PTPMQL_NHOM12.Models.Dangki> Dangki { get; set; } = default!;

        public DbSet<BTL_PTPMQL_NHOM12.Models.Giaonhan> Giaonhan { get; set; } = default!;

        public DbSet<BTL_PTPMQL_NHOM12.Models.login> login { get; set; } = default!;
    }
