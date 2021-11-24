using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using doan.Models;
namespace doan.Controllers
{
    public class NhanVienController : Controller
    {
        public IActionResult Index()
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;

           // List<NhanVienModel> list = new List<NhanVienModel>();
            return View(context.GetNhanVien());
           
        }
        [HttpGet]
        public IActionResult Create()
       {
            var model = new NhanVienModel();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult  Create(NhanVienModel nv)
        {
            int count = 0;
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;
            count = context.CreateNhanVien(nv);
            if(count!=0)
            {
                return Redirect("/Nhanvien");
            }    
            return Redirect("/Nhanvien");
        }
        public IActionResult Edit(int maNV)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;
            ViewData["NhanVien"] = context.GetDataNhanVien(maNV);
            return View(context.GetDataNhanVien(maNV));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int maNV, NhanVienModel nv)
        {
            int count = 0;
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;
            count = context.UpdateNhanVien(nv);
            if(count !=0)
            {
                return View(context.GetDataNhanVien(maNV));
            }
            return View(context.GetDataNhanVien(maNV));

        }
        
        public ActionResult Delete(int manv)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.DataContext)) as DataContext;
            ViewData["NhanVien"] = context.GetDataNhanVien(manv);
            if (context.DeleteNhanVien(manv) != 0)
            {
                return Redirect("Index");
            }
            return RedirectToAction("Index");
        }


    }
}
