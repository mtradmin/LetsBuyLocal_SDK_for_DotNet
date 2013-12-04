using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    public class UserService : BaseService
    {
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">User object.</param>
        /// <returns>A ResponseMessage object of type User</returns>
        public ResponseMessage<User> CreateUser(User user)
        {
            return Post<ResponseMessage<User>>("User", user);
        }

        //public ResponseMessage<IList<Video>> GetVideos()
        //{
        //    var videos = Get<ResponseMessage<IList<Video>>>("Training");
        //    return videos;
        //}

        public ResponseMessage<User> GetUserById(string id)
        {
            var user = Get<ResponseMessage<User>>("User" + "/" + id);
            return user;
        }

    }
}
