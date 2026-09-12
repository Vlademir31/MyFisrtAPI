namespace MyFirstAPI.Exceptions
{
    public class FuncionarioNaoEncontradoException : AppException
    {
        public FuncionarioNaoEncontradoException(string mesage) : base(mesage)
        {
            
        }
    }
}