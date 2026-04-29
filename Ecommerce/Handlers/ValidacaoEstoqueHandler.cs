
public class ValidacaoEstoqueHandler : ValidacaoBase
{
  public override bool Validar(Pedido pedido)
  {
    foreach (var item in pedido.Itens)
    {
        if (item.Quantidade > item.Produto.QuantidadeEmEstoque)
        {
            Console.WriteLine($"Produto {item.Produto.Nome} sem estoque suficiente.");
            return false;
        }
    }
    return PassarAdiante(pedido);
  }
}