using System.Collections.Generic;
using System.Threading.Tasks;

namespace King.Security.Services
{
    public interface IRoleProvider
    {
        Task<IEnumerable<string>> GetRoleNamesAsync();
    }

}
