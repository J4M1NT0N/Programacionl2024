using System;
using System.Collections.Generic;

namespace RegistroTransacciones
{
    // Clase para representar un producto
    class Producto
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public string Proveedor { get; set; }
    }

    // Clase para representar una transacción
    class Transaccion
    {
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Tipo { get; set; }
        public List<Producto> ProductosAfectados { get; set; }
    }

    class Program
    {
        static List<Transaccion> transacciones = new List<Transaccion>();
        static List<Producto> inventario = new List<Producto>();
        static decimal saldoEnCaja = 0;

        static void Main(string[] args)
        {
            bool continuar = true;
            while (continuar)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarTransaccion();
                        break;
                    case "2":
                        MostrarTransacciones();
                        break;
                    case "3":
                        MostrarInventario();
                        break;
                    case "4":
                        ArqueoDeCaja();
                        break;
                    case "5":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Registrar una transacción");
            Console.WriteLine("2. Mostrar transacciones");
            Console.WriteLine("3. Mostrar inventario");
            Console.WriteLine("4. Realizar arqueo de caja");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
        }

        static void RegistrarTransaccion()
        {
            Console.WriteLine("\n=== REGISTRO DE TRANSACCIÓN ===");
            Console.Write("Ingrese la fecha (AAAA-MM-DD): ");
            DateTime fecha = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese el tipo de transacción (compra, venta, gasto, ingreso, etc.): ");
            string tipo = Console.ReadLine();

            Console.Write("Ingrese una descripción: ");
            string descripcion = Console.ReadLine();

            Console.Write("Ingrese el monto: ");
            decimal monto = decimal.Parse(Console.ReadLine());

            Console.Write("Ingrese la categoría de la transacción: ");
            string categoria = Console.ReadLine();

            List<Producto> productosAfectados = new List<Producto>();

            if (tipo.ToLower() == "compra")
            {
                Console.Write("Ingrese la cantidad de productos: ");
                int cantidadProductos = int.Parse(Console.ReadLine());

                for (int i = 0; i < cantidadProductos; i++)
                {
                    Producto nuevoProducto = new Producto();

                    Console.Write("Nombre del producto: ");
                    string nombreProducto = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nombreProducto))
                        break;

                    nuevoProducto.Nombre = nombreProducto;

                    Console.Write("Precio de compra del producto: ");
                    nuevoProducto.PrecioCompra = decimal.Parse(Console.ReadLine());

                    Console.Write("Precio de venta del producto: ");
                    nuevoProducto.PrecioVenta = decimal.Parse(Console.ReadLine());

                    Console.Write("Proveedor del producto: ");
                    nuevoProducto.Proveedor = Console.ReadLine();

                    nuevoProducto.Cantidad = 1; // Inicialmente se compra una unidad

                    inventario.Add(nuevoProducto);
                    productosAfectados.Add(nuevoProducto);
                }
            }
            else if (tipo.ToLower() == "venta")
            {
                Console.Write("Ingrese el nombre del producto vendido: ");
                string nombreProducto = Console.ReadLine();

                Console.Write("Ingrese la cantidad vendida: ");
                int cantidadVendida = int.Parse(Console.ReadLine());

                foreach (var producto in inventario)
                {
                    if (producto.Nombre.ToLower() == nombreProducto.ToLower())
                    {
                        if (producto.Cantidad >= cantidadVendida)
                        {
                            producto.Cantidad -= cantidadVendida;
                        }
                        else
                        {
                            Console.WriteLine("Error: No hay suficiente cantidad de este producto en el inventario.");
                            return;
                        }
                    }
                }
            }

            Transaccion nuevaTransaccion = new Transaccion
            {
                Fecha = fecha,
                Monto = monto,
                Descripcion = descripcion,
                Categoria = categoria,
                Tipo = tipo,
                ProductosAfectados = productosAfectados
            };

            transacciones.Add(nuevaTransaccion);

            // Actualizar el saldo en caja
            if (tipo.ToLower() == "venta")
            {
                saldoEnCaja += monto;
            }
            else if (tipo.ToLower() == "compra")
            {
                saldoEnCaja -= monto;
            }

            Console.WriteLine("Transacción registrada con éxito.");
        }

        static void MostrarTransacciones()
        {
            Console.WriteLine("\n=== LISTA DE TRANSACCIONES ===");
            if (transacciones.Count == 0)
            {
                Console.WriteLine("No hay transacciones registradas.");
                return;
            }

            foreach (var transaccion in transacciones)
            {
                Console.WriteLine($"Fecha: {transaccion.Fecha.ToShortDateString()} | Tipo: {transaccion.Tipo} | Descripción: {transaccion.Descripcion} | Monto: {transaccion.Monto} | Categoría: {transaccion.Categoria}");
            }
        }

        static void MostrarInventario()
        {
            Console.WriteLine("\n=== INVENTARIO ===");
            if (inventario.Count == 0)
            {
                Console.WriteLine("El inventario está vacío.");
                return;
            }

            foreach (var producto in inventario)
            {
                Console.WriteLine($"Nombre: {producto.Nombre} | Cantidad: {producto.Cantidad} | Precio de compra: {producto.PrecioCompra} | Precio de venta: {producto.PrecioVenta} | Proveedor: {producto.Proveedor}");
            }
        }

        static void ArqueoDeCaja()
        {
            Console.WriteLine("\n=== ARQUEO DE CAJA ===");
            Console.WriteLine($"Saldo en caja registrado: {saldoEnCaja}");
            Console.Write("Ingrese el saldo en caja contado: ");
            decimal saldoContado = decimal.Parse(Console.ReadLine());

            if (saldoContado == saldoEnCaja)
            {
                Console.WriteLine("Arqueo de caja equilibrado. Todo esta bien");
            }
            else
            {
                Console.WriteLine("¡Advertencia! Arqueo de caja desequilibrado. Revise las transacciones para identificar discrepancias.");
            }
        }
    }
}