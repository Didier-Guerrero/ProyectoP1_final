namespace ProyectoP1_final.Models
{
    public class Habitacion
    {
        public int HabitacionID { get; set; }
        public int? NumeroHabitacion { get; set; }
        public List<Reserva>? Reservas { get; set; }
    }
}
