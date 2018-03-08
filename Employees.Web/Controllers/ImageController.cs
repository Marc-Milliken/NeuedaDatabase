using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employees.Entities.Images;
using Employees.Data;
using System.Net;

namespace Employees.Web.Controllers
{
    public class ImageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Image
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(Image uploadimage)
        {
            HttpPostedFileBase file = Request.Files["ImageUpload"];

            uploadimage.ImageID = Guid.NewGuid();

            if (file != null && file.FileName != null && file.FileName != "")
            {
                FileInfo fi = new FileInfo(file.FileName);
                if (fi.Extension != ".JPG")
                {
                    TempData["Errormsg"] = "Image File Extension is Not valid";
                    return View(uploadimage);
                }
                else
                {
                    string image1 = "image1";
                    uploadimage.UploadImage = uploadimage.ImageID + fi.Extension;

                    file.SaveAs(Server.MapPath("~/Uploads/" + uploadimage.ImageID + fi.Extension));

                    db.Images.Add(uploadimage);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Employee");
                }
            }

            return View(uploadimage);
        }

        public ActionResult Gallery()
        {
            var image = db.Images.ToList();
            return View(image);

        }

        // GET: Image/Display/
        public ActionResult Display(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);

        }


    }
}