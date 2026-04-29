public static class ProcessadorPagamentoFactory
{
    public static IProcessadorPagamento Criar(FormaPagamentoEnum formaPagamento)
    {
       switch (formaPagamento)
        {
            case FormaPagamentoEnum.Pix:
                return new ProcessadorPix();
            case FormaPagamentoEnum.CartaoCredito:
                return new ProcessadorCartao();
            case FormaPagamentoEnum.Boleto:
                return new ProcesadorBoleto();
            default:
                throw new ArgumentException("Forma de pagamento não suportada: " + formaPagamento);
        }
    }
}