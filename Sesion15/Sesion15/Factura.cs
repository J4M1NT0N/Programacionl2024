using Sesion15;
using System;

public class Factura
{
    public int Id { get; set; }
    public string Numero { get; set; }
    public string Nombre { get; set; }
    public string NIT { get; set; }
    public decimal Total { get; set; }
    public string Direccion { get; set; }

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }

}