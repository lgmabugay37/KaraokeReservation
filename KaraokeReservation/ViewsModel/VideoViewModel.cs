using KaraokeReservation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KaraokeReservation.ViewsModel
{
    public class VideoViewModel
    {
        public Guid Id { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public DateTime DateUploaded { get; set; }

        [NotMapped]
        public HttpPostedFileBase File { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Artist/Band")]
        public Guid ArtistId { get; set; }

        public string UploaderId { get; set; }

        public int CounterForList { get; set; }
        public int ViewCount { get; set; }
    }
}