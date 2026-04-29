public class PedidoEnviadoState : PedidoStateBase
{
    public override void Entregar(Pedido pedido)
    {
        Console.WriteLine("Pedido entregue.");

        pedido.Status = StatusPedidoEnum.Entregue;
        pedido.MudarState(new PedidoEntregueState());
        pedido.NotificarObservadores();
    }
}