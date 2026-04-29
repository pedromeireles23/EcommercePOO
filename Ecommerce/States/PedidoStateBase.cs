public class PedidoStateBase : IPedidoState
{
    public virtual void Pagar(Pedido pedido)
    {
        Console.WriteLine("Ação 'Pagar' não permitida no estado atual.");
    }

    public virtual void IniciarSeparacao(Pedido pedido)
    {
        Console.WriteLine("Ação 'Iniciar Separação' não permitida no estado atual.");
    }

    public virtual void Enviar(Pedido pedido)
    {
        Console.WriteLine("Ação 'Enviar' não permitida no estado atual.");
    }

    public virtual void Entregar(Pedido pedido)
    {
        Console.WriteLine("Ação 'Entregar' não permitida no estado atual.");
    }
}