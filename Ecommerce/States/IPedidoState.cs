public interface IPedidoState
{
    void Pagar (Pedido pedido);
    void IniciarSeparacao (Pedido pedido);
    void Enviar (Pedido pedido);
    void Entregar (Pedido pedido);
}