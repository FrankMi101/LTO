﻿ 
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;

namespace DataAccess
{
    public class DataOperateServiceAPI : IDataOperateService
    {
        private readonly string jwtAuth = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTmFtZSI6Im1pZiIsIlVzZXJSb2xlIjoiVGVjaGVyIiwiZXhwIjoxNjQwMzg0ODYwLCJpc3MiOiJ3d3cudGNkc2Iub3JnIiwiYXVkIjoiU2Nob29sIFRlYWNoZXIifQ.h2Bv6Jix0MJ5CGnqQmmE7jQE0nzlgmqYalpsGzf9wQU";

        public string EditResult(string apiType, string uri, object parameter)
        {
            switch (apiType)
            {
                case "Add":
                case "ADD":
                    return POST_Method(apiType, uri, parameter);
                case "Edit":
                    return PUT_Method(apiType, uri, parameter);
                case "Remove":
                    return PUT_Method(apiType, uri, parameter);
                case "Delete":
                case "DELETE":
                    return DELETE_Method(apiType, uri, parameter);
                default:
                    return "";
            }
        }
        public string EditResult(string apiType, string uri, object parameter, string DapperCommandType)
        {
            return EditResult(apiType, uri, parameter);
        }
        public string EditResult(string sp, object parameter)
        {
            return EditResult("", sp, parameter);
        }
        public string EditResult(string sp, object parameter, string DapperCommandType)
        {
            return EditResult("", sp, parameter);
        }


        private List<T> GET_Method<T>(string apiType, string uri, object parameter)
        {
            List<T> listofT = null;
            try
            {
                string qStr = parameter.ToString(); // "/0354/SIC";
                // string url =  "https://webt.tcdsb.org/Webapi/ASM/api/"; // usergroup/list/" + qStr;
                string url = DBConnection.APIUrl();// WebConfigurationManager.ConnectionStrings["APISite"].ConnectionString;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtAuth);
                    //HTTP GET
                    var responseTask = client.GetAsync(uri + qStr);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<T>>();
                        readTask.Wait();

                        listofT = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..
                        listofT = Enumerable.Empty<T>().ToList();
                    }
                }
                return listofT.ToList();


            }
            catch (Exception ex)
            {
                var mes = ex.Message;
                return listofT.ToList();

            }
        }
        private string POST_Method(string apiType, string uri, object parameter)
        {
            try
            {
                string url = DBConnection.APIUrl();  //WebConfigurationManager.ConnectionStrings["APISite"].ConnectionString;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtAuth);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync(uri, parameter);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        // return  result.Content.ToString();

                        var contents = postTask.Result.Content.ReadAsStringAsync();
                        return contents.Result.ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private string PUT_Method(string apiType, string uri, object parameter)
        {
            try
            {
                string url = DBConnection.APIUrl(); // WebConfigurationManager.ConnectionStrings["APISite"].ConnectionString;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtAuth);

                    // string id = (string)parameter;
                    //HTTP POST
                    var putTask = client.PutAsJsonAsync(uri, parameter);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var contents = putTask.Result.Content.ReadAsStringAsync();
                        return contents.Result.ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private string DELETE_Method(string apiType, string uri, object parameter)
        {
            try
            {
                string url = DBConnection.APIUrl();  // WebConfigurationManager.ConnectionStrings["APISite"].ConnectionString;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtAuth);

                    //int id = (int) parameter ;
                    var id = parameter;
                    //HTTP DELETE
                    var deleteTask = client.DeleteAsync(uri + "/" + id.ToString());
                    deleteTask.Wait();

                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var contents = deleteTask.Result.Content.ReadAsStringAsync();
                        return contents.Result.ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        public List<T> ListOfT<T>(string db, string spName, object para)
        {
            throw new NotImplementedException();
        }

        public T ObjectOfT<T>(string db, string spName, object para)
        {
            throw new NotImplementedException();
        }

        public T ValueOfT<T>(string db, string spName, object para)
        {
            throw new NotImplementedException();
        }

        public string ValueString(string db, string spName, object para)
        {
            throw new NotImplementedException();
        }

        public DateTime ValueDate(string db, string spName, object para)
        {
            throw new NotImplementedException();
        }
    }
   
    public class DataOperateServiceAPI<T> : IDataOperateService<T>
    {
        private readonly string jwtAuth = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTmFtZSI6Im1pZiIsIlVzZXJSb2xlIjoiVGVjaGVyIiwiZXhwIjoxNjQwMzg0ODYwLCJpc3MiOiJ3d3cudGNkc2Iub3JnIiwiYXVkIjoiU2Nob29sIFRlYWNoZXIifQ.h2Bv6Jix0MJ5CGnqQmmE7jQE0nzlgmqYalpsGzf9wQU";

        public string EditResult(string apiType, string uri, object parameter)
        {
            switch (apiType)
            {
                case "Add":
                case "ADD":
                    return POST_Method(apiType,uri, parameter);
                case "Edit":
                    return PUT_Method(apiType,uri, parameter);
                case "Remove":
                    return PUT_Method(apiType,uri, parameter);
                case "Delete":
                case "DELETE":
                    return DELETE_Method(apiType,uri, parameter);
                default:
                    return "";
            }
        }
        public string EditResult(string apiType, string uri, object parameter, string DapperCommandType)
        {
            return EditResult(apiType, uri, parameter);
        }
        public string EditResult(string sp, object parameter)
        {
            return EditResult("", sp, parameter);
        }
        public string EditResult(string sp, object parameter, string DapperCommandType)
        {
            return EditResult("", sp, parameter);
        }
         
 
        private List<T> GET_Method(string apiType,string uri, object parameter)
        {
            List<T> listofT = null;
            try
            {
                string qStr = parameter.ToString(); // "/0354/SIC";
                // string url =  "https://webt.tcdsb.org/Webapi/ASM/api/"; // usergroup/list/" + qStr;
                string url = DBConnection.APIUrl();// WebConfigurationManager.ConnectionStrings["APISite"].ConnectionString;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Authorization =  new AuthenticationHeaderValue("Bearer", jwtAuth);               
                    //HTTP GET
                    var responseTask = client.GetAsync(uri + qStr);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<T>>();
                        readTask.Wait();

                        listofT = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..
                        listofT = Enumerable.Empty<T>().ToList();
                    }
                }
                return listofT.ToList();


            }
            catch (Exception ex)
            {
                var mes = ex.Message;
                return listofT.ToList();

            }
        }
        private string POST_Method(string apiType, string uri, object parameter)
        {
            try
            {
                string url = DBConnection.APIUrl();  //WebConfigurationManager.ConnectionStrings["APISite"].ConnectionString;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtAuth);

                    //HTTP POST
                    var postTask =  client.PostAsJsonAsync(uri, parameter);
                    postTask.Wait();

                    var result =  postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        // return  result.Content.ToString();

                         var contents = postTask.Result.Content.ReadAsStringAsync();
                        return contents.Result.ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private string PUT_Method(string apiType, string uri, object parameter)
        {         
            try
            {
                string url = DBConnection.APIUrl(); // WebConfigurationManager.ConnectionStrings["APISite"].ConnectionString;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtAuth);

                    // string id = (string)parameter;
                    //HTTP POST
                    var putTask = client.PutAsJsonAsync(uri, parameter);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var contents = putTask.Result.Content.ReadAsStringAsync();
                        return contents.Result.ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private string DELETE_Method(string apiType, string uri, object parameter)
        {
            try
            {
                string url = DBConnection.APIUrl();  // WebConfigurationManager.ConnectionStrings["APISite"].ConnectionString;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtAuth);

                    //int id = (int) parameter ;
                    var id = parameter;
                    //HTTP DELETE
                    var deleteTask = client.DeleteAsync(uri + "/" +  id.ToString());
                    deleteTask.Wait();

                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var contents = deleteTask.Result.Content.ReadAsStringAsync();
                        return contents.Result.ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<T> ListOfT(string db, string spName, object para)
        {
            throw new NotImplementedException();
        }

        public T ObjectOfT(string db, string spName, object para)
        {
            throw new NotImplementedException();
        }

        public T ValueOfT(string db, string spName, object para)
        {
            throw new NotImplementedException();
        }

        public string ValueString(string db, string spName, object para)
        {
            throw new NotImplementedException();
        }

        public DateTime ValueDate(string db, string spName, object para)
        {
            throw new NotImplementedException();
        }
    }
}
