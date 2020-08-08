using Android.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IHome.Services
{
    public static class ServiceIO
    {
        public static string UrlServidor = Util.GetServerConfig();

        private static async Task<string> DoGet(string uri)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.SendAsync(request);
                    return await response.Content.ReadAsStringAsync();
                };

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao enviar: " + uri + "\nDetalhes: " + e.Message);
            }
        }

        public static async Task<string> ActionIO(int pin, EnumAction action)
        {
            string uri = string.Empty;
            switch (action)
            {
                case EnumAction.ON:
                    uri = UrlServidor + "PIN" + pin.ToString() + "ON";
                    break;

                case EnumAction.OFF:
                    uri = UrlServidor + "PIN" + pin.ToString() + "OFF";
                    break;

                case EnumAction.TEMPERATURE:
                    uri = UrlServidor + "TEMP=ON";
                    break;

                case EnumAction.HUMIDITY:
                    uri = UrlServidor + "UMID=ON";
                    break;
            }
            try
            {
               return await DoGet(uri);
            }
            catch (Exception e)
            {
                return e.Message;              
            }
        }
    }
}
