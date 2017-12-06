// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation;
using UIKit;
using IO.Swagger.Model;
using ReisekostenNative.Services;

namespace ReisekostenNative.iOS
{
	public partial class BelegeTableViewController : UITableViewController
	{
		public BelegeTableViewController (IntPtr handle) : base (handle)
		{
		}

        List<Beleg> belege = new List<Beleg>();

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            initTableView();
        }

        public void initTableView()
        {
            TableView.RowHeight = UITableView.AutomaticDimension;
            TableView.EstimatedRowHeight = 20;
            TableView.AlwaysBounceVertical = false;
            TableView.RefreshControl = new UIRefreshControl();
            TableView.RefreshControl.ValueChanged += refreshTable;
            UIService.Instance.GetBelege("hugo",(o) => setBelege(o));
        }

        private void refreshTable(object sender, EventArgs e)
        {
            UIService.Instance.GetBelege("hugo", (o) => setBelege(o));
            TableView.RefreshControl.EndRefreshing();
        }

        private void setBelege(Task<List<Beleg>> o)
        {
            belege = o.Result;
            TableView.ReloadData();
            TableView.RefreshControl.EndRefreshing();
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 0;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return belege.Capacity;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return UITableView.AutomaticDimension;
        }

        public override nfloat EstimatedHeight(UITableView tableView, NSIndexPath indexPath)
        {
            return UITableView.AutomaticDimension;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("belege", indexPath);
            if(cell is BelegeTableViewCell) {
                var belegCell = cell as BelegeTableViewCell;
                belegCell.setCellData(belege[indexPath.Row]);
            }
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);
            // Details öffnen
        }
	}
}
