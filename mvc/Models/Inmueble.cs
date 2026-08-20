namespace mvc.Models
{
    public class Inmueble
    {
        public int Id { get; set; }

        public string Direccion { get; set; } = "";

        public int Cupo { get; set; }

        public string Tipo { get; set; } = "";

        public decimal? Latitud { get; set; }

        public decimal? Longitud { get; set; }

        public decimal PrecioPorDia { get; set; }

        public decimal PorcentajeReserva { get; set; }

        public bool Disponible { get; set; } = true;

        // Clave foránea
        public int PropietarioId { get; set; }

        // Relación con Propietario
        public Propietario Propietario { get; set; } = null!;
    }
}