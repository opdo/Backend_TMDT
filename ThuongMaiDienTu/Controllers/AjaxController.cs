﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuongMaiDienTu.Models;

namespace ThuongMaiDienTu.Controllers
{
    public class AjaxController : Controller
    {
        public JsonResult GetProductInfo(int id)
        {
            if (Session["login"] is null) return null;
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var infoDB = db.INFOes.Where(x => x.IdInfo == id).FirstOrDefault();
                if (infoDB is null) return null;
                return new JsonResult()
                {
                    Data = new { Name = infoDB.InfoName, Category = infoDB.InfoCategory },
                    JsonRequestBehavior = JsonRequestBehavior.DenyGet
                };
            }
        }
        [HttpPost]
        public string EditProductInfo(InfoModel info)
        {
            if (Session["login"] is null) return "";

            if (String.IsNullOrEmpty(info.InfoName) || String.IsNullOrEmpty(info.InfoCategory))
            {
                return "Vui lòng nhập đầy đủ thông tin";
            }

            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {

                INFO i = new INFO();
                if (info.IdInfo > 0) i = db.INFOes.Where(x => x.IdInfo == info.IdInfo).FirstOrDefault();
                if (i is null) return "Dữ liệu bất thường vui lòng thử lại sau";
                i.InfoName = info.InfoName;
                i.InfoCategory = info.InfoCategory.ToUpper();
                if (info.IdInfo == 0) db.INFOes.Add(i);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }
        [HttpDelete]
        public string DeleteProductInfo(int id)
        {
            if (Session["login"] is null) return null;
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var info = db.INFOes.Where(x => x.IdInfo == id).FirstOrDefault();
                if (info is null) return "Không tìm thấy đối tượng này";
                db.INFOes.Remove(info);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }

        [HttpDelete]
        public string DeleteProduct(int id)
        {
            if (Session["login"] is null) return null;
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var product = db.PRODUCTs.Where(x => x.IdProduct == id).FirstOrDefault();
                if (product is null) return "Không tìm thấy đối tượng này";
                db.PRODUCTs.Remove(product);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }

        [HttpDelete]
        public string DeleteNews(int id)
        {
            if (Session["login"] is null) return null;
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var news = db.NEWS.Where(x => x.IdNews == id).FirstOrDefault();
                if (news is null) return "Không tìm thấy đối tượng này";
                db.NEWS.Remove(news);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }


        [HttpDelete]
        public string DeleteComment(int id)
        {
            if (Session["login"] is null) return null;
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var comment = db.COMMENT_PRODUCT.Where(x => x.IdComment == id).FirstOrDefault();
                if (comment is null) return "Không tìm thấy đối tượng này";
                db.COMMENT_PRODUCT.Remove(comment);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }

        [HttpPost]
        public string AccpetComment(int id)
        {
            if (Session["login"] is null) return null;
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var comment = db.COMMENT_PRODUCT.Where(x => x.IdComment == id).FirstOrDefault();
                if (comment is null) return "Không tìm thấy đối tượng này";
                comment.CommentStatus = true;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }

        [HttpPost]
        public string AccpetReview(int id)
        {
            if (Session["login"] is null) return null;
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var review = db.REVIEW_PRODUCT.Where(x => x.IdReview == id).FirstOrDefault();
                if (review is null) return "Không tìm thấy đối tượng này";
                review.ReviewStatus = true;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }

        [HttpPost]
        public string AccpetOrder(int id)
        {
            if (Session["login"] is null) return null;
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var order = db.ORDERs.Where(x => x.IdOrder == id).FirstOrDefault();
                if (order is null) return "Không tìm thấy đối tượng này";
                try
                {
                    if (order.IdStatus != 3) throw new Exception("Chỉ có đơn hàng đang giao mới được duyệt");
                    order.IdStatus = 4;

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }
        [HttpPost]
        public string DenyOrder(int id)
        {
            if (Session["login"] is null) return null;
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var order = db.ORDERs.Where(x => x.IdOrder == id).FirstOrDefault();
                if (order is null) return "Không tìm thấy đối tượng này";
                try
                {
                    if (order.IdStatus == 4) throw new Exception("Đơn hàng này đã hoàn thành, không từ chối được");
                    order.IdStatus = 5;

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }

        [HttpPost]
        public string DeliveryOrder(int id)
        {
            if (Session["login"] is null) return null;
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var order = db.ORDERs.Where(x => x.IdOrder == id).FirstOrDefault();
                if (order is null) return "Không tìm thấy đối tượng này";
                try
                {
                    if (order.IdStatus == 1 && order.IdStatus != 2) throw new Exception("Đơn hàng này đã không giao được");
                    if (order.PRODUCT_ORDER.Any(x => String.IsNullOrEmpty(x.IMEI))) throw new Exception("Vui lòng nhập đủ IMEI để giao hàng");
                    order.IdStatus = 3;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }


        [HttpDelete]
        public string DeleteReview(int id)
        {
            if (Session["login"] is null) return null;
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var review = db.REVIEW_PRODUCT.Where(x => x.IdReview == id).FirstOrDefault();
                if (review is null) return "Không tìm thấy đối tượng này";
                db.REVIEW_PRODUCT.Remove(review);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }


        [HttpDelete]
        public string DeleteCustomer(int id)
        {
            if (Session["login"] is null) return null;
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var customer = db.CUSTOMERs.Where(x => x.IdCustomer == id).FirstOrDefault();
                if (customer is null) return "Không tìm thấy đối tượng này";
                db.CUSTOMERs.Remove(customer);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }

        public JsonResult GetCategoryNews(int id)
        {
            if (Session["login"] is null) return null;
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var categoryDB = db.CATEGORY_NEWS.Where(x => x.IdCategory == id).FirstOrDefault();
                if (categoryDB is null) return null;
                return new JsonResult()
                {
                    Data = new { Name = categoryDB.CategoryName, Icon = categoryDB.CategoryIcon },
                    JsonRequestBehavior = JsonRequestBehavior.DenyGet
                };
            }
        }
        [HttpPost]
        public string EditCategoryNews(CategoryModel category)
        {
            if (Session["login"] is null) return "";

            if (String.IsNullOrEmpty(category.CategoryName) || String.IsNullOrEmpty(category.CategoryIcon))
            {
                return "Vui lòng nhập đầy đủ thông tin";
            }

            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {

                CATEGORY_NEWS c = new CATEGORY_NEWS();
                if (category.IdCategory > 0) c = db.CATEGORY_NEWS.Where(x => x.IdCategory == category.IdCategory).FirstOrDefault();
                if (c is null) return "Dữ liệu bất thường vui lòng thử lại sau";
                c.CategoryName = category.CategoryName;
                c.CategoryIcon = category.CategoryIcon;
                c.IdUser = ((USER)Session["login"]).IdUser;
                if (category.IdCategory == 0) db.CATEGORY_NEWS.Add(c);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }
        [HttpDelete]
        public string DeleteCategoryNews(int id)
        {
            if (Session["login"] is null) return null;
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var category = db.CATEGORY_NEWS.Where(x => x.IdCategory == id).FirstOrDefault();
                if (category is null) return "Không tìm thấy đối tượng này";
                db.CATEGORY_NEWS.Remove(category);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }


        public JsonResult GetCategory(int id)
        {
            if (Session["login"] is null) return null;
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var categoryDB = db.CATEGORY_PRODUCT.Where(x => x.IdCategory == id).FirstOrDefault();
                if (categoryDB is null) return null;
                return new JsonResult()
                {
                    Data = new { Name = categoryDB.CategoryName, Icon = categoryDB.CategoryIcon },
                    JsonRequestBehavior = JsonRequestBehavior.DenyGet
                };
            }
        }
        [HttpPost]
        public string EditCategory(CategoryModel category)
        {
            if (Session["login"] is null) return "";

            if (String.IsNullOrEmpty(category.CategoryName) || String.IsNullOrEmpty(category.CategoryIcon))
            {
                return "Vui lòng nhập đầy đủ thông tin";
            }

            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {

                CATEGORY_PRODUCT c = new CATEGORY_PRODUCT();
                if (category.IdCategory > 0) c = db.CATEGORY_PRODUCT.Where(x => x.IdCategory == category.IdCategory).FirstOrDefault();
                if (c is null) return "Dữ liệu bất thường vui lòng thử lại sau";
                c.CategoryName = category.CategoryName;
                c.CategoryIcon = category.CategoryIcon;
                if (category.IdCategory == 0) db.CATEGORY_PRODUCT.Add(c);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }
        [HttpDelete]
        public string DeleteCategory(int id)
        {
            if (Session["login"] is null) return null;
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var category = db.CATEGORY_PRODUCT.Where(x => x.IdCategory == id).FirstOrDefault();
                if (category is null) return "Không tìm thấy đối tượng này";
                db.CATEGORY_PRODUCT.Remove(category);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }

        [HttpDelete]
        public string DeleteUser(int id)
        {
            if (Session["login"] is null) return null;
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var user = db.USERs.Where(x => x.IdUser == id).FirstOrDefault();
                if (user is null) return "Không tìm thấy đối tượng này";
                db.USERs.Remove(user);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }

        public JsonResult GetUser(int id)
        {
            if (Session["login"] is null) return null;
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var userDB = db.USERs.Where(x => x.IdUser == id).FirstOrDefault();
                if (userDB is null) return null;
                return new JsonResult()
                {
                    Data = new { IdRole = userDB.IdRole, Fullname = userDB.Fullname, Username = userDB.Username },
                    JsonRequestBehavior = JsonRequestBehavior.DenyGet
                };
            }
        }
        [HttpPost]
        public string EditUser(UserModel user)
        {
            if (Session["login"] is null) return "";

            if (String.IsNullOrEmpty(user.Fullname) || String.IsNullOrEmpty(user.Username) || (String.IsNullOrEmpty(user.Password) && user.IdUser == 0))
            {
                return "Vui lòng nhập đầy đủ thông tin";
            }
            
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                if (db.USERs.Any(x => x.Username.Equals(user.Username) && x.IdUser != user.IdUser)) return "Tài khoản này đã tồn tại";
                USER u = new USER();
                if (user.IdUser > 0) u = db.USERs.Where(x => x.IdUser == user.IdUser).FirstOrDefault();
                if (u is null) return "Dữ liệu bất thường vui lòng thử lại sau";
                u.Username = user.Username;
                u.Fullname = user.Fullname;
                u.IdRole = user.IdRole;
                if (!String.IsNullOrEmpty(user.Password)) u.Password = user.Password;
                if (user.IdUser == 0) db.USERs.Add(u);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }
    }
}