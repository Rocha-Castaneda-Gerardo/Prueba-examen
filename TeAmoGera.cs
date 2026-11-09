using ARES8.Interfaces;
using ARES8.Modelos;

namespace ARES8.Sebastian;

/// Cola FIFO: la primera pieza en llegar es la primera en ensamblarse (Tema 4.3)
public class LineaProduccion : ILineaProduccion
{
    private Queue<PiezaRobot> _cola = new();

    public int Pendientes => _cola.Count;

    public void Encolar(PiezaRobot pieza) => _cola.Enqueue(pieza);

    public PiezaRobot? Ensamblar() => _cola.Count > 0 ? _cola.Dequeue() : null;

    public IEnumerable<PiezaRobot> Ver() => _cola;

    // Para deshacer un "Encolar": quita la última pieza que entró
    public bool QuitarUltima(out PiezaRobot? pieza)
    {
        pieza = null;
        if (_cola.Count == 0) return false;
        var lista = _cola.ToList();
        pieza = lista[^1];
        lista.RemoveAt(lista.Count - 1);
        _cola = new Queue<PiezaRobot>(lista);
        return true;
    }

    // Para deshacer un "Ensamblar": la pieza vuelve al frente
    public void ReinsertarAlFrente(PiezaRobot pieza)
    {
        var lista = new List<PiezaRobot> { pieza };
        lista.AddRange(_cola);
        _cola = new Queue<PiezaRobot>(lista);
    }
}
