using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BTL_PTPMQL_NHOM12.Models;

public class MovieGenreViewModel
{
    public List<Nganhang>? Nganhang{ get; set; }
    public SelectList? TenNH { get; set; }
    public string? TimkiemNH { get; set; }
    public List<Phongban>? Phongban{ get; set; }
    public SelectList? TenPB { get; set; }
    public string? TimkiemPB { get; set; }

    public string? SearchString { get; set; }
}