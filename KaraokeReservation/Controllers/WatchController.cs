using KaraokeReservation.Models;
using KaraokeReservation.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaraokeReservation.Controllers
{
    public class WatchController : Controller
    {
        ApplicationDbContext db;

        public WatchController()
        {
            db = new ApplicationDbContext();
        }

        public ViewResult All()
        {
            return View(GetWatchViewModel());
        }

        public WatchViewModel GetWatchViewModel()
        {
            WatchViewModel model = new WatchViewModel();
            model.ListOfVideoModels = new List<VideoViewModel>();


            var lst = from a in db.Video
                      select new
                      {
                          a.FileName,
                          a.FileExtension,
                          a.Description,
                          a.Title,
                          a.DateUploaded,
                          a.Id,
                          a.Uploader.UserName
                      };



            foreach (var item in lst)
            {
                VideoViewModel vm = new VideoViewModel()
                {
                    FileName = item.FileName,
                    FileExtension = item.FileExtension,
                    Description = item.Description,
                    Title = item.Title,
                    DateUploaded = item.DateUploaded,
                    Id = item.Id,
                    UploaderId = item.UserName


                };

                model.ListOfVideoModels.Add(vm);
            }

            return model;
        }


        public ActionResult Index(Guid? id)
        {
            //Request.QueryString[]

            var result = db.Video.FirstOrDefault(e => e.Id == id);
            result.ViewCount += 1;
            db.SaveChanges();

            if (result == null)
            {
                return View("All", GetWatchViewModel());
            }

            VideoViewModel vm = new VideoViewModel()
            {
                Id = result.Id,
                FileExtension = result.FileExtension,
                Title = result.Title,
                Description = result.Description
            };





            return View(vm);
        }
    }
}