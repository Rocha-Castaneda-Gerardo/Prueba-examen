using ARES8.Interfaces;
using ARES8.Modelos;

namespace ARES8.Sebastian;

/// Pila LIFO para el botón "Deshacer" (Tema 4.2)
public class HistorialAcciones : IHistorial
{
    private readonly Stack<Accion> _pila = new();

    public int Cantidad => _pila.Count;

    public void Registrar(Accion accion) => _pila.Push(accion);

    public Accion? Deshacer() => _pila.Count > 0 ? _pila.Pop() : null;
}