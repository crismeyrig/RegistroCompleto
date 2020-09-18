using System;
using System.ComponentModel.DataAnnotations;

public class Personas{
        [Key]
        public int PersonaId {get; set;}

         public string Nombre { get; set; }

        public int Telefono { get; set; }

        public int Cedula { get; set; }

        public string Direccion { get; set; }

        public DateTime FechaNacimiento { get; set; } = DateTime.Now;
    }