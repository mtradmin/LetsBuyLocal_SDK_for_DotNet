using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsBuyLocal.SDK.Models
{
    public class UserAlerts : BaseEntity
    {
        //Id is UserId
        public List<string> DeletedAlertIds { get; set; } //List of Alert Ids that have been deleted
    }
}
