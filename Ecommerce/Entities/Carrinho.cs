public class Carrinho
{
    private List<CarrinhoItem> Itens { get; set; }
    private IFreteStrategy _freteStrategy;

    public void DefinirFreteStrategy(IFreteStrategy strategy)
    {
        _freteStrategy = strategy;
    }

    public decimal Frete
    {
        get
        {
            if (_freteStrategy == null)
            return 0;
        
        return _freteStrategy.CalcularFrete(Itens);
        }
    }
   
    public Carrinho()
    {
        Itens = new List<CarrinhoItem>();
        
    }

    public decimal Total
    {
        get
        {
            decimal total = 0;
            foreach (var item in Itens)
            {
                total += item.SubTotal + Frete;
            }
            return total;
        }
    }

    public bool AdicionarItem(Produto produto, int quantidade)
    {
        if (produto.QuantidadeEmEstoque < quantidade)
        {
            return false;
        }

        var itemExistente = Itens.FirstOrDefault(i => i.Produto == produto);

        if (itemExistente != null)
        {
            itemExistente.Quantidade += quantidade;
        }
        else
        {
            Itens.Add(new CarrinhoItem(produto, quantidade));
        }

        return true;
    }

    public void RemoverItem(Produto produto)
    {
        var item = Itens.FirstOrDefault(i => i.Produto == produto);
        if (item != null)
        {
            Itens.Remove(item);
        }
    }

    public void ExibirResumo()
    {
        foreach (var item in Itens)
        {
            Console.WriteLine($"{item.Produto.Nome} - Quantidade: {item.Quantidade} - Subtotal: {item.SubTotal:C}");
        }
        System.Console.WriteLine($"/n Subtotal: {Total:C}");
        System.Console.WriteLine($"Frete: {Frete:C}");
    }
}