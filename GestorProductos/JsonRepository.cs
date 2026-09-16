using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace GestorProductos;

public class JsonRepository<T> : IRepository<T> where T : IEntidad
{
    private readonly string _ruta;

    public JsonRepository(string ruta)
    {
        _ruta = ruta;
    }

    public List<T> LeerTodos()
    {
        if (!File.Exists(_ruta))
            return new List<T>();

        var json = File.ReadAllText(_ruta);
        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }

    public T? BuscarPorId(int id)
    {
        return LeerTodos().FirstOrDefault(e => e.Id == id);
    }

    public void Agregar(T item)
    {
        var lista = LeerTodos();
        item.Id = lista.Count > 0 ? lista.Max(e => e.Id) + 1 : 1;
        lista.Add(item);
        Persistir(lista);
    }

    public void Actualizar(T item)
    {
        var lista = LeerTodos();
        var idx = lista.FindIndex(e => e.Id == item.Id);
        if (idx >= 0)
        {
            lista[idx] = item;
            Persistir(lista);
        }
    }

    public void Eliminar(int id)
    {
        var lista = LeerTodos();
        lista.RemoveAll(e => e.Id == id);
        Persistir(lista);
    }

    private void Persistir(List<T> lista)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(lista, options);
        File.WriteAllText(_ruta, json);
    }
}
