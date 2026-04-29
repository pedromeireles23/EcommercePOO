public interface IValidacaoHandler
{

  IValidacaoHandler Proximo { get; set; }
  bool Validar(Pedido pedido);

   IValidacaoHandler DefinirProximo(IValidacaoHandler proximo);
}