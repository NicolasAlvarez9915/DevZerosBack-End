using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class DispositivoMovil
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(11)")]
        public string Codigo { get; set; }
        [Column(TypeName = "int")]
        public int Cantidad { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Marca { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Modelo { get; set; }
        [Column(TypeName = "real")]
        public decimal PrecioCompra { get; set; }
        [Column(TypeName = "real")]
        public decimal PrecioVenta { get; set; }
        [Column(TypeName = "real")]
        public decimal PorcentajeIva { get; set; }
        [Column(TypeName = "real")]
        public decimal PorcentajeDescuento {get; set;}
        [Column(TypeName = "nvarchar(50)")]
        public string TipoPantalla { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Resolucion { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Procesador { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Almacenamiento { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Ram { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Camara { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string TipoBateria { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string CapacidadBateria { get; set; }
        [Column(TypeName = "nvarchar(11)")]
        public string TipoProteccion { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string LectorHuella { get; set; }
        public byte[] Imagen { get; set; }
    }
}
