namespace LetsBuyLocal.SDK.Models
{
    public class Video : BaseEntity
    {
        public string ThumbnailUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int SortOrder { get; set; }
    }
}
