using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestApiMaui.Controllers
{
    public static class EmpleController
    {
        // Crud - Create
        public async static Task<Models.Msg> CreateEmple(Models.Empleado emple)
        {
            var msg = new Models.Msg();

            String jsonObject = JsonConvert.SerializeObject(emple);
            System.Net.Http.StringContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

            using(HttpClient client = new HttpClient()) 
            {
                HttpResponseMessage responseMessage = null;

                responseMessage = await client.PostAsync(Config.ConfigProcess.EndpointPost, content);

                if(responseMessage != null) 
                {
                    if(responseMessage.IsSuccessStatusCode) 
                    {
                        var result = responseMessage.Content.ReadAsStringAsync().Result;
                        msg = JsonConvert.DeserializeObject<Models.Msg>(result);
                    }
                }

            }

            return msg;
        }

        // cRUD - get 
        public async static Task<List<Models.Empleado>> GetEmpleados()
        {
            List<Models.Empleado> emplelist = new List<Models.Empleado>();

            try
            {
                using(HttpClient client = new HttpClient()) 
                {
                    HttpResponseMessage responseMessage = null;
                    responseMessage = await client.GetAsync(Config.ConfigProcess.EndpointGet);

                    if(responseMessage != null) 
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            var result = responseMessage.Content.ReadAsStringAsync().Result;
                            emplelist = JsonConvert.DeserializeObject<List<Models.Empleado>>(result);
                        }
                    }
                }

                return emplelist;
            }
            catch (Exception ex) 
            {
                Models.Msg msg  = new Models.Msg();
                msg.message = "Error no se proceso la transaccion";
                return null;
            }
        }

    }
}
