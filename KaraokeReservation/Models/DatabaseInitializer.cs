using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;

namespace KaraokeReservation.Models
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            string userName = SeedUser(context);
            var seededUser = context.Users.SingleOrDefault(e => e.UserName == userName);
            if (seededUser != null)
            {
                SeedArtists(seededUser.Id, context);
                SeedVideo(seededUser, context);
            }

            base.Seed(context);
        }

        private string SeedUser(ApplicationDbContext context)
        {
            string userName = "admin@lmabugay.com";
            string password = "P@ssw0rd123";
            string phoneNumber = "091111111";

            var passwordHash = new PasswordHasher();
            string pass = passwordHash.HashPassword(password);
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = userName,
                    PasswordHash = pass,
                    PhoneNumber = phoneNumber,
                    Email = userName,
                    SecurityStamp = Guid.NewGuid().ToString() //THIS IS WHAT I NEEDED

                });
            context.SaveChanges();

            return userName;
        }

        private void SeedVideo(ApplicationUser applicationUser, ApplicationDbContext context)
        {
            string folderPath = HttpContext.Current.Server.MapPath("~/FileUpload/Thumbnails/");
            if (!Directory.Exists(folderPath))
            { Directory.CreateDirectory(folderPath); }

            var gloc9Artist = context.Artist.FirstOrDefault(e => e.Description.Equals("Gloc 9"));
            var pneArtist = context.Artist.FirstOrDefault(e => e.Description.Equals("Parokya Ni Edgar"));


            string seedImagePath = HttpContext.Current.Server.MapPath("~/Data/Thumbnails/");

            DirectoryInfo d = new DirectoryInfo(seedImagePath);
            FileInfo[] files = d.GetFiles("*.jpg"); //Getting Text files
            int cntr = 0;
            if (gloc9Artist != null && pneArtist != null)
            {
                foreach (FileInfo file in files)
                {
                    cntr++;

                    Guid id = Guid.NewGuid();
                    var video = new Video()
                    {
                        Artist = (cntr > 25 ? pneArtist : gloc9Artist),
                        Content = null,
                        DateUploaded = DateTime.Now,
                        Description = "This is just loaded data :)",
                        FileExtension = "mp4",
                        FileName = id.ToString(),
                        Id = id,
                        Title = id.ToString(),
                        Uploader = applicationUser
                    };


                    string thumbnailOrigFile = string.Concat(seedImagePath, "\\", file.Name);
                    string thumbnailUpdatedFile = string.Concat(folderPath, "\\Thumbnails\\", id.ToString(), ".jpg");

                    string videoOldFile = string.Concat(seedImagePath.Replace("Thumbnails", "Video"), "\\", "1.mp4");
                    string videoUpdatedFile = string.Concat(folderPath.Replace("Thumbnails\\", ""), "\\", id.ToString(), ".mp4");


                    File.Copy(thumbnailOrigFile, thumbnailUpdatedFile.Replace(@"Thumbnails\", ""));
                    File.Copy(videoOldFile, videoUpdatedFile);
                    context.Video.Add(video);
                }

            }

            context.SaveChanges();
        }

        private void SeedArtists(string id, ApplicationDbContext context)
        {
            string userId = id;
            string path = HttpContext.Current.Server.MapPath("~/Data/data.json");
            string json = File.ReadAllText(path);
            var artistList = JsonConvert.DeserializeObject<List<ArtistJsonDetail>>(json);


            foreach (var artistName in artistList)
            {
                string name = artistName.artistName;
                var artist = new Artist()
                {
                    Id = Guid.NewGuid(),
                    Description = name,
                    DateAdded = DateTime.Now,
                    UploaderId = userId
                };

                context.Artist.AddOrUpdate(e => e.Description, artist);
            }

            context.SaveChanges();
        }

        public class ArtistJsonDetail
        {
            public string artistName { get; set; }
        }
    }
}