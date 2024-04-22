using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gabriel_Padilla_P1.Models
{
    public class PRodriguez
    {
        public int Id { get; set; }
        public string CampoString { get; set; }
        public int CampoInt { get; set; }
        public decimal CampoDecimal { get; set; }
        public bool CampoBool { get; set; }
        public DateTime CampoFecha { get; set; }
        public int CarreraId { get; set; }
        public Carrera Carrera { get; set; }
    }

    public class Carrera
    {
        public int Id { get; set; }
        public string NombreCarrera { get; set; }
        public string Campus { get; set; }
        public int NumeroSemestres { get; set; }
    }
}
