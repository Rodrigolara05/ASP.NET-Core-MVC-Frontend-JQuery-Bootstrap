using Event_Soft_FrontEnd.Models;
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
    
    }
}
