using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using KaraokeReservation.Controls;

namespace KaraokeReservation.Controllers.api
{
    public class VideoController : ApiController
    {
        public HttpResponseMessage Get(string filename, string ext)
        {
            var video = new VideoStream(filename, ext);

            var response = Request.CreateResponse();
            response.Content = new PushStreamContent(
                 (Action<Stream, HttpContent, TransportContext>)video.WriteToStream, new MediaTypeHeaderValue("video/" + ext));
            return response;
        }
    }
}
