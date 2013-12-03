using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    public class DealService : BaseService
    {
        public ResponseMessage<Deal> CreateDeal(Deal deal)
        {
            return Post<ResponseMessage<Deal>>("Deal", deal);
        }
    }
}
