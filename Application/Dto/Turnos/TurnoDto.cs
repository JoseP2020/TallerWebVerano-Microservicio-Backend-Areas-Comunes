namespace Application.Dto.Turnos
{
    public class TurnoDto
    {
        public Guid Id { get; set; }
        public TimeOnly Inicio{ get; set; }
        public TimeOnly Fin { get; set; }

    }
}
