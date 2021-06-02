using DAL.Model;
using DAL.Persistence;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carros.View
{
    public partial class CriarModelo : System.Web.UI.Page
    {
        protected override void OnInitComplete(EventArgs e)
        {
            btnCadastrar.Click += BtnCadastrar_Click;
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            var modelo = new Modelo();

            modelo.CodMarca = Convert.ToInt32(ddlMarca.SelectedValue);
            modelo.DescModelo = txtModelo.Text;

            if (CarroDAL.AddModelo(modelo))
            {
                txtModelo.Text = string.Empty;
                lblMensagem.Text = "Modelo de veículo cadastrado com sucesso!";
            }
            else
            {
                lblMensagem.Text = "Ocorreu um erro ao efetuar o cadastro!";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionstring = ConfigurationManager.ConnectionStrings["LojaCarrosEntities"].ConnectionString;

                SqlConnection conn = new SqlConnection(connectionstring);
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT CodMarca, DescMarca FROM tblMarca", conn);
                    conn.Open();
                    SqlDataReader rd;
                    rd = cmd.ExecuteReader();
                    ddlMarca.DataSource = rd;
                    ddlMarca.DataValueField = "CodMarca";
                    ddlMarca.DataTextField = "DescMarca";
                    ddlMarca.DataBind();

                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }            

        }
    }
}