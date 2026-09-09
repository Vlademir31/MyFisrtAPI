
namespace MyFirstAPI.Exceptions
{
    public class ClienteNaoEncontradoException : AppException
    {
        public ClienteNaoEncontradoException(string message) : base(message)
        {
            
        }
    }
}