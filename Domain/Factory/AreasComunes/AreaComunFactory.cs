using Domain.Model.AreasComunes;

namespace Domain.Factory.AreasComunes
{
    public class AreaComunFactory : IAreaComunFactory
    {
 
        public AreaComun Crear(Guid condominioId, Guid turnoId, string nombre, string descripcion, int capacidadMaxima, string estado)
        {
            return new AreaComun(condominioId, turnoId, nombre, descripcion, capacidadMaxima, estado);
        }
    }
}
