public class PedidoPendenteState : PedidoStateBase
{
    public override void Pagar(Pedido pedido)
    {
        Console.WriteLine("Pagamento realizado.");

        pedido.Status = StatusPedidoEnum.Pago;
        pedido.MudarState(new PedidoPagoState());
        pedido.NotificarObservadores();
    }
}