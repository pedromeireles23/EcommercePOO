public class PainelAdminObserver : IPedidoObserver
{
    public void Atualizar(Pedido pedido)
    {
        Console.WriteLine($"[ADMIN] Pedido {pedido.Id} atualizado para {pedido.Status} em {pedido.DataPedido}");
    }
}