using DAL.Model;
using DAL.Persistence;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carros.View
{
    public partial class Editar : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlEditar.Visible = false;

            if (!IsPostBack)
            {
                string connectionstring = ConfigurationManager.ConnectionStrings["LojaCarrosEntities"].ConnectionString;

                SqlConnection conn = new SqlConnection(connectionstring);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_listar_carro_para_edicao", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rd;
                    rd = cmd.ExecuteReader();
                    ddlCarro.DataSource = rd;
                    ddlCarro.DataValueField = "CodCarro";
                    ddlCarro.DataTextField = "Veiculo";
                    ddlCarro.DataBind();

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

        protected void btnPesquisar_Click(object sender, EventArgs e)
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

            int codCarro = Convert.ToInt32(ddlCarro.SelectedValue);
            var carro = CarroDAL.GetCarro(codCarro);

            if (carro != null)
            {
                txtAno.Text = Convert.ToString(carro.Ano);
                txtCor.Text = carro.Cor;
                //txtMarca.Text = carro.DescMarca;
                //txtModelo.Text = carro.DescModelo;
                ddlModelo.SelectedValue = Convert.ToString(carro.CodModelo);

                pnlEditar.Visible = true;
            }
            
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            var carro = new Carro();
            carro.CodCarro = Convert.ToInt32(ddlCarro.SelectedValue);
            carro.CodModelo = Convert.ToInt32(ddlModelo.SelectedValue);
            carro.Ano = Convert.ToInt32(txtAno.Text);
            carro.Cor = txtCor.Text;

            if (CarroDAL.AtualizarCarro(carro))
            {
                lblMensagem.Text = "Dados Atualizado com Sucesso";
            }
            else
            {
                lblMensagem.Text = "Ocorreu um erro ao atualizar os dados";
            }
        }
    }
}