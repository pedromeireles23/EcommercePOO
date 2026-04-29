public class PedidoPagoState : PedidoStateBase
{
    public override void IniciarSeparacao(Pedido pedido)
    {
        Console.WriteLine("Iniciando separação.");

        pedido.Status = StatusPedidoEnum.Processando;
        pedido.MudarState(new PedidoSeparandoState());
        pedido.NotificarObservadores();
    }
}