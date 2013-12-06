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
