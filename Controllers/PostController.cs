using QuanLyTinTuc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTinTuc.Controllers
{
    public class PostController : Controller
    {
        private DataContext _context;
        public PostController()
        {
            _context = new DataContext();
        }
        public ActionResult Index()
        {
            var data = _context.TinTucs.OrderByDescending(x => x.NgayDang).ToList();
            return View(data);
        }

        public ActionResult Detail(int id)
        {
            var data = _context.TinTucs.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
    }
}