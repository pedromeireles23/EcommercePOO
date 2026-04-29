public class ProcessadorCartao : IProcessadorPagamento
{
    public bool ProcessarPagamento(Pedido pedido)
    {
        Console.WriteLine("Processando pagamento com cartão...");
       

        // Simulação de processamento
        return true; // Sucesso
    }

    public void ExibirDetalhesPagamento(Pedido pedido)
    {
        Console.WriteLine("Detalhes do pagamento com cartão:");
        Console.WriteLine("Número do cartão: **** **** **** 1234");
        Console.WriteLine("Validade: 12/25");
        Console.WriteLine("Titular: João Silva");
    }
}