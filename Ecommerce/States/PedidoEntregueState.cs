public class PedidoEntregueState : PedidoStateBase
{
    public override void Pagar(Pedido pedido)
    {
        Console.WriteLine("Pedido já entregue. Ação não permitida.");
    }

    public override void IniciarSeparacao(Pedido pedido)
    {
        Console.WriteLine("Pedido já entregue. Ação não permitida.");
    }

    public override void Enviar(Pedido pedido)
    {
        Console.WriteLine("Pedido já entregue. Ação não permitida.");
    }

    public override void Entregar(Pedido pedido)
    {
        Console.WriteLine("Pedido já foi entregue.");
    }
}