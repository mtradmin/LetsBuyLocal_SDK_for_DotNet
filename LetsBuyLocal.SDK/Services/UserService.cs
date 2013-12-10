using System;
using System.Text;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    /// <summary>
    /// Handles CRUD operations for User model through Base Service
    /// </summary>
    public class UserService : BaseService
    {
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">User object.</param>
        /// <returns>A ResponseMessage object of type User</returns>
        public ResponseMessage<User> CreateUser(User user)
        {
            try
            {
                var resp = Post<ResponseMessage<User>>("User", user);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to create new user. " + ex.Message);
            }
        }

        /// <summary>
        /// Gets a user by the specific id
        /// </summary>
        /// <param name="id">A unique ID string for a user</param>
        /// <returns>A ResponseMessage object of type User</returns>
        public ResponseMessage<User> GetUserById(string id)
        {
            try
            {
                var resp = Get<ResponseMessage<User>>("User" + "/" + id);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get user by Id. " + ex.Message);
            }
        }

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <param name="user">The User object to be updated</param>
        /// <returns>A ResponseMessage object of type User</returns>
        public ResponseMessage<User> UpdateUser(User user)
        {
            try
            {
                var resp = Put<ResponseMessage<User>>("User" + "/" + user.Id, user);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to update user. " + ex.Message);
            }
        }

        /// <summary>
        /// Tracks when the last time a store's message was read, 
        /// updating the LastReadStoreAlertsList property for the user
        /// </summary>
        /// <param name="userId">The Id string for the user to be updated</param>
        /// <param name="storeId">The store Id string for the store whose alert has been read</param>
        /// <param name="dateParam">The DateParameter object for the datetime when the alert was read</param>
        /// <returns>A ResponseMessage object of type User</returns>
        public ResponseMessage<User> UserReadStoreAlert(string userId, string storeId, DateParameter dateParam)
        {
            try
            {
                //Updates Date when last read Alert by Store
                var sb = new StringBuilder();
                sb.Append("User");
                sb.Append("/");
                sb.Append("ReadAlert");
                sb.Append("/");
                sb.Append(userId);
                sb.Append("/");
                sb.Append(storeId);
                string path = sb.ToString();

                var resp = Post<ResponseMessage<User>>(path, dateParam);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to update when user last read an alert from this store." + ex.Message);
            }
        }

        /// <summary>
        /// Updates the date when user last viewed a store's deal.
        /// </summary>
        /// <param name="userId">The Id string for the specified User</param>
        /// <param name="storeId">The Id string for the specified Store</param>
        /// <param name="dateParam">The DateParameter object containing the datetime</param>
        /// <returns></returns>
        public ResponseMessage<User> UserViewedDeal(string userId, string storeId, DateParameter dateParam)
        {
            try
            {
                //Updates Date when last viewed Deal by Store
                var sb = new StringBuilder();
                sb.Append("User");
                sb.Append("/");
                sb.Append("ViewedDeal");
                sb.Append("/");
                sb.Append(userId);
                sb.Append("/");
                sb.Append(storeId);
                string path = sb.ToString();

                var resp = Post<ResponseMessage<User>>(path, dateParam);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to update date when user last viewed a deal from this store." + ex.Message);
            }
        }

        public ResponseMessage<bool> AssignDeviceToUser(string userId, string deviceId)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("User");
                sb.Append("/");
                sb.Append("Device");
                sb.Append("/");
                sb.Append(userId);
                sb.Append("/");
                sb.Append(deviceId);
                string path = sb.ToString();

                var resp = Post<ResponseMessage<bool>>(path);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to assign this device to this user." + ex.Message);
            }
        }



    }
}
