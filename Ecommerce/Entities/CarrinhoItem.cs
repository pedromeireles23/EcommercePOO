public class CarrinhoItem
{
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }

    public CarrinhoItem(Produto produto, int quantidade)
    {
        Produto = produto;
        Quantidade = quantidade;
    }

    public decimal SubTotal
    {
        get
        {
            return Produto.Preco * Quantidade;
        }
    }
}

    // public void AdicionarItem(Produto produto, int quantidade)
    // {
    //     CarrinhoItem item = new CarrinhoItem(produto, quantidade);
    //     Itens.Add(item);
    // }
//  public decimal CalcularTotal()
//     {
//         decimal total = 0;
//         foreach (var item in Itens)
//         {
//             total += item.Produto.Preco * item.Quantidade;
//         }
//         return total;
//     }
   
