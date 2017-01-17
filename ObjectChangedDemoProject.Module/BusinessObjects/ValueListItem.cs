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

    //[RuleCriteria("ForValueListsOnly=false or (Not List is null)")]
    //[RuleCombinationOfPropertiesIsUnique("PropertyNameIsUniqueInObject2", DefaultContexts.Save, "Name, Oid", "Name...")]
    public sealed class ValueListItem : DescriptedObjectBase, IValueListItem//, ISupportsErrorText
    {
        public ValueListItem(Session session)
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

        private string expression;
        [EditorAlias("ExpressionEditor")]
        [RuleRequiredField]
        public string Expression
        {
            get { return expression; }
            set
            {
                SetPropertyValue(nameof(Expression), ref expression, value);
            }
        }


        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (propertyName == nameof(Name) && string.IsNullOrWhiteSpace(Expression))
                Expression = string.Format(CultureInfo.InvariantCulture, "'{0}'", newValue);
        }

        private bool forValueListsOnly;
        [ModelDefault(nameof(IModelMember.Caption), "forValueListsOnly")]
        public bool ForValueListsOnly
        {
            get
            {
                return forValueListsOnly;
            }

            set
            {
                SetPropertyValue(nameof(ForValueListsOnly), ref forValueListsOnly, value);
            }
        }

        private Unit unit;
        public Unit Unit
        {
            get { return unit; }
            set { SetPropertyValue("Unit", ref unit, value); }
        }

        private Unit1 unit1;
        public Unit1 Unit1
        {
            get { return unit1; }
            set { SetPropertyValue("Unit1", ref unit1, value); }
        }

        private Unit2 unit2;
        public Unit2 Unit2
        {
            get { return unit2; }
            set { SetPropertyValue("Unit2", ref unit2, value); }
        }

        private Unit3 unit3;
        public Unit3 Unit3
        {
            get { return unit3; }
            set { SetPropertyValue("Unit3", ref unit3, value); }
        }


    }

}
