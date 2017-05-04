using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaraokeReservation.ViewsModel
{
    public class SuggestedVideoViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Uploader { get; set; }
    }
}