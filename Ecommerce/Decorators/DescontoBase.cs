public abstract class DescontoBase : ICarrinhoDesconto
{
  private readonly ICarrinhoDesconto _carrinho;
  protected readonly decimal _percentualDesconto;
  public DescontoBase(ICarrinhoDesconto carrinho, decimal percentualDesconto)
  {
    _carrinho = carrinho;
    _percentualDesconto = percentualDesconto;
  }
  public virtual decimal CalcularTotal()
  {
    decimal total = _carrinho.CalcularTotal();
    decimal desconto = total * _percentualDesconto;
    return total - desconto;
  }


}