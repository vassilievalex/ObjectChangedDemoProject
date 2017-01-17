using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ObjectChangedDemoProject.Module.BusinessObjects
{
    public class ValueProperty : DescriptedObjectBase
    {
        public ValueProperty(Session session)
            : base(session)
        {
        }

        private ValueList list;
        [Association]
        public ValueList List
        {
            get { return list; }
            set { SetPropertyValue("List", ref list, value); }
        }


    }
}
