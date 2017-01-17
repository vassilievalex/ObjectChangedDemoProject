using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using ObjectChangedDemoProject.Module.BusinessObjects;

namespace ObjectChangedDemoProject.Module.DatabaseUpdate
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
    public class Updater : ModuleUpdater
    {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion)
        {
        }
        public override void UpdateDatabaseBeforeUpdateSchema()
        {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();

            createValueList();
            ObjectSpace.CommitChanges(); //Uncomment this line to persist created object(s).
        }

        private void createValueList()
        {
            ValueList valueList = ObjectSpace.FindObject<ValueList>(CriteriaOperator.Parse("Oid is not null"));
            if (valueList == null)
            {
                //valueList
                bool valueListVisible = false;
                bool valueListItemVisible = false;
                for (int i = 0; i <= 100; i++)
                {
                    valueListVisible = !valueListVisible;
                    valueList = ObjectSpace.CreateObject<ValueList>();
                    valueList.Name = "ValueList" + i;
                    valueList.Description = "ValueList" + i;
                    valueList.ForValueListsOnly = valueListVisible;
                    for (int ii = 0; ii <= 10; ii++)
                    {
                        valueListItemVisible = !valueListItemVisible;
                        var valueListItem = ObjectSpace.CreateObject<ValueListItem>();
                        valueListItem.Name = "ValueListItem" + ii;
                        valueListItem.List = valueList;
                        valueListItem.ForValueListsOnly = valueListItemVisible;

                        var valueProperty = ObjectSpace.CreateObject<ValueProperty>();
                        valueProperty.Name = "valueProperty" + ii;
                        valueProperty.List = valueList;

                        /*var iunit = ObjectSpace.CreateObject<Unit>();
                        iunit.Name = "iunit_" + ii;
                        iunit.ShortName = "iunit_" + ii;

                        var iunit1 = ObjectSpace.CreateObject<Unit1>();
                        iunit1.Name = "iunit1_" + ii;
                        iunit1.ShortName = "iunit1_" + ii;

                        var iunit2 = ObjectSpace.CreateObject<Unit2>();
                        iunit2.Name = "iunit2_" + ii;
                        iunit2.ShortName = "iunit2_" + ii;

                        var iunit3 = ObjectSpace.CreateObject<Unit3>();
                        iunit3.Name = "iunit3_" + ii;
                        iunit3.ShortName = "iunit3_" + ii;*/


                    }
                    var unit = ObjectSpace.CreateObject<Unit>();
                    unit.Name = "unit_" + i;
                    unit.ShortName = "unit_" + i;

                    var unit1 = ObjectSpace.CreateObject<Unit1>();
                    unit1.Name = "unit1_" + i;
                    unit1.ShortName = "unit1_" + i;

                    var unit2 = ObjectSpace.CreateObject<Unit2>();
                    unit2.Name = "unit2_" + i;
                    unit2.ShortName = "unit2_" + i;

                    var unit3 = ObjectSpace.CreateObject<Unit3>();
                    unit3.Name = "unit3_" + i;
                    unit3.ShortName = "unit3_" + i;

                }

            }
        }

    }
}
