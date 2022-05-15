﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestApp1.Api
{
    /// <summary>
    /// Api Mehods 
    /// </summary>
    public class Base
    {
        /// <summary>
        /// Api Get Method
        /// </summary>
        /// <returns></returns>
        public async Task<string> Get(string url)
        {
            try
            {
                string Content = null;
                HttpResponseMessage response = new HttpResponseMessage();
                using (HttpClient api = new HttpClient())
                {
                    response = await api.GetAsync(url);
                }
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    Content = await response.Content.ReadAsStringAsync();
                    return Content ?? "";
                }
                else return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// Api Post Method
        /// </summary>
        public bool Post()
        {
            HttpClient api = new HttpClient();
            return true;
        }
    }
}
