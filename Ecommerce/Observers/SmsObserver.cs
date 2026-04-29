public class SmsObserver : IPedidoObserver
{
    public void Atualizar(Pedido pedido)
    {
        Console.WriteLine($"[SMS] Seu pedido {pedido.Id} mudou para: {pedido.Status}");
    }
}