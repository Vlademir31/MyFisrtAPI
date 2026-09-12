namespace MyFirstAPI.Exceptions
{
    public class FuncionarioNaoEncontradoException : AppException
    {
        public FuncionarioNaoEncontradoException(string message) : base(message)
        {
            
        }
    }
}