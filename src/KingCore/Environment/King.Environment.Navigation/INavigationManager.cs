using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace King.Environment.Navigation
{
    public interface INavigationManager
    {
        IEnumerable<MenuItem> BuildMenu(string name, ActionContext context);
    }
}
