public class ValidacaoPagamentoHandler : ValidacaoBase
{
  public override bool Validar(Pedido pedido)
  {
    try
    {
      var processador = ProcessadorPagamentoFactory.Criar(pedido.FormaPagamento);
      bool aprovado = processador.ProcessarPagamento(pedido);
      if (!aprovado)
      {
        System.Console.WriteLine("Pagamento não aprovado.");
        return false;
      }
      System.Console.WriteLine("Pagamento aprovado.");
      return PassarAdiante(pedido);
    }catch (Exception ex)
    {
      System.Console.WriteLine($"Erro ao processar pagamento: {ex.Message}");
      return false;
    }
  }
}