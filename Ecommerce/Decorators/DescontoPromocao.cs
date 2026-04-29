public class DescontoPromocao : DescontoBase
{
    public DescontoPromocao(ICarrinhoDesconto carrinho, decimal percentualDesconto) : base(carrinho, percentualDesconto)
    {
    }
}