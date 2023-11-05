namespace ProyectoP1_final.Models
{
    public class Huesped
    {
        public int HuespedID { get; set; }
        public string? NombreHuesped { get; set; }
        public List<Reserva>? Reservas { get; set; }
    }
}
