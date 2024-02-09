using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Tipo
    {
        public int Id { get; set; }

        public string DescripcionTipo { get; set; }

        public override string ToString()
        {
            return DescripcionTipo;
        }
    }
}
