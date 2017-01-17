using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChangedDemoProject.Module.BusinessObjects
{
    public interface IValueListItem
    {
        string Name { get; set; }
        string Expression { get; set; }
        //string SortKey { get; }

        //object MatchObject { get; }
    }
}
