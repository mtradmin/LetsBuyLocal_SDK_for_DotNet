namespace LetsBuyLocal.SDK.Models
{
    public class RewardsCard : BaseEntity
    {
        public override string Id { get; set; }

        public string UserId { get; set; }
        public string StoreId { get; set; }
        public string MoreThanRewardsUserId { get; set; }
        public string RewardsCardNumber { get; set; }
    }
}
