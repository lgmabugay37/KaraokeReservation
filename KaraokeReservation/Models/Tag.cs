using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KaraokeReservation.Models
{
    public class Tag
    {
        public string Id { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
    }
}