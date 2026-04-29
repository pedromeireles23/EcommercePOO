public class PedidoSeparandoState : PedidoStateBase
{
    public override void Enviar(Pedido pedido)
    {
        Console.WriteLine("Pedido enviado.");

        pedido.Status = StatusPedidoEnum.Enviado;
        pedido.MudarState(new PedidoEnviadoState());
        pedido.NotificarObservadores();
    }
}