namespace LetsBuyLocal.SDK.Models
{
    public class FBSettings
    {
        //Facebook Id
        //Might be 9-digit string
        public string Account { get; set; }
        public string Page { get; set; }
        //Might be alphanumeric with length = 195
        public string PageAccessToken { get; set; }
        public bool PublishAlerts { get; set; }
        public bool PublishDeals { get; set; }
    }
}
