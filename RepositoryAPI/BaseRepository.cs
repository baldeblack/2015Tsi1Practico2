using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Shared.Entities;


namespace RepositoryAPI
{
    public class BaseRepository<T> where T : class
    {

        public string UrlApi { get; set; }
        HttpClient asd = new HttpClient { BaseAddress = new Uri("http://localhost:38417/") };

        //ADD
        public void addEmployee(Employee emp)
        {
            var client = asd;
            

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(string.Format("api/addEmployee/{0}", emp)).Result;

            //if (response.IsSuccessStatusCode)
            //{
            //   var datosContacto = response.Content.ReadAsStringAsync();
            //   return JsonConvert.DeserializeObject<T>(datosContacto.Result);
            //}
            //else
            //{
            //   return null;
            //}
        }

        //DELETE
        public void deleteEmployee(int id)
        {
            var client = asd;

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(string.Format("api/addEmployee/{0}", id)).Result;
        }

        //UPDATE
        public void updateEmployee(Employee emp)
        {
            var client = asd;

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(string.Format("api/updateEmployee/{0}", emp)).Result;
        }

        //GETALL EMPLOYEE
        public List<T> getAllEmployees()
        {
            var client = asd;

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(string.Format("api/getAllEmployee/{0}")).Result;

            if (response.IsSuccessStatusCode)
            {
                var getAllEmployee = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T>>(getAllEmployee.Result);
            }
            else
            {
                return null;
            }
        }

        //GET EMPLOYEE
        public T getEmployee(int id)
        {
            var client = asd;

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(string.Format("api/getEmployee/{0}", id)).Result;

            if (response.IsSuccessStatusCode)
            {
                var getEmployee = response.Content.ReadAsStringAsync();
               return JsonConvert.DeserializeObject<T>(getEmployee.Result);
            }
            else
            {
                return null;
            }
        }


        //SEARCH
        public List<T> searchEmployees(string searchTerm)
        {
            var client = asd;

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(string.Format("api/getEmployee/{0}", searchTerm)).Result;

            if (response.IsSuccessStatusCode)
            {
                var searchEmployees = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T>>(searchEmployees.Result);
            }
            else
            {
                return null;
            }
        }


    }
}
