using KaraokeReservation.ViewsModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KaraokeReservation.Models;
using Microsoft.AspNet.Identity;

using Microsoft.AspNet.Identity.EntityFramework;

namespace KaraokeReservation.Controllers
{
    //[Authorize]
    public class UploadController : Controller
    {
        private ApplicationDbContext db;
        UserManager<ApplicationUser> UserManager { get; set; }

        public UploadController()
        {
            db = new ApplicationDbContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.db));
        }


        // GET: Upload
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public void SaveThumbnail(string filePath, Guid id)
        {
            string folderPath = Server.MapPath("~/FileUpload/Thumbnails/");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
            ffMpeg.GetVideoThumbnail(filePath, folderPath + id.ToString() + ".jpg");
        }

        public ActionResult Index(VideoViewModel vm)
        {
            if (vm.File != null)
            {
                var user = UserManager.FindById(User.Identity.GetUserId());
                var id = Guid.NewGuid();
                var file = vm.File;
                var fileExtension = Path.GetExtension(vm.File.FileName);

                string path = Server.MapPath("~/FileUpload/");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                path += id + fileExtension;
                file.SaveAs(path);

                SaveThumbnail(path, id);

                fileExtension = fileExtension.Replace(".", "");





                byte[] buffer;

                using (MemoryStream ms = new MemoryStream())
                {
                    //open converted video file, read it and write it to buffer
                    using (FileStream tempfile = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        buffer = new byte[tempfile.Length];
                        tempfile.Read(buffer, 0, (int)tempfile.Length);
                        ms.Write(buffer, 0, (int)tempfile.Length);
                    }
                }



                var artist = db.Artist.FirstOrDefault(e => e.Id == vm.ArtistId);
                // Store video in database
                var video = new Video()
                {
                    FileName = vm.File.FileName,
                    FileExtension = fileExtension,
                    Content = buffer,
                    DateUploaded = DateTime.Now,
                    Uploader = user,
                    Title = vm.Title,
                    Description = vm.Description,
                    Id = id,
                    Artist = artist == null ? null : artist
                };
                db.Video.Add(video);
                db.SaveChanges();

            }

            return View();
        }

        [HttpGet]
        public ActionResult GetArtists(string term)
        {
            var artists = new List<string>();

            //artists = db.Artist.Where(e => e.Description.StartsWith(term)).Select(x => (x.Description)).ToList();
            var a = db.Artist.Where(e => e.Description.StartsWith(term))
                .Select(x => new ArtistViewModel()
                {
                    Description = x.Description,
                    Id = x.Id
                })
                .ToList();

            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}