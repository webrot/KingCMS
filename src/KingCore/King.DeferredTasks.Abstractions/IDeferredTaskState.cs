using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace King.DeferredTasks
{
    public interface IDeferredTaskState
    {
        IList<Func<DeferredTaskContext, Task>> Tasks { get; }
    }
}
