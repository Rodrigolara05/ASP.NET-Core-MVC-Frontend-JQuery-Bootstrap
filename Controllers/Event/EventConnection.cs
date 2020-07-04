using Event_Soft_FrontEnd.Models;
using Event_Soft_FrontEnd.Models.Authorization;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Event_Soft_FrontEnd.Controllers.Event
{
    public class EventConnection
    {
        private const string URL = "https://webeventsoft.azurewebsites.net/api/v1/";
        
        public static EventModel[] GetEvents()
        {
            const string endpoint = "events/";
            var client = new RestClient(URL);
            var request = new RestRequest(endpoint, Method.GET);

            EventModel[] result = null;

            try
            {
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = ListEventModel.FromJson(response.Content);
                   
                    // success = true;
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
        public static EventModel InformationEvent(string id)
        {
            string endpoint =  string.Format("events/{0}", id);
            var client = new RestClient(URL);
            var request = new RestRequest(endpoint, Method.GET);

            EventModel result = null;

            try
            {
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = EventModel.FromJson(response.Content);

                    // success = true;
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
        public static bool CreateEvent(string name, string image, CategoryModel[] categories, string start, string end,string address,string referenceLocation ,  Zone[] zona)
        {
            const string endpoint = "events/";
            var client = new RestClient(URL);
            var request = new RestRequest(endpoint, Method.POST);

            string jsonToSend = SerializeEvent.ToJson(new EventModel
            {

                Name = name,
                Image = image,
                Categories =
                {
                    
                },
                Start = start,
                End = end,
                Address = address,
                ReferenceLocation = referenceLocation,
                Zones =
                {
                    
                },

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

    }
}
