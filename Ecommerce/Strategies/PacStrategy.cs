public class PacStrategy : IFreteStrategy
{
  public decimal CalcularFrete(List<CarrinhoItem> itens)
  {
    return 5.0m;
  }
}