using Domain.Model.Condominios;

namespace Domain.Factory.Condominios
{
    public interface ICondominioFactory
    {
        Condominio Crear(string nombre);
    }
}
