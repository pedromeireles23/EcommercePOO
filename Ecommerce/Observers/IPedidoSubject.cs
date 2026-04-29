public interface IPedidoSubject
{
    void Inscrever(IPedidoObserver observador);
    void Desinscrever(IPedidoObserver observador);
    void NotificarObservadores();
}