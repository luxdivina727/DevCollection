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
        #region Page load
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
        #endregion

        #region Metodos Privados
        private void CargarDatosPeliculas(List<Pelicula> listPeliculas)
        {
            RepeterPeliculas.DataSource = listPeliculas;
            RepeterPeliculas.DataBind();

            int count = 1;

            foreach (RepeaterItem repeaterItem in RepeterPeliculas.Items)
            {
                Pelicula pelicula = listPeliculas.ElementAt(count - 1);
                ((Label)repeaterItem.FindControl("LabelTittle")).Text = $"<h5 class='card-title'>{pelicula.Tittle}</h5>";
                ((Image)repeaterItem.FindControl("ImagePoster")).ImageUrl = pelicula.Poster.ToString();
                ((Label)repeaterItem.FindControl("LabelType")).Text = pelicula.Type.ToString();
                ((Label)repeaterItem.FindControl("LabelYear")).Text = pelicula.Year.ToString();
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