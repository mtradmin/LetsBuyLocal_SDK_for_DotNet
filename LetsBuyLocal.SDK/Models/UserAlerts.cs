using System.Collections.Generic;

namespace LetsBuyLocal.SDK.Models
{
    public class UserAlerts : BaseEntity
    {
        //Id is UserId
        public List<string> DeletedAlertIds { get; set; } //List of Alert Ids that have been deleted
    }
}
