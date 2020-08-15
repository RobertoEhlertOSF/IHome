using Android.Util;
using IHome.Models;
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

        private static async Task<string> DoGet(string uri)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.SendAsync(request).ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {   
                        var res = await response.Content.ReadAsStringAsync().ConfigureAwait(false); ;
                        return res;
                    }
                    return ("Houve um problema de conexão com o servidor!");
                };

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao enviar: " + uri + "\nDetalhes: " + e.Message);
            }
        }

        public static async Task<string> ActionIO(Equipamento equip, bool value)
         {
            string UrlServidor = Util.GetServerConfig();
            string type = string.Empty;
            bool isSensor = false;
            string uri;

            switch (equip.Tipo)
            {
                case ("Entrada"):
                    type = "PIN";
                    break;
                case ("Saida"):
                    type = "POU";
                    break;
                case ("Analogico"):
                    type = equip.Sensor;
                    isSensor = true;
                    break;
                default:
                    break;
            }

            if (value && !isSensor)
            {
                uri = UrlServidor + type + equip.Pino.ToString() + "=ON";
            }
            else if(!isSensor)
            {
                uri = UrlServidor + type + equip.Pino + "=OFF";
            }
            else
            {
                uri = UrlServidor + type + "=ON";
            }

            try
            {
                return await DoGet(uri).ConfigureAwait(continueOnCapturedContext: false); 
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
