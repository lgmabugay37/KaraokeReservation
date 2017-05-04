using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaraokeReservation.ViewsModel
{
    public class WatchViewModel
    {
        public List<VideoViewModel> ListOfVideoModels { get; set; }
        public List<SuggestedVideoViewModel> ListOfSuggestedVideos { get; set; }
    }
}