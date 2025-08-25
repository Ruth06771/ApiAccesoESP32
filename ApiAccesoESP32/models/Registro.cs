using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAccesoESP32.models
{
    public class Registro
    {
        [Key]
        public int Id { get; set; }  // opcional, clave primaria
        public string Uid { get; set; }
        public string Nombre { get; set; }
        public string Metodo { get; set; }  // "PIN" o "RFID"
        [Column("Accion")] // <-- Mapea exactamente con la columna de la base
        public string Accion { get; set; }// "RETIRAR" o "DEVOLVER"
        public DateTime FechaHora { get; set; } = DateTime.UtcNow;

    }
}
