using QuanLyTinTuc.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyTinTuc.Controllers
{
    public class HomeController : Controller
    {
        public readonly DataContext _context;
        public HomeController()
        {
            _context = new DataContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadTable(string tennen, int trangthai = -1, string tennguoimua = null)
        {
            var data = _context.TinTucs.OrderByDescending(x => x.NgayDang).AsQueryable();
            //if (!string.IsNullOrEmpty(tennen))
            //    data = data.Where(x => x.TenNen.Contains(tennen));
            //if (!string.IsNullOrEmpty(tennguoimua))
            //    data = data.Where(x => x.HoTen.Contains(tennguoimua));
            //if (trangthai != -1)
            //    data = data.Where(x => x.TinhTrang == trangthai);
            return View(data.ToList());
        }
        [HttpGet]
        public ActionResult AddOrUpdate(int id = 0)
        {
            //var ListTinhTrang = new List<TinhTrang>() {
            //    new TinhTrang(){Id = 0, Ten = "Nền trống"},
            //    new TinhTrang(){Id = 1, Ten = "Đã giao"},
            //};

            if (id == 0)
            {
                //ViewBag.TinhTrang = new SelectList(ListTinhTrang, "Id", "Ten");
                return View(new TinTuc());
            }
            else
            {
                var entity = _context.TinTucs.Where(x => x.Id == id).FirstOrDefault();
                if (entity == default(TinTuc))
                    throw new Exception("Không tìm thấy dữ liệu");
                //ViewBag.TinhTrang = new SelectList(ListTinhTrang, "Id", "Ten", entity.TinhTrang);
                return View(entity);
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddOrUpdate(TinTuc model)
        {
            try
            {
                if (model.Id == 0)
                {
                    _context.TinTucs.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    var entity = _context.TinTucs.Where(x => x.Id == model.Id).FirstOrDefault();
                    if (entity == default(TinTuc))
                        throw new Exception("Không tìm thấy dữ liệu.");
                    entity.TieuDe = model.TieuDe;
                    entity.MoTa = model.MoTa;
                    entity.NoiDung = model.NoiDung;
                    entity.HinhAnh = model.HinhAnh;
                    entity.NgayDang = model.NgayDang;

                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return Json(new GenericMessageVM()
                {
                    Status = false,
                    Message = $"{ex.Message}",
                    MessageType = GenericMessage.error
                }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var data = _context.TinTucs.Where(x => x.Id == id).FirstOrDefault();
                _context.TinTucs.Remove(data);
                _context.SaveChanges();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}