using System.Text;
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
            var newUser = Post<ResponseMessage<User>>("User", user);
            return newUser;
        }

        /// <summary>
        /// Gets a user by the specific id
        /// </summary>
        /// <param name="id">A unique ID string for a user</param>
        /// <returns>A ResponseMessage object of type User</returns>
        public ResponseMessage<User> GetUserById(string id)
        {
            var user = Get<ResponseMessage<User>>("User" + "/" + id);
            return user;
        }

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <param name="user">The User object to be updated</param>
        /// <returns>A ResponseMessage object of type User</returns>
        public ResponseMessage<User> UpdateUser(User user)
        {
            var updatedUser = Put<ResponseMessage<User>>("User" + "/" + user.Id, user);
            return updatedUser;
        }

        /// <summary>
        /// Tracks when the last time a message was read, 
        /// updating the LastReadStoreAlertsList property for the user
        /// </summary>
        /// <param name="user">The User object to be updated</param>
        /// <returns>A ResponseMessage object of type User</returns>
        public ResponseMessage<User> SetWhenMessageReadByUser(User user)
        {
            //Updates Date of last read alert by Store [StoreId|DateTime] (LastReadStoreAlertsList property)
            var sb = new StringBuilder();
            sb.Append("User");
            sb.Append("/");
            sb.Append("ReadAlert");
            sb.Append("/");
            sb.Append(user.Id);
            string path = sb.ToString();
            var updatedUser = Post<ResponseMessage<User>>(path + user.Id, user);
            return updatedUser;
        }


        //Todo: Post /v1/User/ViewedDeal/{id}
        //Todo: Post /v1/User/Device/{id}


    }
}
