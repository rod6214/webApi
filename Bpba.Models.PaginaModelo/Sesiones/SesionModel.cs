using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bpba.Models.PaginaModelo.Usuarios;

namespace Bpba.Models.PaginaModelo.Sesiones
{
    public class SesionModel
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool Isonline { get; set; }
        public int Usuario_id { get; set; }
        public TimeSpan Duracion { get; set; }
        public DateTime TiempoInicial { get; set; }
    }
}
