using DevExpress.Persistent.Base.General;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChangedDemoProject.Module.BusinessObjects
{
    public interface IHiearchyCode : ITreeNode, ISortedObject, IXPReceiveOnChangedFromArbitrarySource
    {
        string HierarchyCode { get; }

    }
}
