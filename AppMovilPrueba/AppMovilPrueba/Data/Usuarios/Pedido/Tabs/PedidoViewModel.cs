using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovilPrueba.Data.Usuarios.Pedido.Tabs
{
    public class PedidoViewModel
    {
        public string IdPedido { get; set; }
        public string NombreProducto { get; set; }
        public string Local { get; set; }
        public string Precio { get; set; }
        public string EstadoPedido { get; set; }
        public string Cantidad { get; set; }
        public string Total { get; set; }
        public string TipoPago { get; set; }
        public string Fecha { get; set; }
        public string Imagen { get; set; }
        public string Observacion { get; set; }
    }
}
