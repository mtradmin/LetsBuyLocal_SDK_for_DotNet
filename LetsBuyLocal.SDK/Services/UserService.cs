﻿using System;
using System.Collections.Generic;
using System.Text;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    /// <summary>
    /// Handles CRUD operations for users.
    /// </summary>
    public class UserService : BaseService
    {
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">User object.</param>
        /// <returns>
        /// A ResponseMessage object of type User
        /// </returns>
        /// <exception cref="System.ApplicationException">Unable to create new user.  + ex.Message</exception>
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
        /// <returns>
        /// A ResponseMessage object of type User
        /// </returns>
        /// <exception cref="System.ApplicationException">Unable to get user by Id.  + ex.Message</exception>
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
        /// <returns>
        /// A ResponseMessage object of type User
        /// </returns>
        /// <exception cref="System.ApplicationException">Unable to update user.  + ex.Message</exception>
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
        /// <returns>
        /// A ResponseMessage object of type User
        /// </returns>
        /// <exception cref="System.ApplicationException">Unable to update when user last read an alert from this store. + ex.Message</exception>
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
        /// <exception cref="System.ApplicationException">Unable to update date when user last viewed a deal from this store. + ex.Message</exception>
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

        /// <summary>
        /// Updates the list of stores that the user is following.
        /// </summary>
        /// <param name="userId">The user identifier string.</param>
        /// <param name="stores">The stores ArrayofValues.</param>
        /// <returns>
        /// A  ResponseMethod containing an IList of Store object.
        /// </returns>
        /// <exception cref="System.ApplicationException">Unable to create list of stores that user is following.  + ex.Message</exception>
        /// <remarks>
        /// The underlying API is a full update.  So you have to send the full list of stores every time.
        /// If you want to remove a store, then you just don’t send the id to the api.
        /// If you want to add a new one, you send the current list along with the new id.
        /// If you want to remove all of them, you send an empty list.
        /// </remarks>
        public ResponseMessage<IList<Store>> CreateListOfStoresUserFollowing(string userId, ArrayOfValues stores)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("User");
                sb.Append("/");
                sb.Append("Stores");
                sb.Append("/");
                sb.Append(userId);
                var path = sb.ToString();

                var resp = Post<ResponseMessage<IList<Store>>>(path, stores);
                return resp;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to create list of stores that user is following. " + ex.Message);
            }
        }

        /// <summary>
        /// Assigns the device to user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Unable to assign this device to this user. + ex.Message</exception>
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
                    throw new ApplicationException("Unable to assign specified device to user. " + ex.Message);
                }
        }



    }
}
