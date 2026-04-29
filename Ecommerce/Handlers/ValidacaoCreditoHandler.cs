public class ValidacaoCreditoHandler : ValidacaoBase
{
  private const decimal LimiteCredito = 5000m;
  public override bool Validar(Pedido pedido)
  {
    if (pedido.Total > LimiteCredito)
    {
        Console.WriteLine("Valor do pedido excede o limite de crédito.");
        return false;
    }
    return PassarAdiante(pedido);
  }
}