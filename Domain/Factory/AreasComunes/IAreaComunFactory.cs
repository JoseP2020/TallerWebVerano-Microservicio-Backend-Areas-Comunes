using Domain.Model.AreasComunes;

namespace Domain.Factory.AreasComunes
{
    public interface IAreaComunFactory
    {
        AreaComun Crear(Guid condominioId, Guid turnoId, string nombre, string descripcion, int capacidadMaxima, string estado);
    }
}
