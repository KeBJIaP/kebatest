using System.Threading.Tasks;

namespace MaxValues.Common
{
    public interface IMaxValueProvider
    {
        Task<int> Get();
    }
}
