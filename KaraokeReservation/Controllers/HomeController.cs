using KaraokeReservation.Models;
using KaraokeReservation.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaraokeReservation.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            WatchViewModel model = new WatchViewModel();
            model.ListOfVideoModels = new List<VideoViewModel>();


            var lst = from a in _context.Video
                      select new
                      {
                          a.FileName,
                          a.FileExtension,
                          a.Description,
                          a.Title,
                          a.DateUploaded,
                          a.Id,
                          a.Uploader.UserName,
                          a.ViewCount
                      };


            int counter = 0;
            foreach (var item in lst)
            {
                counter++;
                VideoViewModel vm = new VideoViewModel()
                {
                    FileName = item.FileName,
                    FileExtension = item.FileExtension,
                    Description = item.Description,
                    Title = item.Title,
                    DateUploaded = item.DateUploaded,
                    Id = item.Id,
                    UploaderId = item.UserName,
                    ViewCount = item.ViewCount
                };

                vm.CounterForList = counter;
                model.ListOfVideoModels.Add(vm);
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}