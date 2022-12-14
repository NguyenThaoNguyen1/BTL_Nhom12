// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTLPTPMQLNHOM12.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221203043549_Login")]
    partial class Login
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("BTL_PTPMQL_NHOM12.Models.Dangki", b =>
                {
                    b.Property<string>("MaDK")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaDV")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaKH")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NgayDangKi")
                        .HasColumnType("TEXT");

                    b.Property<string>("SoLuong")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaDK");

                    b.HasIndex("MaDV");

                    b.HasIndex("MaKH");

                    b.ToTable("Dangki");
                });

            modelBuilder.Entity("BTL_PTPMQL_NHOM12.Models.Dichvu", b =>
                {
                    b.Property<string>("MaDV")
                        .HasColumnType("TEXT");

                    b.Property<string>("DonGia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DonViTinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("GhiChu")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaLoaiDV")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenDV")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaDV");

                    b.HasIndex("MaLoaiDV");

                    b.ToTable("Dichvu");
                });

            modelBuilder.Entity("BTL_PTPMQL_NHOM12.Models.Giaonhan", b =>
                {
                    b.Property<string>("MaQL")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaDV")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaNV")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NgayGiao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NgayHoanThanh")
                        .HasColumnType("TEXT");

                    b.Property<string>("TrangThaiHienTai")
                        .HasColumnType("TEXT");

                    b.HasKey("MaQL");

                    b.HasIndex("MaDV");

                    b.HasIndex("MaNV");

                    b.ToTable("Giaonhan");
                });

            modelBuilder.Entity("BTL_PTPMQL_NHOM12.Models.Khachhang", b =>
                {
                    b.Property<string>("MaKH")
                        .HasColumnType("TEXT");

                    b.Property<string>("CoQuanKH")
                        .HasColumnType("TEXT");

                    b.Property<string>("DiaChiKH")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailKH")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("SDTKH")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("SoTKKH")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("TenKH")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenNH")
                        .HasColumnType("TEXT");

                    b.HasKey("MaKH");

                    b.HasIndex("TenNH");

                    b.ToTable("Khachhang");
                });

            modelBuilder.Entity("BTL_PTPMQL_NHOM12.Models.Kyhopdong", b =>
                {
                    b.Property<string>("SoHD")
                        .HasColumnType("TEXT");

                    b.Property<string>("DiaDiem")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaDV")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaKH")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaQL")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NgayKi")
                        .HasColumnType("TEXT");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhuongThucThanhToan")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ThoiGianThanhToan")
                        .HasColumnType("TEXT");

                    b.Property<string>("TrachNhiemChung")
                        .HasColumnType("TEXT");

                    b.HasKey("SoHD");

                    b.HasIndex("MaDV");

                    b.HasIndex("MaKH");

                    b.HasIndex("MaQL");

                    b.HasIndex("PhuongThucThanhToan");

                    b.ToTable("Kyhopdong");
                });

            modelBuilder.Entity("BTL_PTPMQL_NHOM12.Models.Loaidichvu", b =>
                {
                    b.Property<string>("MaLoaiDV")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenLoaiDV")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("YeuCaudikem")
                        .HasColumnType("TEXT");

                    b.HasKey("MaLoaiDV");

                    b.ToTable("Loaidichvu");
                });

            modelBuilder.Entity("BTL_PTPMQL_NHOM12.Models.Nganhang", b =>
                {
                    b.Property<string>("MaNH")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenNH")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaNH");

                    b.ToTable("Nganhang");
                });

            modelBuilder.Entity("BTL_PTPMQL_NHOM12.Models.Nguoiquanli", b =>
                {
                    b.Property<string>("MaQL")
                        .HasColumnType("TEXT");

                    b.Property<string>("DiaChiNQL")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailNQL")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("SDTNQl")
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<string>("SoTKNQL")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenPB")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenQL")
                        .HasColumnType("TEXT");

                    b.HasKey("MaQL");

                    b.HasIndex("TenPB");

                    b.ToTable("Nguoiquanli");
                });

            modelBuilder.Entity("BTL_PTPMQL_NHOM12.Models.Nhanvien", b =>
                {
                    b.Property<string>("MaNV")
                        .HasColumnType("TEXT");

                    b.Property<string>("ChucVuNV")
                        .HasColumnType("TEXT");

                    b.Property<string>("DiaChiNV")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailNV")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("GioiTinhNV")
                        .HasColumnType("TEXT");

                    b.Property<string>("SDTNV")
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<string>("TenNV")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenPB")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaNV");

                    b.HasIndex("TenPB");

                    b.ToTable("Nhanvien");
                });

            modelBuilder.Entity("BTL_PTPMQL_NHOM12.Models.Phongban", b =>
                {
                    b.Property<string>("MaPB")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenPB")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaPB");

                    b.ToTable("Phongban");
                });

            modelBuilder.Entity("BTL_PTPMQL_NHOM12.Models.PhuongThucTT", b =>
                {
                    b.Property<string>("MaPT")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhuongThucthanhToan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaPT");

                    b.ToTable("PhuongThucTT");
                });

            modelBuilder.Entity("BTL_PTPMQL_NHOM12.Models.login", b =>
                {
                    b.Property<string>("User")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.HasKey("User");

                    b.ToTable("login");
                });

            modelBuilder.Entity("BTL_PTPMQL_NHOM12.Models.Dangki", b =>
                {
                    b.HasOne("BTL_PTPMQL_NHOM12.Models.Dichvu", "Dichvu")
                        .WithMany()
                        .HasForeignKey("MaDV");

                    b.HasOne("BTL_PTPMQL_NHOM12.Models.Khachhang", "Khachhang")
                        .WithMany()
                        .HasForeignKey("MaKH");

                    b.Navigation("Dichvu");

                    b.Navigation("Khachhang");
                });

            modelBuilder.Entity("BTL_PTPMQL_NHOM12.Models.Dichvu", b =>
                {
                    b.HasOne("BTL_PTPMQL_NHOM12.Models.Loaidichvu", "Loaidichvu")
                        .WithMany()
                        .HasForeignKey("MaLoaiDV");

                    b.Navigation("Loaidichvu");
                });

            modelBuilder.Entity("BTL_PTPMQL_NHOM12.Models.Giaonhan", b =>
                {
                    b.HasOne("BTL_PTPMQL_NHOM12.Models.Dichvu", "Dichvu")
                        .WithMany()
                        .HasForeignKey("MaDV");

                    b.HasOne("BTL_PTPMQL_NHOM12.Models.Nhanvien", "Nhanvien")
                        .WithMany()
                        .HasForeignKey("MaNV");

                    b.HasOne("BTL_PTPMQL_NHOM12.Models.Nguoiquanli", "Nguoiquanli")
                        .WithMany()
                        .HasForeignKey("MaQL")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dichvu");

                    b.Navigation("Nguoiquanli");

                    b.Navigation("Nhanvien");
                });

            modelBuilder.Entity("BTL_PTPMQL_NHOM12.Models.Khachhang", b =>
                {
                    b.HasOne("BTL_PTPMQL_NHOM12.Models.Nganhang", "Nganhang")
                        .WithMany()
                        .HasForeignKey("TenNH");

                    b.Navigation("Nganhang");
                });

            modelBuilder.Entity("BTL_PTPMQL_NHOM12.Models.Kyhopdong", b =>
                {
                    b.HasOne("BTL_PTPMQL_NHOM12.Models.Dichvu", "Dichvu")
                        .WithMany()
                        .HasForeignKey("MaDV");

                    b.HasOne("BTL_PTPMQL_NHOM12.Models.Khachhang", "Khachhang")
                        .WithMany()
                        .HasForeignKey("MaKH");

                    b.HasOne("BTL_PTPMQL_NHOM12.Models.Nguoiquanli", "Nguoiquanli")
                        .WithMany()
                        .HasForeignKey("MaQL");

                    b.HasOne("BTL_PTPMQL_NHOM12.Models.PhuongThucTT", "PhuongThucTT")
                        .WithMany()
                        .HasForeignKey("PhuongThucThanhToan");

                    b.Navigation("Dichvu");

                    b.Navigation("Khachhang");

                    b.Navigation("Nguoiquanli");

                    b.Navigation("PhuongThucTT");
                });

            modelBuilder.Entity("BTL_PTPMQL_NHOM12.Models.Nguoiquanli", b =>
                {
                    b.HasOne("BTL_PTPMQL_NHOM12.Models.Phongban", "Phongban")
                        .WithMany()
                        .HasForeignKey("TenPB");

                    b.Navigation("Phongban");
                });

            modelBuilder.Entity("BTL_PTPMQL_NHOM12.Models.Nhanvien", b =>
                {
                    b.HasOne("BTL_PTPMQL_NHOM12.Models.Phongban", "Phongban")
                        .WithMany()
                        .HasForeignKey("TenPB")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phongban");
                });
#pragma warning restore 612, 618
        }
    }
}
