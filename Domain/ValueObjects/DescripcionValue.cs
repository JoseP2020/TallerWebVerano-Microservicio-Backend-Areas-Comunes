using Shared.Core;
using Shared.Rules;

namespace Domain.ValueObjects
{
    public record DescripcionValue : ValueObject
    {
        public string Descripcion { get; init; }

        public DescripcionValue(string descripcion)
        {
            CheckRule(new StringNotNullOrEmptyRule(descripcion));
            if (descripcion.Length > 50)
            {
                throw new BussinessRuleValidationException("Descripcion no puede tener mas de 50 caracteres");
            }
            Descripcion = descripcion;
        }

        public static implicit operator string(DescripcionValue value)
        {
            return value.Descripcion;
        }

        public static implicit operator DescripcionValue(string descripcion)
        {
            return new DescripcionValue(descripcion);
        }
    }
}
