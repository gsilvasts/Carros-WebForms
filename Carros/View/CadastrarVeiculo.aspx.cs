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
    public partial class Create : System.Web.UI.Page
    {
        protected override void OnInitComplete(EventArgs e)
        {
            btnCadastrar.Click += BtnCadastrar_Click;           
        }
       
        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            //var cadastrar = new CarroDAL();
            var carro = new Carro();            
            carro.CodModelo = Convert.ToInt32(ddlModelo.SelectedValue);
            carro.Ano = Convert.ToInt32(txtAno.Text);
            carro.Cor = txtCor.Text;

            if (CarroDAL.AddCarro(carro))
            {
                txtAno.Text = string.Empty;
                txtCor.Text = string.Empty;
                lblMensagem.Text = "Veículo Cadastrado com sucesso!";
            }
            else
            {
                lblMensagem.Text = "Ocorreu um erro ao efetuar o cadastro!";
            }
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtAno.Attributes.Add("onkeypress", "if(event.keyCode < 48 || event.keyCode > 57) {event.keyCode = 0;}");
            if (!IsPostBack)
            {
                string connectionstring = ConfigurationManager.ConnectionStrings["LojaCarrosEntities"].ConnectionString;

                SqlConnection conn = new SqlConnection(connectionstring);
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT CodModelo, mc.DescMarca + ' - ' + DescModelo AS Modelo FROM tblModelo md INNER JOIN tblMarca mc ON md.CodMarca = mc.CodMarca", conn);
                    conn.Open();
                    SqlDataReader rd;
                    rd = cmd.ExecuteReader();
                    ddlModelo.DataSource = rd;
                    ddlModelo.DataValueField = "CodModelo";
                    ddlModelo.DataTextField = "Modelo";
                    ddlModelo.DataBind();

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