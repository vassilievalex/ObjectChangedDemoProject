using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChangedDemoProject.Module.BusinessObjects
{

    //[RuleCriteria("ForValueListsOnly=(Not Items is null) or Parent is null")]
    //[RuleCombinationOfPropertiesIsUnique("PropertyNameIsUniqueInObject1", DefaultContexts.Save, "Name, Oid", "Name...")]

    [DefaultClassOptions]
    [ModelDefault("Caption", "ValueList")]
    public class ValueList : DescriptedTreeNodeBase, ITreeNode//, IHasServiceCatalog
    {
        public ValueList(Session session) : base(session)
        {

        }

        [Association, Aggregated]
        [ModelDefault("Caption", "ValueListItem")]
        public XPCollection<ValueListItem> Items
        {
            get { return GetCollection<ValueListItem>("Items"); }
        }


        private bool multiValue;
        public bool MultiValue
        {
            get { return multiValue; }
            set { SetPropertyValue("MultiValue", ref multiValue, value); }
        }



        private ValueList inheritValuesFromList;
        [ModelDefault(nameof(IModelMember.Caption), "InheritValuesFromList")]
        public ValueList InheritValuesFromList
        {
            get { return inheritValuesFromList; }
            set { SetPropertyValue(nameof(InheritValuesFromList), ref inheritValuesFromList, value); }
        }


        public IList<IValueListItem> GetListItems()
        {
            List<IValueListItem> resultList = new List<IValueListItem>();
            if (InheritValuesFromList != null)
                resultList.AddRange(InheritValuesFromList.GetListItems());

            resultList.AddRange(Items.Cast<IValueListItem>());
            return resultList.AsReadOnly();
        }


        private BindingList<IValueListItem> predefinedListItems;

        [VisibleInDetailView(true)]
        [ModelDefault(nameof(IModelMember.Caption), "PredefinedListItems")]
        public BindingList<IValueListItem> PredefinedListItems
        {
            get
            {
                if (predefinedListItems == null /*&& CustomItemsProviderType != null*/)
                {
                    predefinedListItems = new BindingList<IValueListItem>(GetListItems());
                    predefinedListItems.AllowEdit = false;
                    predefinedListItems.AllowNew = false;
                    predefinedListItems.AllowRemove = false;
                }

                return predefinedListItems;
            }
        }

        private ValueList parent;
        [Association]
        public ValueList Parent
        {
            get { return parent; }
            set { SetPropertyValue(nameof(Parent), ref parent, value); }
        }


        [Association, Aggregated, VisibleInDetailView(false)]
        public XPCollection<ValueList> Children => GetCollection<ValueList>(nameof(Children));

        ITreeNode ITreeNode.Parent => Parent;

        IBindingList ITreeNode.Children => Children;

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

        [Association, Aggregated]
        [ModelDefault("Caption", "ValueProperty")]
        public XPCollection<ValueProperty> Properties
        {
            get { return GetCollection<ValueProperty>("Properties"); }
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



        private string desc;
        public string Desc
        {
            get { return desc; }
            set { SetPropertyValue("Description", ref desc, value); }
        }

        private string desc1;
        public string Desc1
        {
            get { return desc1; }
            set { SetPropertyValue("Description1", ref desc1, value); }
        }

        private string desc2;
        public string Desc2
        {
            get { return desc2; }
            set { SetPropertyValue("Description2", ref desc2, value); }
        }

        private string desc3;
        public string Desc3
        {
            get { return desc3; }
            set { SetPropertyValue("Description3", ref desc3, value); }
        }

        private string desc4;
        public string Desc4
        {
            get { return desc4; }
            set { SetPropertyValue("Description4", ref desc4, value); }
        }

        private string desc5;
        public string Desc5
        {
            get { return desc5; }
            set { SetPropertyValue("Description5", ref desc5, value); }
        }

        private string desc6;
        public string Desc6
        {
            get { return desc6; }
            set { SetPropertyValue("Description6", ref desc6, value); }
        }

        private string desc7;
        public string Desc7
        {
            get { return desc7; }
            set { SetPropertyValue("Description7", ref desc7, value); }
        }

        private string desc8;
        public string Desc8
        {
            get { return desc8; }
            set { SetPropertyValue("Description8", ref desc8, value); }
        }

        private string desc9;
        public string Desc9
        {
            get { return desc9; }
            set { SetPropertyValue("Description9", ref desc9, value); }
        }


    }

}
