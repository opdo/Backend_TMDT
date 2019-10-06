﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuongMaiDienTu.Helper;
using ThuongMaiDienTu.Models;

namespace ThuongMaiDienTu.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            return RedirectToAction("User");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        // danh sách user
        public ActionResult User()
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            return View();
        }

        // Comment
        public ActionResult Comment()
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            return View();
        }

        // Review
        public ActionResult Review()
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            return View();
        }

        // sản phẩm
        public ActionResult Product()
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            return View();
        }

        // khách hàng
        public ActionResult Customer()
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            return View();
        }

        // bài viết
        public ActionResult News()
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            return View();
        }

        public ActionResult OrderInfo(int id)
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            ORDER order = new ORDER();
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                order = db.ORDERs.Where(x => x.IdOrder == id).FirstOrDefault();
                if (order is null) return HttpNotFound();
            }
            return View(order);
        }

        public ActionResult Promotion()
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            return View();
        }

        public ActionResult PromotionInfo(int? id)
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            PROMOTION promotion = new PROMOTION();
            if (id != null)
            {
                using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
                {
                    promotion = db.PROMOTIONs.Where(x => x.IdPromotion == id).FirstOrDefault();
                    if (promotion is null) return HttpNotFound();
                }
            }
            return View(promotion);
        }

        [HttpPost]
        public ActionResult PromotionInfo(PROMOTION data)
        {
            //try
            //{
            //    if (String.IsNullOrEmpty(data.PromotionName)) throw new Exception("Tên chương trình khuyến mãi không được bỏ trống");
            //    if (data.PromotionEnd is null || data.PromotionStart is null) throw new Exception("Thời gian khuyến mãi không được bỏ trống");
            //    if (data.PromotionEnd.Value < data.PromotionStart.Value) throw new Exception("Thời gian khuyến mãi không hợp lệ");
            //    using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            //    {

            //        if (data.IdPromotion == 0)
            //        {
            //            db.PROMOTIONs.Add(data);
            //        }
            //        else
            //        {
            //            var promotionDB = db.PROMOTIONs.Where(x => x.IdPromotion == data.IdPromotion).FirstOrDefault();
            //            if (productDB is null) throw new Exception("Không tìm thấy sản phẩm này, vui lòng thử lại");
            //            productDB.IdCategory = product.IdCategory;
            //            productDB.ProductName = product.ProductName;
            //            productDB.ProductPrice = product.ProductPrice;
            //            productDB.ProductSumary = product.ProductSumary;
            //            productDB.ProductDetail = product.ProductDetail;
            //            if (imgChanged)
            //            {
            //                if (product.PRODUCT_IMG != null)
            //                    foreach (var item in productDB.PRODUCT_IMG.ToList())
            //                        db.PRODUCT_IMG.Remove(item);
            //                foreach (var item in product.PRODUCT_IMG.ToList())
            //                    productDB.PRODUCT_IMG.Add(item);

            //            }


            //            productDB.PRODUCT_INFO.Clear();
            //            if (product.PRODUCT_INFO != null)
            //                foreach (var item in product.PRODUCT_INFO.ToList())
            //                    productDB.PRODUCT_INFO.Add(item);


            //            product = productDB;

            //        }

            //        db.SaveChanges();
            //    }
            //    ViewBag.Success = "Bài viết được lưu thành công";
            //    ViewBag.Id = product.IdProduct;
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Error = ex.Message;
            //}
            //return View(product);
            return View();
        }


        public ActionResult GiftCode()
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            return View();
        }

        public ActionResult OrderWaiting()
        {
         
            if (Session["login"] is null) return RedirectToAction("Login");
            ViewBag.Id1 = 1;
            ViewBag.Id2 = 2;
            ViewBag.Title = "Đơn chờ duyệt";
            return View();
        }
        public ActionResult OrderDelivery()
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            ViewBag.Id1 = 3;
            ViewBag.Id2 = 3;
            ViewBag.Title = "Đơn đang giao";
            return View("OrderWaiting");
        }

        public ActionResult OrderDone()
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            ViewBag.Id1 = 4;
            ViewBag.Id2 = 4;
            ViewBag.Title = "Đơn hoàn thành";
            return View("OrderWaiting");
        }
        public ActionResult OrderDeny()
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            ViewBag.Id1 = 5;
            ViewBag.Id2 = 5;
            ViewBag.Title = "Đơn từ chối";
            return View("OrderWaiting");
        }


        public ActionResult ProductEdit(int? id)
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            PRODUCT product = new PRODUCT();
            if (id != null)
            {
                using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
                {
                    product = db.PRODUCTs.Where(x => x.IdProduct == id).FirstOrDefault();
                    if (product is null) return HttpNotFound();
                }
            }
            return View(product);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ProductEdit(PRODUCT product, HttpPostedFileBase[] files)
        {
            try
            {
                if (String.IsNullOrEmpty(product.ProductName)) throw new Exception("Tên sản phẩm không được bỏ trống");
                using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
                {
                    bool imgChanged = false;
                    if (files != null)
                    {
                        int i = 1;
                        foreach (var file in files)
                        {
                            if (file is null) continue;
                            imgChanged = true;
                            if (!file.ContentType.Contains("image")) throw new Exception("File hình không hợp lệ");
                            if (file.ContentLength > 5 * 1024 * 1024) throw new Exception("Hình ảnh vượt quá 5Mb");
                            string mapPath = Server.MapPath("~/img/product");
                            string filename = product.ProductName.ToLower().Trim().Replace("  ", " ").Replace(" ", "-");
                            filename = RemoveVietnamese.RemoveSign4VietnameseString(filename) + "-" + i + ".png";
                            string filePath = mapPath + "/" + filename;
                            if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
                            file.SaveAs(filePath);

                            PRODUCT_IMG img = new PRODUCT_IMG();
                            img.Filename = filename;
                            img.ImgAlt = RemoveVietnamese.RemoveSign4VietnameseString(product.ProductName);
                            product.PRODUCT_IMG.Add(img);

                            i++;
                        }
                    }

                    if (product.IdProduct == 0)
                    {
                        product.IdUser = ((USER)Session["login"]).IdUser;
                        db.PRODUCTs.Add(product);
                    }
                    else
                    {
                        var productDB = db.PRODUCTs.Where(x => x.IdProduct == product.IdProduct).FirstOrDefault();
                        if (productDB is null) throw new Exception("Không tìm thấy sản phẩm này, vui lòng thử lại");
                        productDB.IdCategory = product.IdCategory;
                        productDB.ProductName = product.ProductName;
                        productDB.ProductPrice = product.ProductPrice;
                        productDB.ProductSumary = product.ProductSumary;
                        productDB.ProductDetail = product.ProductDetail;
                        if (imgChanged)
                        {
                            if (product.PRODUCT_IMG != null)
                                foreach (var item in productDB.PRODUCT_IMG.ToList())
                                    db.PRODUCT_IMG.Remove(item);
                                foreach (var item in product.PRODUCT_IMG.ToList())
                                    productDB.PRODUCT_IMG.Add(item);
                            
                        }


                        productDB.PRODUCT_INFO.Clear();
                        if (product.PRODUCT_INFO != null)
                            foreach (var item in product.PRODUCT_INFO.ToList())
                             productDB.PRODUCT_INFO.Add(item);


                        product = productDB;

                    }

                    db.SaveChanges();
                }
                ViewBag.Success = "Bài viết được lưu thành công";
                ViewBag.Id = product.IdProduct;
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(product);
        }

        public ActionResult NewsInfo(int? id)
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            NEWS news = new NEWS();
            if (id != null)
            {
                using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
                {
                    news = db.NEWS.Where(x => x.IdNews == id).FirstOrDefault();
                    if (news is null) return HttpNotFound();
                }
            }
            return View(news);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewsInfo(NEWS news, HttpPostedFileBase file)
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            try
            {
                if (String.IsNullOrEmpty(news.NewsTitle)) throw new Exception("Tên bài viết không được bỏ trống");
                using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
                {

                    if (file != null)
                    {
                        if (!file.ContentType.Contains("image")) throw new Exception("File hình không hợp lệ");
                        if (file.ContentLength > 5 * 1024 * 1024) throw new Exception("Hình ảnh vượt quá 5Mb");
                        string mapPath = Server.MapPath("~/img/news");
                        string filename = news.NewsTitle.ToLower().Trim().Replace("  ", " ").Replace(" ", "-");
                        filename = RemoveVietnamese.RemoveSign4VietnameseString(filename) + ".png";
                        string filePath = mapPath + "/" + filename;
                        if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
                        file.SaveAs(filePath);
                        news.NewsThumbail = filename;
                    }

                    if (news.IdNews == 0)
                    {
                        news.IdUser = ((USER)Session["login"]).IdUser;
                        news.DateCreate = DateTime.Now;
                        db.NEWS.Add(news);
                    }
                    else
                    {
                        var newsDB = db.NEWS.Where(x => x.IdNews == news.IdNews).FirstOrDefault();
                        if (newsDB is null) throw new Exception("Không tìm thấy bài viết này, vui lòng thử lại");
                        newsDB.IdCategory = news.IdCategory;
                        newsDB.NewsDetail = news.NewsDetail;
                        newsDB.NewsThumbail = news.NewsThumbail;
                        newsDB.NewsSumary = news.NewsSumary;
                        newsDB.NewsTitle = news.NewsTitle;
                        news = newsDB;
                    }
                    db.SaveChanges();
                }
                ViewBag.Success = "Bài viết được lưu thành công";
                ViewBag.Id = news.IdNews;
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(news);
        }

        public ActionResult Login()
        {
            if (Session["login"] != null) return RedirectToAction("Index");
            return View();
        }

        public ActionResult CategoryProduct()
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            return View();
        }

        public ActionResult CategoryNews()
        {
            if (Session["login"] is null) return RedirectToAction("Login");
            return View();
        }

        public ActionResult ProductInfo()
        {
            if (Session["login"] is null) return RedirectToAction("Login");
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