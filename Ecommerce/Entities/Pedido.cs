using Microsoft.VisualBasic;

public class Pedido : IPedidoSubject
{
  internal Pedido()
  {
    _state = new PedidoPendenteState();
    Status = StatusPedidoEnum.Pendente;
  }

  private readonly List<IPedidoObserver> _observadores = new List<IPedidoObserver>();

  private IPedidoState _state;

  public Guid Id { get; set; } = Guid.NewGuid();
  public List<CarrinhoItem> Itens { get; set; }
  public Endereco EnderecoEntrega { get; set; }
  public FormaPagamentoEnum FormaPagamento { get; set; }
  public StatusPedidoEnum Status { get; set; }
  public DateTime DataPedido { get; set; } = DateTime.Now;
  public decimal Total => Itens.Sum(i => i.SubTotal);
  public decimal TotalComDesconto { get; set; }
  private IFreteStrategy _freteStrategy;
  public decimal Frete => _freteStrategy?.CalcularFrete(Itens) ?? 0;


  public void Pagar() => _state.Pagar(this);
  public void IniciarSeparacao() => _state.IniciarSeparacao(this);
  public void Enviar() => _state.Enviar(this);
  public void Entregar() => _state.Entregar(this);

  
  public PedidoStateBase EstadoAtual { get; private set; }

  public void AlterarEstado(PedidoStateBase novoEstado)
  {
    EstadoAtual = novoEstado;
  }


  internal void MudarState(IPedidoState novoState)
  {
    _state = novoState;
  }


  public void Inscrever(IPedidoObserver observador)
  {
    _observadores.Add(observador);
  }

  public void Desinscrever(IPedidoObserver observador)
  {
    _observadores.Remove(observador);
  }


  public void NotificarObservadores()
  {
    foreach (var observador in _observadores)
    {
      observador.Atualizar(this);
    }
  }


  public void MudarStatus(StatusPedidoEnum novoStatus)
  {
    Status = novoStatus;
    NotificarObservadores();
  }

  internal void DefinirDados(List<CarrinhoItem> itens, Endereco endereco, FormaPagamentoEnum formaPagamento)
  {
    Itens = itens;
    EnderecoEntrega = endereco;
    FormaPagamento = formaPagamento;
    Status = StatusPedidoEnum.Pendente;
  }

  public void DefinirFrete(IFreteStrategy freteStrategy)
  {
    _freteStrategy = freteStrategy;
  }

  public void ExibirResumo()
  {
    Console.WriteLine($"Pedido ID: {Id}");
    Console.WriteLine($"Data: {DataPedido}");
    Console.WriteLine($"Status: {Status}");
    Console.WriteLine($"Forma de Pagamento: {FormaPagamento}");
    Console.WriteLine("Itens:");

    foreach (var item in Itens)
    {
      Console.WriteLine($"- {item.Produto.Nome} x{item.Quantidade} - Subtotal: {item.SubTotal:C}");
    }

    Console.WriteLine($"Subtotal: {Total:C}");
    Console.WriteLine($"Frete: {Frete:C}");
    var totalBase = TotalComDesconto > 0 ? TotalComDesconto : Total;
    Console.WriteLine($"Total Geral: {(totalBase + Frete):C}");
  }
}