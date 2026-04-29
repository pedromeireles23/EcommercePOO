var produto = new Produto("Notebook", 3000m, 5, "Eletrônicos");
var endereco = new Endereco("Rua A", "444", "Belo Horizonte", "MG", "30123-456");

// Observers
var observers = new List<IPedidoObserver>
{
    new EmailObserver(),
    new PainelAdminObserver()
};

// Frete
var frete = new PacStrategy();

// Descontos (pode deixar vazio se quiser)
var descontos = new List<Func<ICarrinhoDesconto, ICarrinhoDesconto>>
{
    c => new DescontoCupom(c, 0.1m)
};

var loja = new LojaFacade(observers, frete, descontos);

// Console.WriteLine("\n=== CENÁRIO 1: FLUXO FELIZ ===");

// var itens1 = new List<CarrinhoItem>
// {
//     new CarrinhoItem(produto, 1)
// };

// loja.FinalizarCompra(
//     itens1,
//     endereco,
//     FormaPagamentoEnum.Pix
// );

// Console.WriteLine("\n=== CENÁRIO 2: ESTOQUE INSUFICIENTE ===");

// var itens2 = new List<CarrinhoItem>
// {
//     new CarrinhoItem(produto, 10) // maior que o estoque (ex: 5)
// };

// loja.FinalizarCompra(
//     itens2,
//     endereco,
//     FormaPagamentoEnum.Pix
// );
Console.WriteLine("\n=== CENÁRIO 3: BOLETO RECUSADO ===");

var itens3 = new List<CarrinhoItem>
{
    new CarrinhoItem(produto, 1)
};

loja.FinalizarCompra(
    itens3,
    endereco,
    FormaPagamentoEnum.Boleto
);
