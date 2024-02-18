using Shared.Core;
using Shared.Rules;

namespace Domain.ValueObjects
{
    public record FechaValue : ValueObject
    {
        public DateTime Fecha { get; init; }

        public FechaValue(DateTime fecha)
        {
            CheckRule(new NotNullRule(fecha));

            if (fecha.Date <= DateTime.Now.Date.AddDays(1))
            {
                throw new BussinessRuleValidationException("La fecha debe ser al menos mañana.");
            }

            Fecha = fecha;
        }

        public static implicit operator DateTime(FechaValue value)
        {
            return value.Fecha;
        }

        public static implicit operator FechaValue(DateTime fecha)
        {
            return new FechaValue(fecha);
        }
    }
}
