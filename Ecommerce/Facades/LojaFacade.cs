
public class LojaFacade
{
  private readonly List<IPedidoObserver> _observers;
    private readonly IFreteStrategy _freteStrategy;
private readonly List<Func<ICarrinhoDesconto, ICarrinhoDesconto>> _descontos;
    public LojaFacade(
        List<IPedidoObserver> observers,
    IFreteStrategy freteStrategy,
    List<Func<ICarrinhoDesconto, ICarrinhoDesconto>> descontos)
    {
         _observers = observers;
        _freteStrategy = freteStrategy;
        _descontos = descontos;
    }
        public void FinalizarCompra(
        List<CarrinhoItem> itens,
        Endereco endereco,
        FormaPagamentoEnum formaPagamento)
    {
        Console.WriteLine("=== INICIANDO COMPRA ===");

        // 1️⃣ Builder
        var pedido = new PedidoBuilder()
            .ComItens(itens)
            .ComEndereco(endereco)
            .ComFormaPagamento(formaPagamento)
            .ComFrete(_freteStrategy)
            .Build();

        // 2️⃣ Observers
        foreach (var obs in _observers)
        {
            pedido.Inscrever(obs);
        }

        // 3️⃣ Descontos (Decorator)
        ICarrinhoDesconto carrinho = new CarrinhoBase(itens);

        foreach (var aplicar in _descontos)
        {
            carrinho = aplicar(carrinho);
            }
        
        var totalOriginal = pedido.Total;
        var totalComDesconto = carrinho.CalcularTotal();
        pedido.TotalComDesconto = totalComDesconto;

        Console.WriteLine($"Total original: {totalOriginal:C}");
        Console.WriteLine($"Total com desconto: {totalComDesconto:C}");

        // 4️⃣ Frete
        var frete = _freteStrategy.CalcularFrete(itens);
        var totalFinal = totalComDesconto + frete;

        Console.WriteLine($"Frete: {frete:C}");
        Console.WriteLine($"Total final: {totalFinal:C}");

        // 5️⃣ Validação (Chain)
        var estoque = new ValidacaoEstoqueHandler();
        var enderecoVal = new ValidacaoEnderecoHandler();
        var pagamentoVal = new ValidacaoPagamentoHandler();
        var credito = new ValidacaoCreditoHandler();
        

        estoque
            .DefinirProximo(enderecoVal)
            .DefinirProximo(pagamentoVal)
            .DefinirProximo(credito);

        bool valido = estoque.Validar(pedido);

        if (!valido)
        {
            Console.WriteLine("Compra recusada na validação.");
            return;
        }

        // 6️⃣ Pagamento (Factory)
        // var processador = ProcessadorPagamentoFactory.Criar(pedido.FormaPagamento);

        // bool pagamentoOk = processador.ProcessarPagamento(pedido);

        // if (!pagamentoOk)
        // {
        //     Console.WriteLine("Pagamento não aprovado.");
        //     return;
        // }

        // 7️⃣ State + Observer
        pedido.Pagar();

        Console.WriteLine("Compra finalizada com sucesso!");
        pedido.ExibirResumo();
    }
}