public interface IProcessadorPagamento
{
    bool ProcessarPagamento(Pedido pedido);
    void ExibirDetalhesPagamento(Pedido pedido);
}