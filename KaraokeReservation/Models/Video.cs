using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KaraokeReservation.Models
{
   
    public class Video
    {
        public Guid Id { get; set; }
        public Artist Artist { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public byte[] Content { get; set; }

        public byte[] ThumbnailContent { get; set; }

        public DateTime DateUploaded { get; set; }

        public ApplicationUser Uploader { get; set; }

        public int ViewCount { get; set; }

    }
}