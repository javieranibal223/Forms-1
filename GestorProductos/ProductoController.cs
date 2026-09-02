﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorProductos;

public class ProductoController
{
    private readonly List<Producto> _productos = new();

    private int _proximoId = 1;


    // =========================================================
    // AGREGAR
    // =========================================================

    public void Agregar(
        string nombre,
        decimal precio,
        int stock,
        string rubro)
    {
        var producto = new Producto
        {
            Id = _proximoId++,
            Nombre = nombre,
            Precio = precio,
            Stock = stock,
            Rubro = rubro
        };

        _productos.Add(producto);
    }


    // =========================================================
    // OBTENER TODOS
    // =========================================================

    public List<Producto> ObtenerTodos()
    {
        return _productos.ToList();
    }


    // =========================================================
    // ELIMINAR POR ID
    // =========================================================

    public void Eliminar(int id)
    {
        _productos.RemoveAll(
            p => p.Id == id);
    }


    // =========================================================
    // MODIFICAR
    // =========================================================

    public void Modificar(
        Producto modificado)
    {
        var p =
            _productos.Find(
                x => x.Id == modificado.Id);


        if (p == null)
        {
            return;
        }


        p.Nombre =
            modificado.Nombre;

        p.Precio =
            modificado.Precio;

        p.Stock =
            modificado.Stock;

        p.Rubro =
            modificado.Rubro;
    }


    // =========================================================
    // ELIMINAR SEGÚN STOCK
    // =========================================================

    public void EliminarSegunStock(
        int stockMaximo)
    {
        _productos.RemoveAll(
            p => p.Stock <= stockMaximo);
    }


    // =========================================================
    // BUSCAR POR NOMBRE O RUBRO
    // =========================================================

    public List<Producto> Buscar(
        string texto)
    {
        texto =
            texto.Trim();


        if (string.IsNullOrWhiteSpace(texto))
        {
            return ObtenerTodos();
        }


        return _productos
            .Where(
                p =>
                    p.Nombre.Contains(
                        texto,
                        StringComparison.OrdinalIgnoreCase)

                    ||

                    p.Rubro.Contains(
                        texto,
                        StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}

