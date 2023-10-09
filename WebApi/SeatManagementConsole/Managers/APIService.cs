using Newtonsoft.Json;
using SeatManagement1Console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement1Console.Managers
{
    public class APIService<T> : IAPIService<T> where T : class
    {
        private readonly HttpClient client;
        public string baseUrl;
        public string apiEndpoint;
        public APIService(string apiEndpoint)
        {
            baseUrl = "https://localhost:7134/api/";
            this.apiEndpoint = apiEndpoint;
            client = new HttpClient();
        }

        public void PostWithExtension<T>(string extension)
        {
            try
            {
                HttpResponseMessage response = client.PostAsync(baseUrl + apiEndpoint + extension, null).Result;

                if (response.IsSuccessStatusCode)
                {

                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.Content.ReadAsStringAsync().Result}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred in API Configurations");
            }

        }

        public async void PatchWithExtension<T>(string extension)
        {
            try
            {
                var url = baseUrl + apiEndpoint + extension;
                Console.Out.WriteLine(url);

                HttpResponseMessage response = await client.PatchAsync(url, null);

                if (response.IsSuccessStatusCode)
                {
                   
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");

                }
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred in API Configurations");

            }

        }

        public async Task<int?> Post<T>(T newObject)
        {
            try
            {
                string jsonObject = JsonConvert.SerializeObject(newObject);

                
                StringContent content = new StringContent(jsonObject, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(baseUrl + apiEndpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        int? responseId = JsonConvert.DeserializeObject<int>(responseContent);
                       
                        return responseId;
                    }
                    catch (Exception ex)
                    {
                        //if no Id Present.
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return null;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred in API Configurations");
                return null;
            }

        }


        public async Task<List<T>> GetAll<T>()
        {

            try
            {
                HttpResponseMessage response = await client.GetAsync(baseUrl + apiEndpoint);

                if (response.IsSuccessStatusCode)
                {
                    
                    string content = await response.Content.ReadAsStringAsync();

                    List<T> objects = JsonConvert.DeserializeObject<List<T>>(content);

                    return objects;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return null;
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"An error occurred with configurations of API");
                return null;
            }

        }
        public async Task <List<T>> GetAllWithExtension<T>(string extension)
        {
            try
            {
                var url = baseUrl + apiEndpoint + extension;
               

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    List<T> objects = JsonConvert.DeserializeObject<List<T>>(content);

                    return objects;

                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return null;

                }
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred in API Configurations");
                return null;
            }

        }


        //Generic GetById 
        public async Task<T> GetById<T>(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{baseUrl}{apiEndpoint}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    // Within the response header, we have content of the response.
                    string content = await response.Content.ReadAsStringAsync();

                    T obj = JsonConvert.DeserializeObject<T>(content);

                    return obj;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return default(T); //returns default value for T
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"An error occurred with configurations of API");
                return default(T);
            }

        }

        //Generic Put
        public async void PutWithExtension<T>(string extension)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsync(baseUrl + apiEndpoint + extension, null);

                if (response.IsSuccessStatusCode)
                {
                    //success
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred in API Configurations");
            }
        }


    }
}
