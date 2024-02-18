using Domain.Model.Residentes;

namespace Domain.Factory.Residentes
{
    public class ResidenteFactory : IResidenteFactory
    {
        public Residente Crear(string nombre)
        {
            return new Residente(nombre);
        }
    }
}
