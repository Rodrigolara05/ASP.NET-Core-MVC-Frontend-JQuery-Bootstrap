using System;
using System.Net;
using Event_Soft_FrontEnd.Models;
using RestSharp;

namespace Event_Soft_FrontEnd.Controllers.Category
{
    public class CategoryConnection
    {
        private const string URL = "https://webeventsoft.azurewebsites.net/api/v1/";

        public static CategoryModel[] GetEvents()
        {
            const string endpoint = "categories/";
            var client = new RestClient(URL);
            var request = new RestRequest(endpoint, Method.GET);

            CategoryModel[] result = null;

            try
            {
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
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
