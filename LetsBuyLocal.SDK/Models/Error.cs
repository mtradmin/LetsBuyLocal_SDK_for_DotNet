namespace LetsBuyLocal.SDK.Models
{
    public class Error : BaseEntity
    {
        public string UserId { get; set; }
        public string StoreId { get; set; }
        public string Screen { get; set; }
        public string Api { get; set; }
        public string Data { get; set; }
        public string Description { get; set; }
    }
}
