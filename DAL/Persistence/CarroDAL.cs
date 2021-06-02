using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DAL.Model;

namespace DAL.Persistence
{
    public class CarroDAL
    {
        private static string connectionstring = ConfigurationManager.ConnectionStrings["LojaCarrosEntities"].ConnectionString;

        public static bool AddCarro(Carro carro)
        {
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_insere_carro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodModelo", carro.CodModelo);
                cmd.Parameters.AddWithValue("@Ano", carro.Ano);
                cmd.Parameters.AddWithValue("@Cor", carro.Cor);

                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool AddModelo(Modelo modelo)
        {
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_insere_modelo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodMarca", modelo.CodMarca);
                cmd.Parameters.AddWithValue("@DescModelo", modelo.DescModelo);

                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool AddMarca(Marca marca)
        {
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_insere_marca", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@DescMarca", SqlDbType.VarChar, 100).Value = marca.DescMarca;
                //cmd.Parameters.Add("@DescMarca", SqlDbType.VarChar, 100).Value = marca.DescMarca;
                cmd.Parameters.AddWithValue("@DescMarca", marca.DescMarca);
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }


        public static IEnumerable<CarroViewModel> ListarCarros()
        {
            //CarroViewModel carro = new CarroViewModel();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_listar_carros", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();                

                var lista = new List<CarroViewModel>();
                while (rdr.Read())
                {
                    var carro = new CarroViewModel
                    {
                        CodCarro = Convert.ToInt32(rdr["CodCarro"]),
                        DescMarca = Convert.ToString(rdr["DescMarca"]),
                        DescModelo = Convert.ToString(rdr["DescModelo"]),
                        Ano = Convert.ToInt32(rdr["Ano"]),
                        Cor = Convert.ToString(rdr["Cor"])

                    };
                    lista.Add(carro);
                }

                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            
        }

        public static CarroViewModel GetCarro(int codCarro)
        {
            
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_lista_carro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodCarro", codCarro);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    CarroViewModel carro = new CarroViewModel();
                    carro.DescMarca = rdr["DescMarca"].ToString();
                    carro.CodModelo = Convert.ToInt32(rdr["CodModelo"]);
                    carro.DescModelo = rdr["DescModelo"].ToString();
                    carro.Ano = Convert.ToInt32(rdr["Ano"]);
                    carro.Cor = rdr["Cor"].ToString(); ;

                    return carro;
                }
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool AtualizarCarro(Carro carro)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            try
            {
                
                SqlCommand cmd = new SqlCommand("sp_atualiza_carro", conn);
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodCarro", carro.CodCarro);
                cmd.Parameters.AddWithValue("@CodModelo", carro.CodModelo);
                cmd.Parameters.AddWithValue("@Ano", carro.Ano);
                cmd.Parameters.AddWithValue("@Cor", carro.Cor);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {                
                throw new Exception("Erro ao atualizar dados: " + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool ExcluirCarro(int CodCarro)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_deletar_veiculo", conn);                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodCarro", CodCarro);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {

                throw new Exception ("Erro ao excluir dados: " + e.Message);
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
