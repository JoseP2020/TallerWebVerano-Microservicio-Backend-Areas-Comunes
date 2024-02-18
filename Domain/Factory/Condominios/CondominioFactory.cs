using Domain.Model.Condominios;

namespace Domain.Factory.Condominios
{
    public class CondominioFactory : ICondominioFactory
    {
        public Condominio Crear(string nombre)
        {
            return new Condominio(nombre);
        }
    }
}
