using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KaraokeReservation.Models
{
    public class Artist
    {
        public Guid Id { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string UploaderId { get; set; }

    }
}