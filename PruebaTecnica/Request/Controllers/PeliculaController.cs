using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using PruebaTecnica.Request.Model;

namespace PruebaTecnica.Request.Controllers
{
    public static class PeliculaController
    {
        #region Propiedades

        /* Propiedades de configuración */
        private static string ApiBaseUrl => ConfigurationManager.AppSettings["ApiUrl"].ToString();
        private static string ApiKey => ConfigurationManager.AppSettings["ApiKey"].ToString();
        private static string ApiToken => ConfigurationManager.AppSettings["ApiToken"].ToString();

        #endregion

        #region Peliculas

        /* CRUD para consumir por medio de la API cualquier objeto de peliculas */

        public static Task<List<Pelicula>> ListarPeliculas(string tittlePelicula = null)
        {
            return Task.Run(() =>
            {
                List<Pelicula> listPeliculas = new List<Pelicula>();
                string apiKey = ApiKey.ToString();
                string apiToken = ApiToken.ToString();
                string urlPeticion = ApiBaseUrl.ToString() +"?apiKey=" + apiKey+"&";
                if (tittlePelicula != null)
                {
                    urlPeticion=urlPeticion+ "&s=" + tittlePelicula;
                }
                else
                {
                    urlPeticion = urlPeticion + "&s=marvel";

                }
                using (var client = new HttpClient())
                {
                    JArray jsonPeliculas = new JArray();
                    Pelicula pelicula = new Pelicula();
                    client.BaseAddress = new Uri(urlPeticion);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                    HttpResponseMessage response = client.GetAsync(urlPeticion).GetAwaiter().GetResult();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var jsonText = response.Content.ReadAsStringAsync().Result;
                        var objectJson = JObject.Parse(jsonText)["Search"];
                        if (objectJson != null)
                        {
                            jsonPeliculas = objectJson.ToString().Equals("") ? new JArray() : JArray.Parse(objectJson.ToString());
                            foreach (JObject jsonPelicula in jsonPeliculas.Children<JObject>())
                            {
                                listPeliculas.Add(
                                    new Pelicula()
                                    {
                                        ImdbID = jsonPelicula["imdbID"].ToString(),
                                        Year = jsonPelicula["Year"].ToString(),
                                        Tittle = jsonPelicula["Title"].ToString(),
                                        Type = jsonPelicula["Type"].ToString(),
                                        Poster = jsonPelicula["Poster"].ToString(),
                                    });
                            }
                        }
                    }
                }
                return listPeliculas;
            });
        }
        #endregion
    }
}