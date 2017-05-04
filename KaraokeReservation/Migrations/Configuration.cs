namespace KaraokeReservation.Migrations
{
    using Microsoft.AspNet.Identity;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    internal sealed class Configuration : DbMigrationsConfiguration<KaraokeReservation.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KaraokeReservation.Models.ApplicationDbContext context)
        {
           
        }
    }
}
