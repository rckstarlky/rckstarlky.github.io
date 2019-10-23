using Service.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Service.Controllers
{
    public class ProviderController : Controller
    {
        //
        // GET: /Provider/
        Entities db = new Entities();
        public ActionResult Index()
        {
            ViewBag.Categeries = new SelectList(db.Categeries, "id", "Category");
            return View();
        }
        [HttpPost]
        public ActionResult SaveProfile(Provider provider)
        {
            byte[] imageBytes = null;
            var fileName = "";
            var path = "";

            if (!ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var file1 = Request.Files[0];
                    if (file1 != null && file1.ContentLength > 0)
                    {
                         fileName = Path.GetFileName(provider.UserNAme+file1.FileName);
                         path = Server.MapPath("~") + @"\Images\" + fileName;
                         //path = Directory.GetFiles(Path.Combine(Server.MapPath("~/Images/"), fileName)).ToString();
                        // path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                        file1.SaveAs(path);

                        BinaryReader reader = new BinaryReader(file1.InputStream);
                        imageBytes = reader.ReadBytes((int)file1.ContentLength);
                        if (path.Contains(@"A:\NewService\Service\Service\"))
                        {
                            path="~/Images/" +fileName;
                        }
                    }
                }

                var userid = System.Web.HttpContext.Current.Session["UserID"].ToString();
                ProviderInfo providerinfo = new ProviderInfo();
                
        
                providerinfo.Photo = path;
                providerinfo.UserName = provider.UserNAme;
                providerinfo.AlternateText = "Profile Picture";
                providerinfo.Zipcode = provider.zipcode;
                providerinfo.city = provider.city;
                providerinfo.State = provider.state;
                providerinfo.Country = provider.country;
                providerinfo.AboutMe = provider.aboutme;
                providerinfo.MobileNumber = provider.mobilenumber;
                providerinfo.AlternateNumber = provider.alternatenumber;
                providerinfo.AdharNumber = provider.adharnumber;
                providerinfo.Photid = imageBytes;
                if (!string.IsNullOrEmpty(userid))
                {
                    Guid providerid = new Guid(userid);
                    providerinfo.ProviderId = providerid;
                }
                providerinfo.IsProfileCompleted = true;
                db.ProviderInfoes.Add(providerinfo);
                db.SaveChanges();
            }
            return RedirectToAction("ProviderProfile", "Provider");
        }
        public ActionResult ProviderProfile(string userid)
        {
            var path = "";
           // dynamic userid = null;
            displayprofile dsp = new displayprofile();
            //if (string.IsNullOrEmpty(userid))
            //{
            //    userid = System.Web.HttpContext.Current.Session["UserIDAl"].ToString();
            //}
            //else
            //{
            //}
            userid = System.Web.HttpContext.Current.Session["UserID"].ToString();

            if (!string.IsNullOrEmpty(userid))
            {
                var userdata = db.ProviderInfoes.Where(p => p.ProviderId == new Guid(userid) && p.Photid!=null).FirstOrDefault();
                {
                    
                    var arrayBinary = userdata.Photid.ToArray();
                    Image rImage = null;
                   // sbyte pid = Convert.ToSByte(userdata.Photid);
                    //dsp.imagedata = pid;
                    using (MemoryStream ms = new MemoryStream(arrayBinary))
                    {
                        rImage = Image.FromStream(ms);
                        string filename = userid;
                       // path = Path.Combine(Server.MapPath("~/Images/"));
                        path = Server.MapPath("~") + @"\Images\" + filename;
                        rImage.Save(path + ImageFormat.Jpeg);
                    }
                    dsp.description = userdata.AboutMe;
                    //ViewBag.profileimage = path;
                    dsp.name = userdata.UserName;
                    dsp.photo = userdata.Photo;
                    dsp.id = userdata.ProviderId.ToString();
                }
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
            return View(dsp);
        }
        public ActionResult Provider(string id)
        {

            var userdata = db.ProviderInfoes.Where(p => p.ProviderId == new Guid(id)).FirstOrDefault();
            if(userdata!=null)
            {
                Provider provider = new Provider();

                provider.zipcode = Convert.ToInt32(userdata.Zipcode);
                provider.city = userdata.city;
                provider.state = userdata.State;
                provider.category = userdata.Category;
                ViewBag.Categeries = new SelectList(db.Categeries, "id", "Category");
                provider.country = userdata.Country;
                provider.aboutme = userdata.AboutMe;
                provider.alternatenumber = Convert.ToInt32(userdata.AlternateNumber);
                provider.adharnumber = Convert.ToInt32(userdata.AdharNumber);
                provider.mobilenumber = Convert.ToInt32(userdata.MobileNumber);
                provider.UserNAme = userdata.UserName;
                provider.photo = userdata.Photo;
                provider.providerid = userdata.ProviderId.ToString();

                return View(provider);
            }
            //ViewBag.Categeries = new SelectList(db.Categeries, "id", "Category");
            return Content("Error Occurred in processing the request");
        }

        public ActionResult Editprovider(Provider provider2, string providerid)
        {

            if (!string.IsNullOrEmpty(providerid))
            {
            var userdata = db.ProviderInfoes.Where(p => p.ProviderId == new Guid(providerid)).FirstOrDefault();
           // ProviderInfo provider1 = new ProviderInfo();
            userdata.Zipcode = Convert.ToInt32(provider2.zipcode);
            userdata.city = provider2.city;
            userdata.State = provider2.state;
            userdata.Category = provider2.category;
            ViewBag.Categeries = new SelectList(db.Categeries, "id", "Category");
            userdata.Country = provider2.country;
            userdata.AboutMe = provider2.aboutme;
            userdata.AlternateNumber = Convert.ToInt32(provider2.alternatenumber);
            userdata.AdharNumber = Convert.ToInt32(provider2.adharnumber);
            userdata.MobileNumber = Convert.ToInt32(provider2.mobilenumber);
            userdata.UserName = provider2.UserNAme;
            userdata.Photo = provider2.photo;
            db.Entry(userdata).State = System.Data.Entity.EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (Exception  ex)
            {

               

                throw ex;
            }
          
            }
            else
            {
                return Content("Error Ocurred during processing your request please try again.");
            }
           // provider1.providerid = provider2.ProviderId.ToString();

            return RedirectToAction("ProviderProfile", "Provider");
        }
    }
}