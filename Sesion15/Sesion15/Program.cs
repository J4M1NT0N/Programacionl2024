using Microsoft.EntityFrameworkCore;
using Sesion15;
using System;

var context = new AppDbContext();

// Crear cliente
var cliente = new Cliente
{
    Nombre = "Cliente 1",
    Direccion = "Jalapa",
    NIT = "7218273",
    Telefono = "2133242"
};

var factura = new Factura
{
    Cliente = cliente,
    Direccion = cliente.Direccion,
    Nombre = cliente.Nombre,
    NIT = cliente.NIT,
    Numero = "923402",
    Total = 100
};


context.Facturas.Add(factura);
//context.Clientes.Add(cliente);

//Recuperar cliente
//var clienteRecuperado = context.Clientes.FirstOrDefault(x => x.Id == 1);
//Console.WriteLine(clienteRecuperado?.Nombre ?? "");

//clienteRecuperado.Nombre = "Este cliente cambio de nombre";

////Actualizamos en la BD
//context.Update(clienteRecuperado);

//context.Remove(clienteRecuperado);
//Guardar cambios

//Recuperar facturas de cliente
var clienteRecuperado = context.Clientes.Include(s => s.Facturas).FirstOrDefault(x => x.NIT == "7218273");
Console.WriteLine(clienteRecuperado.Nombre);
Console.WriteLine(clienteRecuperado.Facturas.Count());

foreach (var facturaRecuperada in clienteRecuperado.Facturas)
{
    Console.WriteLine("Factura asociada :" + facturaRecuperada.Numero);
}
var clientesFiltrados = context.Facturas.Where(s => s.Total > 100 && s.Total < 200);

context.SaveChanges();
