using System;
using System.Net;
using Event_Soft_FrontEnd.Models;
using RestSharp;

namespace Event_Soft_FrontEnd.Controllers.Category
{
    public class CategoryConnection
    {
        private const string URL = "https://webeventsoft.azurewebsites.net/api/v1/";

        public static bool Suscribe(string token,string name)
        {
            string endpoint = "subscriptions/";
            var client = new RestClient(URL);
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", token));
            var request = new RestRequest(endpoint, Method.POST);

            string jsonToSend = SerializeSubscription.ToJson(new SubscriptionModel
            {
                Category = name,
            });

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            bool success = false;
            SubscriptionModel result = null;

            try
            {
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.Created)
                {
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
        public static CategoryModel InformationCategory(string name)
        {
            string endpoint = string.Format("categories/{0}/events/", name);
            var client = new RestClient(URL);
            var request = new RestRequest(endpoint, Method.GET);

            CategoryModel result = null;

            try
            {
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    result = CategoryModel.FromJson(response.Content);

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

        public static CategoryModel[] GetCategories()
        {
            const string endpoint = "categories/";
            var client = new RestClient(URL);
            var request = new RestRequest(endpoint, Method.GET);

            CategoryModel[] result = null;

            try
            {
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    result = ListCategoryModel.FromJson(response.Content);

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
