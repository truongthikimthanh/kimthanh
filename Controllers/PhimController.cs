using doan.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doan.Controllers
{
    public class PhimController : Controller
    {
        public IActionResult Index()
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;

            List<PhimModel> list = new List<PhimModel>();
            return View(context.GetPhim());
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new PhimModel();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PhimModel nv)
        {
            int count = 0;
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;
            count = context.CreatePhim(nv);
            if (count != 0)
            {
                return Redirect("/Phim");
            }
            return Redirect("/Phim");
        }
        public IActionResult Edit(int maPhim)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;
            ViewData["Phim"] = context.GetDataPhim(maPhim);
            return View(context.GetDataPhim(maPhim));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PhimModel nv)
        {
            int count = 0;
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;
            count = context.UpdatePhim(nv);
            if (count != 0)
            {
                return Redirect("Index");
            }
            return Redirect("Index");

        }

        public ActionResult Delete(int maPhim)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;
            ViewData["NhanVien"] = context.GetDataPhim(maPhim);
            if (context.DeleteNhanVien(maPhim) != 0)
            {
                return Redirect("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
