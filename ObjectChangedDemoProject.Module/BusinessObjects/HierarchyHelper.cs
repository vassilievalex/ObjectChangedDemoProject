using DevExpress.Persistent.Base.General;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChangedDemoProject.Module.BusinessObjects
{
    public static class HierarchyHelper
    {
        public static string GetHierarchyCode(IHiearchyCode treeNode)
        {
            List<int> keys = new List<int>();
            for (var node = treeNode; node != null; node = (IHiearchyCode)node.Parent)
            {
                keys.Add(node.SortKey);
            }

            return string.Join(".", keys.Select(k => k.ToString("000")).Reverse().ToArray()).TrimStart('0');
        }

        public static void HandleOnChanged(IHiearchyCode obj, string propertyName)
        {
            switch (propertyName)
            {
                case nameof(ISortedObject.SortKey):
                    RaiseHierarchyCodeChanged(obj);
                    break;
            }
        }

        internal static IBindingList GetChildren(XPBaseObject treeNodeWithCaptionBase)
        {
            return (IBindingList)treeNodeWithCaptionBase.GetMemberValue(nameof(ITreeNode.Children));

        }

        public static void RaiseHierarchyCodeChanged(IHiearchyCode obj)
        {

            if ((obj.Children as XPBaseCollection)?.IsLoaded ?? true)
            {
                foreach (IHiearchyCode child in obj.Children)
                {
                    child.FireChanged(nameof(IHiearchyCode.HierarchyCode));
                    RaiseHierarchyCodeChanged(child);
                }
            }
        }
    }
}
