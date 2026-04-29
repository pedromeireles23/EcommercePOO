public class EmailObserver : IPedidoObserver
{
    public void Atualizar(Pedido pedido)
    {
        Console.WriteLine($"[EMAIL] Pedido {pedido.Id} agora está com status: {pedido.Status}");
    }
}