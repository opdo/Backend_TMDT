using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuongMaiDienTu.Models;

namespace ThuongMaiDienTu.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            return View();
        }

        // danh sách user
        public ActionResult User(int? page)
        {
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var listDB = db.USERs.ToList();
                return View(listDB.ToPagedList(page ?? 1, 10));
            }
        }

        // xem user
        public ActionResult User(int id)
        {
            return View();
        }

        public ActionResult Login()
        {
            if (Session["login"] != null) return RedirectToAction("Index");
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel data)
        {
            if (data is null) return HttpNotFound();
            if (String.IsNullOrEmpty(data.username) || String.IsNullOrEmpty(data.password))
            {
                ViewBag.Error = "Vui lòng nhập tài khoản hoặc mật khẩu";
                return View();
            }

            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                // mã hóa pass nhận vào
                string password = db.proc_CryptData(data.password).FirstOrDefault();
                // lấy info user
                var userDB = db.USERs.Where(x => x.Username.Equals(data.username.ToLower().Trim()) && x.Password.Equals(password)).FirstOrDefault();
                if (userDB is null)
                {
                    ViewBag.Error = "Tài khoản hoặc mật khẩu không chính xác";
                    return View();
                }

                Session["login"] = userDB;
                return RedirectToAction("Index");
            }
           
        }
    }
}