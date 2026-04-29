public abstract class ValidacaoBase : IValidacaoHandler
{
   private IValidacaoHandler _proximo;

    public IValidacaoHandler Proximo
    {
        get { return _proximo; }
        set { _proximo = value; }
    }

    public IValidacaoHandler DefinirProximo(IValidacaoHandler proximo)
    {
        _proximo = proximo;
        return proximo;
    }
    public abstract bool Validar (Pedido pedido);
    protected bool PassarAdiante(Pedido pedido)
  {
    if (_proximo == null)
    {
        return true;
    }
    return _proximo.Validar(pedido);
  }
}