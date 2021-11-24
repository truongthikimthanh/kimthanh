using doan.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doan.Controllers
{
    public class SanPhamController : Controller
    {
        public IActionResult Index()
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;

            List<
                SanPhamModel> list = new List<SanPhamModel>();
            return View(context.GetSanPham());
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new SanPhamModel();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SanPhamModel nv)
        {
            int count = 0;
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;
            count = context.CreateSanPham(nv);
            if (count != 0)
            {
                return Redirect("/SanPham");
            }
            return Redirect("/SanPham");
        }
        public IActionResult Edit(int maSP)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;
            ViewData["SanPham"] = context.GetDataSanPham(maSP);
            return View(context.GetDataSanPham(maSP));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SanPhamModel nv)
        {
            int count = 0;
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;
            count = context.UpdateSanPham(nv);
            if (count != 0)
            {
                return Redirect("Index");
            }
            return Redirect("Index");

        }

        public ActionResult Delete(int matv)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;
            ViewData["SanPham"] = context.GetDataNhanVien(matv);
            if (context.DeleteNhanVien(matv) != 0)
            {
                return Redirect("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
