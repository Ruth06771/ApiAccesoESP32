using System.ComponentModel.DataAnnotations;

namespace ApiAccesoESP32.models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pin { get; set; }
        public string Uid { get; set; }
    }
}
