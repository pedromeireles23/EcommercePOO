public class Endereco
{
    public string Rua { get; set; }
    public string Numero { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string CEP { get; set; }

    public Endereco(string rua, string numero, string cidade, string estado, string cep)
    {
        Rua = rua;
        Numero = numero;
        Cidade = cidade;
        Estado = estado;
        CEP = cep;
    }

    public void ExibirEndereco()
    {
        Console.WriteLine($"{Rua}, {Numero} - {Cidade}/{Estado} - CEP: {CEP}");
    }
}