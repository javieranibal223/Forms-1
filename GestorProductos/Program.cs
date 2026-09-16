using System;
using System.Windows.Forms;

namespace GestorProductos;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // 1. Crear el repositorio persistente en JSON
        var repo = new JsonRepository<Producto>("productos.json");

        // 2. Inyectar el repositorio en el controlador
        var controller = new ProductoController(repo);

        // 3. Inyectar el controlador en el formulario visual
        Application.Run(new Form1(controller));
    }
}