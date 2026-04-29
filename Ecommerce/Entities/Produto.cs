public class Produto
{

    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int QuantidadeEmEstoque { get; set; } 
    public string Categoria { get; set; }

    public Produto(string nome, decimal preco, int estoque, string categoria)
    {
        Nome = nome;
        Preco = preco;
        QuantidadeEmEstoque = estoque;
        Categoria = categoria;
    }

    public bool TemEstoque()
    {
        return QuantidadeEmEstoque > 0;
    }
}