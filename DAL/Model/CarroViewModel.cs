using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class CarroViewModel
    {
        public int CodCarro { get; set; }
        public int CodModelo { get; set; }
        public string DescMarca { get; set; }
        public string DescModelo { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
    }
}
