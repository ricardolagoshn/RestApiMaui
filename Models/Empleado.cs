using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiMaui.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string fechanac { get; set; }
        public string correo { get; set; }
        public string foto { get; set; }
    }
}
