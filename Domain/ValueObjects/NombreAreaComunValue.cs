using Shared.Core;
using Shared.Rules;

namespace Domain.ValueObjects
{
    public record NombreAreaComunValue : ValueObject
    {
        public string Nombre { get; init; }

        public NombreAreaComunValue(string nombre)
        {
            CheckRule(new StringNotNullOrEmptyRule(nombre));
            if (nombre.Length > 50)
            {
                throw new BussinessRuleValidationException("Nombre no puede tener mas de 50 caracteres");
            }
            Nombre = nombre;
        }

        public static implicit operator string(NombreAreaComunValue value)
        {
            return value.Nombre;
        }

        public static implicit operator NombreAreaComunValue(string nombre)
        {
            return new NombreAreaComunValue(nombre);
        }
    }
}
