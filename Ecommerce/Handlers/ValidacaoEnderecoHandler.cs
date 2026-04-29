public class ValidacaoEnderecoHandler : ValidacaoBase
{
  public override bool Validar(Pedido pedido)
  {
   var endereco = pedido.EnderecoEntrega;
   if(endereco == null || string.IsNullOrWhiteSpace(endereco.Rua) || string.IsNullOrWhiteSpace(endereco.Cidade) || string.IsNullOrWhiteSpace(endereco.Estado) || string.IsNullOrWhiteSpace(endereco.CEP))
   {
    Console.WriteLine("Endereço inválido. Preencha todos os campos de endereço.");
    return false;
   }
   return PassarAdiante(pedido);
  }
}