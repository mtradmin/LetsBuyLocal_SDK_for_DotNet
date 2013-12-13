using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Provides an object that can store a location as latitude & longitude
    /// </summary>
    public class GeoPoint
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
