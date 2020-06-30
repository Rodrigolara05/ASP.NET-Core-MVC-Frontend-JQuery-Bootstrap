﻿using Event_Soft_FrontEnd.Models;
using Event_Soft_FrontEnd.Models.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore;
namespace Event_Soft_FrontEnd.Controllers.User
{
    public class UserConnection
    {
        private const string URL = "https://webeventsoft.azurewebsites.net/api/v1/";

        public static bool RegisterPublisher(string username, string firstname, string lastname, string email, string password)
        {
            const string endpoint = "auth/publishers";
            var client = new RestClient(URL);
            var request = new RestRequest(endpoint, Method.POST);

            string jsonToSend = SerializeUser.ToJson(new UserModel
            {
                Username = username,
                Password = password,
                Email = email,
                Firstname = firstname,
                Lastname = lastname
            });

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            bool success = false;

            try
            {
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    AuthModel authModel = AuthModel.FromJson(response.Content.ToString());
                    //SaveToken(authModel);
                    //SaveRefreshToken(authModel);
                    success = true;
                }
                else
                {
                    // NOK
                    Console.Write(response.ToString());
                }
            }
            catch (Exception error)
            {
                Console.Write(error.ToString());
            }

            return success;
        }
        public static bool RegisterShopper(string username, string firstname, string lastname, string email, string password)
        {
            const string endpoint = "auth/shoppers";
            var client = new RestClient(URL);
            var request = new RestRequest(endpoint, Method.POST);
            
            string jsonToSend = SerializeUser.ToJson(new UserModel
            {
                Username = username,
                Password = password,
                Email = email,
                Firstname = firstname, 
                Lastname = lastname
            });

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            bool success = false;

            try
            {
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    AuthModel authModel = AuthModel.FromJson(response.Content.ToString());
                    //SaveToken(authModel);
                    //SaveRefreshToken(authModel);
                    success = true;
                }
                else
                {
                    // NOK
                    Console.Write(response.ToString());
                }
            }
            catch (Exception error)
            {
                Console.Write(error.ToString());
            }

            return success;
        }
        public static string Login(string username = "", string password = "")
        {
            const string endpoint = "auth/login";
            var client = new RestClient(URL);
            var request = new RestRequest(endpoint, Method.POST);
            
            string jsonToSend = SerializeUser.ToJson(new UserModel
            {
                Username = username,
                Password = password
            });

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            string result = "";

            try
            {
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    //                    string variable = session.GetString("Token");

                    result = response.Content.ToString();
                }
                else
                {
                    // NOK
                    Console.Write(response.ToString());
                }
            }
            catch (Exception error)
            {
                Console.Write(error.ToString());
            }

            return result;
        }

    }
}
