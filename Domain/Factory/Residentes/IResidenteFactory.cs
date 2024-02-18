using Domain.Model.Residentes;

namespace Domain.Factory.Residentes
{
    public interface IResidenteFactory
    {
        Residente Crear(string nombre);
    }
}
