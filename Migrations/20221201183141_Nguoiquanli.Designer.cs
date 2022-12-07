﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTLPTPMQLNHOM12.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221201183141_Nguoiquanli")]
    partial class Nguoiquanli
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

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
