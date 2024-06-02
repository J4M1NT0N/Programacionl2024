using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ProyectoFinal
{
    public partial class Dashboard : Window
    {
        private ObservableCollection<Producto> inventario;
        private ObservableCollection<MovimientoCaja> movimientosCaja;
        private ObservableCollection<Transaccion> transacciones;

        public Dashboard(ObservableCollection<Producto> inventario, ObservableCollection<MovimientoCaja> movimientosCaja, ObservableCollection<Transaccion> transacciones)
        {
            InitializeComponent();
            this.inventario = inventario ?? new ObservableCollection<Producto>();
            this.movimientosCaja = movimientosCaja ?? new ObservableCollection<MovimientoCaja>();
            this.transacciones = transacciones ?? new ObservableCollection<Transaccion>();
            CargarResumenInventario();
            CargarTransaccionesRecientes();
            CargarEstadisticasVentas();
            CargarMovimientosRecientes();
        }

        private void CargarResumenInventario()
        {
            int totalProductos = inventario.Count;
            int productosEnStock = inventario.Where(p => p.Cantidad > 0).Count();
            decimal valorTotalInventario = inventario.Sum(p => p.PrecioIngreso * p.Cantidad);

            txtTotalProductos.Text = $"Total de productos: {totalProductos}";
            txtProductosEnStock.Text = $"Productos en stock: {productosEnStock}";
            txtValorTotalInventario.Text = $"Valor total del inventario: ${valorTotalInventario:F2}";
        }

        private void CargarTransaccionesRecientes()
        {
            var transaccionesRecientes = transacciones.Take(5);

            foreach (var transaccion in transaccionesRecientes)
            {
                lstTransaccionesRecientes.Items.Add($"{transaccion.Tipo}: {transaccion.Descripcion} (${transaccion.Monto})");
            }
        }

        private void CargarEstadisticasVentas()
        {
            var ventasPorTipo = transacciones
                .Where(t => t.Tipo == "Venta")
                .GroupBy(t => t.Descripcion)
                .Select(g => new { Descripcion = g.Key, Total = g.Sum(t => t.Monto) });

            SeriesCollection series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Ventas",
                    Values = new ChartValues<decimal>(ventasPorTipo.Select(v => v.Total))
                }
            };

            chartVentas.Series = series;
            chartVentas.AxisX.Add(new Axis
            {
                Title = "Tipos de Venta",
                Labels = ventasPorTipo.Select(v => v.Descripcion).ToArray()
            });
            chartVentas.AxisY.Add(new Axis
            {
                Title = "Monto",
                LabelFormatter = value => value.ToString("C")
            });
        }

        private void CargarMovimientosRecientes()
        {
            var movimientosRecientes = movimientosCaja.Take(5);

            foreach (var movimiento in movimientosRecientes)
            {
                lstMovimientosRecientes.Items.Add($"{movimiento.TipoMovimiento}: {movimiento.Descripcion} (${movimiento.Monto})");
            }
        }
    }
}
