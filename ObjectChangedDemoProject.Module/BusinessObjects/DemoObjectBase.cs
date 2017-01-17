using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChangedDemoProject.Module.BusinessObjects
{
    [NonPersistent]
    public abstract class DemoObjectBase : BaseObject
    {
        protected DemoObjectBase(Session session) : base(session)
        {
        }


        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        protected override void OnSaving()
        {
            base.OnSaving();
        }

    }
}
