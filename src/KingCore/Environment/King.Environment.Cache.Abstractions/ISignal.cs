using Microsoft.Extensions.Primitives;

namespace King.Environment.Cache
{
    public interface ISignal
    {
        IChangeToken GetToken(string key);

        void SignalToken(string key);
    }
}
