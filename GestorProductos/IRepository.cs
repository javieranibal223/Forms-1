using System.Collections.Generic;

namespace GestorProductos;

public interface IRepository<T> where T : IEntidad
{
    List<T> LeerTodos();
    T? BuscarPorId(int id);
    void Agregar(T item);
    void Actualizar(T item);
    void Eliminar(int id);
}
