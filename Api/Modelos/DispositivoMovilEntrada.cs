using System;
using Entidad;

namespace Api.Modelos
{
    public class DispositivoMovilEntrada
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Cantidad { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PorcentajeIva { get; set; }
        public decimal PorcentajeDescuento {get; set;}
        public string TipoPantalla { get; set; }
        public string Resolucion { get; set; }
        public string Procesador { get; set; }
        public string Almacenamiento { get; set; }
        public string Ram { get; set; }
        public string Camara { get; set; }
        public string TipoBateria { get; set; }
        public string CapacidadBateria { get; set; }
        public string TipoProteccion { get; set; }
        public string LectorHuella { get; set; }
        public string Imagen { get; set; }
    }

    public class DispositivoMovilVista: DispositivoMovilEntrada
    {
        public DispositivoMovilVista(){

        }
        public DispositivoMovilVista(DispositivoMovil dispositivoMovil){
            Id = dispositivoMovil.Id;
            Codigo = dispositivoMovil.Codigo;
            Cantidad = dispositivoMovil.Cantidad;
            Marca = dispositivoMovil.Marca;
            Modelo = dispositivoMovil.Modelo;
            PrecioCompra = dispositivoMovil.PrecioCompra;
            PrecioVenta = dispositivoMovil.PrecioVenta;
            PorcentajeIva = dispositivoMovil.PorcentajeIva;
            PorcentajeDescuento = dispositivoMovil.PorcentajeDescuento;
            TipoPantalla = dispositivoMovil.TipoPantalla;
            Resolucion = dispositivoMovil.Resolucion;
            Procesador = dispositivoMovil.Procesador;
            Almacenamiento = dispositivoMovil.Almacenamiento;
            Camara = dispositivoMovil.Camara;
            Ram = dispositivoMovil.Ram;
            TipoBateria = dispositivoMovil.TipoBateria;
            CapacidadBateria = dispositivoMovil.CapacidadBateria;
            TipoProteccion = dispositivoMovil.TipoProteccion;
            LectorHuella = dispositivoMovil.LectorHuella;
            Imagen = "data:image/jpeg;base64," + ConvertirByteToImage(dispositivoMovil.Imagen);      
        }   
        public string ConvertirByteToImage(byte[] img)
        { 
            return Convert.ToBase64String(img);
        }
    }
}
