namespace ProyectoP1_final.Models
{
    public class Reserva
    {
        public int? ID { get; set; }
        public DateTime? FechaReserva { get; set; }
        public int HabitacionID { get; set; }
        public Habitacion? Habitacion { get; set; }
        public int HuespedID { get; set; }
        public Huesped? Huesped { get; set; }
    } 
}
