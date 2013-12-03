using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    public class ErrorService : BaseService
    {

        public ResponseMessage<bool> CreateError(Error error)
        {
            return Post<ResponseMessage<bool>>("Error", error);
        }
    }
}
