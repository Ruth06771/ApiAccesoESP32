using System;
using System.ComponentModel.DataAnnotations;

namespace ApiAccesoESP32.DTOs
{
    public class CrearRegistroDTO
    {
        public string Uid { get; set; }
        public string Nombre { get; set; }
        public string Metodo { get; set; }  // "PIN" o "RFID"
        public string Accion { get; set; }  // "RETIRAR" o "DEVOLVER"
        public DateTime FechaHora { get; set; } // Agregado para que coincida con el JSON
    }
}
