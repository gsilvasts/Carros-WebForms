using Carros.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Carros
{
    public class CarrosDb
    {
        private string connectionstring = ConfigurationManager.ConnectionStrings["LojaCarrosEntities"].ConnectionString;

        public bool Add(Carro carro)
        {
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_insere_carro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = carro.Id;
                cmd.Parameters.Add("@MarcaId", SqlDbType.Int).Value = carro.MarcaId;
                cmd.Parameters.Add("@Modelo", SqlDbType.NVarChar, 50).Value = carro.Modelo;
                cmd.Parameters.Add("@Ano", SqlDbType.Int).Value = carro.Ano;
                cmd.Parameters.Add("@Cor", SqlDbType.NVarChar, 50).Value = carro.Modelo;

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

        public List<Carro> GetCarros()
        {
            List<Carro> carros = new List<Carro>();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                SqlCommand cmd = new SqlCommand("select m.Nome as Marca, c.Modelo as Modelo, c.Ano as Ano, c.Cor as Cor from Carro c left join Marca m ON c.MarcaId = m.Id", conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Carro carro = new Carro();
                    carro.Marca.Nome = rdr.GetValue(0).ToString();
                    carro.Modelo = rdr.GetValue(1).ToString();
                    carro.Ano = Convert.ToInt32(rdr.GetValue(2).ToString());
                    carro.Cor = rdr.GetValue(3).ToString();
                    carros.Add(carro);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return carros;
        }
    }
}