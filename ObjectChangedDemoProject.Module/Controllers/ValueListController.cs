using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.TreeListEditors.Win;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.Persistent.Base;
using DevExpress.XtraTreeList.Nodes;
using ObjectChangedDemoProject.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChangedDemoProject.Module.Controllers
{
    public class ValueListController : ViewController<ListView>
    {

        public SimpleAction RenumerateAction { get; }

        public ValueListController()
        {
            RenumerateAction = new SimpleAction(this, nameof(RenumerateAction), PredefinedCategory.Edit);
            RenumerateAction.Id = "RenumerateSortOrder";
            RenumerateAction.Caption = "Renumerate";
            RenumerateAction.Execute += RenumerateAction_Execute;
            RegisterActions(RenumerateAction);
        }

        private void RenumerateAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            GridListEditor gridEditor = View.Editor as GridListEditor;
            TreeListEditor editor = View.Editor as TreeListEditor;
            if ((gridEditor != null && gridEditor.GridView.ActiveEditor != null) ||
                (editor != null && editor.TreeList.ActiveEditor != null)) return;

            RenumerateCore();

            if (editor != null)
            {
                foreach (TreeListNode rootNode in editor.TreeList.Nodes)
                {
                    ClearSelection(rootNode);
                }
            }

            if (gridEditor != null)
            {
                for (int i = 0; i < gridEditor.GridView.RowCount; i++)
                {
                    int rowHandle = gridEditor.GridView.GetRowHandle(i);
                    gridEditor.GridView.UnselectRow(rowHandle);
                }
            }

        }

        private void RenumerateCore()
        {
                foreach (DescriptedObjectBase o in View.SelectedObjects)
                {
                    o.SortKey = o.SortKey + 1;
                }
                ObjectSpace.CommitChanges();
        }

        void ClearSelection(TreeListNode node)
        {
            TreeListEditor editor = View.Editor as TreeListEditor;
            if (editor != null)
            {
                editor.TreeList.Selection.Remove(node);
                foreach (TreeListNode i in node.Nodes)
                {
                    ClearSelection(i);
                }
            }
        }

    }
}
