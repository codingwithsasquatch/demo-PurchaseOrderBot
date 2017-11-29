using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoFlowers.Models
{
    public class Vendor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Url { get; set; }

        public static List<Vendor> GetVendors()
        {
            List<Vendor> vendors = new List<Vendor>();

            var v1 = new Vendor()
            {
               Id = 1,
               Name = "United",
               Title = "",
               Subtitle = "5 POs open",
               Url = "https://www.airport-houston.com/images/airlines17/united-airlines.png"
            };
            

            var v2 = new Vendor()
            {
                Id = 2,
                Name = "Delta",
                Title = "",
                Subtitle = "3 POs open",
                Url = "https://i.forbesimg.com/media/lists/companies/delta-air-lines_416x416.jpg"
            };

            var v3 = new Vendor()
            {
                Id = 3,
                Name = "Infosys",
                Title = "",
                Subtitle = "2 POs open",
                Url = "http://indiacsr.in/wp-content/uploads/2016/03/Infosys-Foundation.png"
            };

            var v4 = new Vendor()
            {
                Id = 4,
                Name = "IBM",
                Title = "",
                Subtitle = "4 POs open",
                Url = "https://www.frontiercomputercorp.com/wp-content/uploads/2015/01/IBM-logo.jpg"
            };

            var v5 = new Vendor()
            {
                Id = 5,
                Name = "SAP",
                Title = "",
                Subtitle = "10 POs open",
                Url = "https://pbs.twimg.com/profile_images/883004037385175040/KCQKBM9_.jpg"
            };

            vendors.Add(v1);
            vendors.Add(v2);
            vendors.Add(v3);
            vendors.Add(v4);
            vendors.Add(v5);

            return vendors;
        }
    }
}