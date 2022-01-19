using System.Threading.Tasks;

namespace DBook.EmailProviders
{
    public interface IProvider
    {
        Task Send(string from, string to, string body);
    }
}
