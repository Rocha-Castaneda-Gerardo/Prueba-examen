// Archivo: Interfaces.cs
using System;
using System.Collections.Generic;

namespace SimuladorExamen
{
    // Define el contrato básico de cualquier pieza
    public interface IPiezaRobot
    {
        int Id { get; }
        string Nombre { get; }
        string Categoria { get; }
        double Costo { get; }
        void MostrarDetalles();
    }
}
// Archivo: PiezaBase.cs
namespace SimuladorExamen
{
    // Clase abstracta que implementa la interfaz (OCP: lista para extenderse)
    public abstract class PiezaBase : IPiezaRobot
    {
        public int Id { get; }
        public string Nombre { get; }
        public string Categoria { get; }
        public double Costo { get; }

        protected PiezaBase(int id, string nombre, string categoria, double costo)
        {
            Id = id;
            Nombre = nombre;
            Categoria = categoria;
            Costo = costo;
        }

        public virtual void MostrarDetalles()
        {
            Console.WriteLine($"[{Id}] {Categoria} - {Nombre}: ${Costo}");
        }
    }
}