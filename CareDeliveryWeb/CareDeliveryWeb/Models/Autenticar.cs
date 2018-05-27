using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareDeliveryWeb.Models
{
    public class Autenticar
    {
        private bool autenticado;

        public bool Autenticado
        {
            get { return autenticado; }
            set { autenticado = value; }
        }
        private int codUsuario;

        public int CodUsuario
        {
            get { return codUsuario; }
            set { codUsuario = value; }
        }
        private int categoria;

        public int Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
    }
}