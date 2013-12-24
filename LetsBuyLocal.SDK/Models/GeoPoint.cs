namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents an object that can store a location as latitude and longitude
    /// </summary>
    public class GeoPoint
    {
        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public decimal Latitude { get; set; }
        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public decimal Longitude { get; set; }
    }
}
