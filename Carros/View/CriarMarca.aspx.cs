using DAL.Model;
using DAL.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carros.View
{
    public partial class CriarMarca : System.Web.UI.Page
    {
        protected override void OnInitComplete(EventArgs e)
        {
            btnCadastrar.Click += BtnCadastrar_Click;
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {            
            var marca = new Marca();

            marca.DescMarca = txtMarca.Text;
            if (CarroDAL.AddMarca(marca))
            {
                lblMensagem.Text = "Marca de veículo cadastrado com sucesso!";
                txtMarca.Text = string.Empty;
            }
            else
            {
                lblMensagem.Text = "Ocorreu um erro ao efetuar o cadastro!";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}