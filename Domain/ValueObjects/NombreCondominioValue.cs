using Shared.Core;
using Shared.Rules;

namespace Domain.ValueObjects
{
    public record NombreCondominioValue : ValueObject
    {
        public string Nombre { get; init; }

        public NombreCondominioValue(string nombre)
        {
            CheckRule(new StringNotNullOrEmptyRule(nombre));
            if (nombre.Length > 40)
            {
                throw new BussinessRuleValidationException("Nombre no puede tener mas de 50 caracteres");
            }
            Nombre = nombre;
        }

        public static implicit operator string(NombreCondominioValue value)
        {
            return value.Nombre;
        }

        public static implicit operator NombreCondominioValue(string nombre)
        {
            return new NombreCondominioValue(nombre);
        }
    }
}
