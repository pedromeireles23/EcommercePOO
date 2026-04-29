public class CarrinhoBase : ICarrinhoDesconto
{
    private readonly List<CarrinhoItem> _itens;

    public CarrinhoBase(List<CarrinhoItem> itens)
    {
        _itens = itens;
    }

    public decimal CalcularTotal()
    {
        return _itens.Sum(item => item.SubTotal);
    }
}