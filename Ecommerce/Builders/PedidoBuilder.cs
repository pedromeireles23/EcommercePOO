public class PedidoBuilder
{
  private Endereco _endereco;
  private FormaPagamentoEnum _formaPagamento;
  private List<CarrinhoItem> _itens;
  private IFreteStrategy _freteStrategy;

  public PedidoBuilder ComEndereco(Endereco endereco)
  {
    _endereco = endereco;
   
    return this;
  }
  public PedidoBuilder ComFormaPagamento(FormaPagamentoEnum formaPagamento)
  {
    _formaPagamento = formaPagamento;
    return this;
  }
  public PedidoBuilder ComItens(List<CarrinhoItem> itens)
  {
    _itens = itens;
    return this;
  }

  public PedidoBuilder ComFrete(IFreteStrategy freteStrategy)
  {
    _freteStrategy = freteStrategy;
    return this;
  }
  public Pedido Build()
{
    if (_endereco == null)
        throw new InvalidOperationException("Endereço não informado.");

    if (_formaPagamento == FormaPagamentoEnum.Nenhum)
        throw new InvalidOperationException("Forma de pagamento inválida.");

    if (_itens == null || !_itens.Any())
        throw new InvalidOperationException("Pedido sem itens.");

    if (_freteStrategy == null)
        throw new InvalidOperationException("Frete não definido.");

    var pedido = new Pedido();

    pedido.DefinirDados(_itens, _endereco, _formaPagamento);
    pedido.DefinirFrete(_freteStrategy);

    Reset();

    return pedido;
}
  private void Reset()
  {
    _endereco = null;
    _formaPagamento = FormaPagamentoEnum.Nenhum;
    _itens = null;
    _freteStrategy = null;
  }


}