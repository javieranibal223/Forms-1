using System;

namespace GestorProductos;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // CREAR EL CONTROLLER
        var controller = new ProductoController();

        // PASAR EL CONTROLLER AL FORMULARIO
        Application.Run(new Form1(controller));
    }
}