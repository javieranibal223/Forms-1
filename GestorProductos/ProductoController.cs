using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorProductos;

public class ProductoController
{
    private readonly IRepository<Producto> _repo;

    public ProductoController(IRepository<Producto> repo)
    {
        _repo = repo;
    }

    public void Agregar(string nombre, decimal precio, int stock, string rubro)
    {
        var producto = new Producto
        {
            Nombre = nombre,
            Precio = precio,
            Stock = stock,
            Rubro = rubro
        };

        _repo.Agregar(producto);
    }

    public List<Producto> ObtenerTodos()
    {
        var productos = _repo.LeerTodos();
        foreach (var p in productos)
        {
            if (p.Nombre != null)
            {
                p.Nombre = p.Nombre.ToUpper();
            }
        }
        return productos;
    }

    public Producto? ObtenerPorId(int id)
    {
        var producto = _repo.LeerTodos().FirstOrDefault(p => p.Id == id);
        if (producto != null && producto.Nombre != null)
        {
            producto.Nombre = producto.Nombre.ToUpper();
        }
        return producto;
    }

    public void Eliminar(int id)
    {
        _repo.Eliminar(id);
    }

    public void Eliminar(Producto producto)
    {
        if (producto != null)
        {
            _repo.Eliminar(producto.Id);
        }
    }

    public void Modificar(Producto modificado)
    {
        _repo.Actualizar(modificado);
    }

    public void EliminarSegunStock(int stockMaximo)
    {
        var lista = _repo.LeerTodos();
        var filtrados = lista.Where(p => p.Stock > stockMaximo).ToList();

        // Guardar la lista filtrada reemplazando los ítems
        var paraEliminar = lista.Where(p => p.Stock <= stockMaximo).ToList();
        foreach (var p in paraEliminar)
        {
            _repo.Eliminar(p.Id);
        }
    }

    public List<Producto> Buscar(string texto)
    {
        texto = texto.Trim();
        var todos = ObtenerTodos();

        if (string.IsNullOrWhiteSpace(texto))
        {
            return todos;
        }

        return todos
            .Where(p => (p.Nombre != null && p.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase)) ||
                        (p.Rubro != null && p.Rubro.Contains(texto, StringComparison.OrdinalIgnoreCase)))
            .ToList();
    }
}