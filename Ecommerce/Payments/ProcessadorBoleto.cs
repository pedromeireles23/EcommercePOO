public class ProcesadorBoleto : IProcessadorPagamento
{
    public Guid NumeroBoleto { get; set; } = Guid.NewGuid();

    public bool ProcessarPagamento(Pedido pedido)
    {
        Console.WriteLine("Boleto foi gerado... Aguardando pagamento.");
        return false;
    }

    public void ExibirDetalhesPagamento(Pedido pedido)
    {
        Console.WriteLine("Detalhes do pagamento via boleto:");
        Console.WriteLine($"Valor: {pedido.Total:C}");
        System.Console.WriteLine("Número do boleto: " + NumeroBoleto);
        Console.WriteLine("Vencimento: " + DateTime.Now.AddDays(7).ToShortDateString());
    }
}