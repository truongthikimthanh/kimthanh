using doan.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doan.Controllers
{
    public class ThanhVienController : Controller
    {
        public IActionResult Index()
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;

            List<ThanhVienModel> list = new List<ThanhVienModel>();
            return View(context.GetThanhVien());
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new ThanhVienModel();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ThanhVienModel nv)
        {
            int count = 0;
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;
            count = context.CreateThanhVien(nv);
            if (count != 0)
            {
                return Redirect("/Thanhvien");
            }
            return Redirect("/Thanhvien");
        }
        public IActionResult Edit(int maTV)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;
            ViewData["ThanhVien"] = context.GetDataThanhVien(maTV);
            return View(context.GetDataThanhVien(maTV));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ThanhVienModel nv)
        {
            int count = 0;
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;
            count = context.UpdateThanhVien(nv);
            if (count != 0)
            {
                return Redirect("Index");
            }
            return Redirect("Index");

        }

        public ActionResult Delete(int matv)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;
            ViewData["NhanVien"] = context.GetDataNhanVien(matv);
            if (context.DeleteNhanVien(matv) != 0)
            {
                return Redirect("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
