public class ProcessadorPix : IProcessadorPagamento
{
  public Guid ChavePix { get; set; } = Guid.NewGuid();
    public void ExibirDetalhesPagamento(Pedido pedido)
      {
          Console.WriteLine("Detalhes do pagamento via Pix:");
          Console.WriteLine("Chave Pix:" + ChavePix);
          Console.WriteLine("Valor: R$ 150,00");
      }
    public bool ProcessarPagamento(Pedido pedido)
    {
        Console.WriteLine("Processando pagamento via Pix...");

        // Simulação de processamento
        return true; // Sucesso
    }

}