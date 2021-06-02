using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DAL.Model;
using DAL.Persistence;

namespace Carros
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // O nome do parâmetro id deve corresponder ao valor DataKeyNames definido no controle
       
        // O nome do parâmetro id deve corresponder ao valor DataKeyNames definido no controle
        public void gridCarros_DeleteItem(int CodCarro)
        {
            CarroDAL.ExcluirCarro(CodCarro);
        }

        // O tipo de retorno pode ser alterado para IEnumerable, no entanto, para dar suporte à paginação de
        // e classificação, os seguintes parâmetros devem ser adicionados:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<CarroViewModel> gridCarros_GetData()
        {
            var carro = CarroDAL.ListarCarros();
            return carro;
        }
    }
}