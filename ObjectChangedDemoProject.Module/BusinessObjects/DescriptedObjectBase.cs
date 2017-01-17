using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChangedDemoProject.Module.BusinessObjects
{
    [NonPersistent]
    [OptimisticLocking(false)]
    public abstract class DescriptedObjectBase : DemoObjectBase, INamedObject, ISortedObject
    {
        protected DescriptedObjectBase(Session session) : base(session)
        {
        }

        private string name;
        [Size(100)]
        [ModelDefault("Caption", "Name")]
        [RuleRequiredField]
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                SetPropertyValue("Name", ref name, value);
            }
        }

        private string description;
        [Size(SizeAttribute.Unlimited)]
        [ModelDefault("Caption", "Description")]
        [ModelDefault(nameof(IModelMember.RowCount), "3")]
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                SetPropertyValue("Description", ref description, value);
            }
        }

        private int sortKey;
        [ModelDefault("Caption", "Id")]
        [ModelDefault(nameof(IModelMember.AllowEdit), "False")]
        public int SortKey
        {
            get
            {
                return sortKey;
            }

            set
            {
                SetPropertyValue(nameof(SortKey), ref sortKey, value);
            }
        }
    }
}
