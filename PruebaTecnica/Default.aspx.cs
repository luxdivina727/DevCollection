using PruebaTecnica.Request.Model;
using PruebaTecnica.Request.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PruebaTecnica
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    LinkButtonSearch_Click(null, null);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #region Metodos Privados
        private void CargarDatosPeliculas(List<Pelicula> peliculas)
        {
            RepeterPeliculas.DataSource = peliculas;
            RepeterPeliculas.DataBind();

            int count = 1;

            foreach (RepeaterItem repeaterItem in RepeterPeliculas.Items)
            {
                Pelicula pelicula = peliculas.ElementAt(count - 1);
                ((Label)repeaterItem.FindControl("LabelTittle")).Text = $"<h5 class='card-title'>{pelicula.Tittle}</h5>";
                ((Image)repeaterItem.FindControl("CardImagen")).ImageUrl = pelicula.Poster.ToString();
                ((Label)repeaterItem.FindControl("LabelTipo")).Text = pelicula.Type.ToString();
                ((Label)repeaterItem.FindControl("LabelAnio")).Text = pelicula.Year.ToString();
                //((Label)repeaterItem.FindControl("LabelAnio")).Text = $"<small class='text-muted'>{ pelicula.Year.ToString()}</small";

                count = count + 1;
            }
        }
        #endregion

        #region Eventos
        protected void LinkButtonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(TextBoxtSearch.Text))
                {
                    CargarDatosPeliculas(PeliculaController.ListarPeliculas(TextBoxtSearch.Text).GetAwaiter().GetResult());
                }
                else
                {
                    CargarDatosPeliculas(PeliculaController.ListarPeliculas(null).GetAwaiter().GetResult());

                }

            }
            catch (Exception) 
            {
                throw;
            }
        }



        #endregion

    }
}