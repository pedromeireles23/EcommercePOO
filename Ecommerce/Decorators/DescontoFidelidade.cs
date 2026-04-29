public class DescontoFidelidade : DescontoBase
{
    public DescontoFidelidade(ICarrinhoDesconto carrinho, decimal percentualDesconto) : base(carrinho, percentualDesconto)
    {
    }
}