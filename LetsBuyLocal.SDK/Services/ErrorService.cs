using System;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    public class ErrorService : BaseService
    {

        public ResponseMessage<bool> CreateError(Error error)
        {
            try
            {
                var resp = Post<ResponseMessage<bool>>("Error", error);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to create error message. " + ex.Message);
            }
        }
    }
}
