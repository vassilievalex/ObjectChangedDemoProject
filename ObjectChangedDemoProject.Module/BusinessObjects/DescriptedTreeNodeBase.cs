using DevExpress.ExpressApp.Model;
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
    [NonPersistent]
    public abstract class DescriptedTreeNodeBase : DescriptedObjectBase, ITreeNode, IHiearchyCode
    {
        protected DescriptedTreeNodeBase(Session session) : base(session)
        {
        }

        [NonPersistent]
        [ModelDefault("Caption", "HierarchyCode")]
        public string HierarchyCode => HierarchyHelper.GetHierarchyCode(this);

        protected virtual IBindingList ChildrenCore => HierarchyHelper.GetChildren(this);

        IBindingList ITreeNode.Children => ChildrenCore;


        protected virtual ITreeNode ParentCore
        {
            get
            {
                return (ITreeNode)GetMemberValue(nameof(ITreeNode.Parent));
            }
        }

        ITreeNode ITreeNode.Parent => ParentCore;

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            HierarchyHelper.HandleOnChanged(this, propertyName);
        }

        private void RaiseHierarchyCodeChanged()
        {
            base.OnChanged(nameof(HierarchyCode), null, HierarchyCode);
            HierarchyHelper.RaiseHierarchyCodeChanged(this);
        }

    }

}
