using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MCSwipeTableViewCellBinding;

namespace XamarinDemo
{
    public partial class XamarinDemoViewController : UITableViewController, IUITableViewDelegate
    {
        const int kMCNumItems = 7;
        int nbItems;
        MCSwipeTableViewCell cellToDelete;
        UIAlertView alert;

        static bool UserInterfaceIdiomIsPhone {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public XamarinDemoViewController ()
        {
            nbItems = kMCNumItems;
        }

        public override void DidReceiveMemoryWarning ()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning ();
            
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            this.Title = "Swipe Table View";
            this.NavigationController.NavigationBar.TintColor = UIColor.DarkGray;
            this.NavigationItem.RightBarButtonItem = new UIBarButtonItem (UIBarButtonSystemItem.Refresh, Reload);

            UIView backgroundView = new UIView (new RectangleF (0, 0, 320, 480));
            backgroundView.BackgroundColor = new UIColor (227f / 255f, 227f / 255f, 227f / 255f, 1.0f);
            this.TableView.BackgroundView = backgroundView;         
        }

        public override int NumberOfSections (UITableView tableView)
        {
            return 1;
        }

        public override int RowsInSection (UITableView tableview, int section)
        {
            return nbItems;
        }

        public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
        {
            const string CellIdentifier = "Cell";

            MCSwipeTableViewCell cell = (MCSwipeTableViewCell)tableView.DequeueReusableCell (CellIdentifier);

            if (null == cell) {
                cell = new MCSwipeTableViewCell (UITableViewCellStyle.Subtitle, CellIdentifier);

                if (cell.RespondsToSelector (new MonoTouch.ObjCRuntime.Selector ("setSeparatorInset:"))) {
                    cell.SeparatorInset = UIEdgeInsets.Zero;
                }
                cell.SelectionStyle = UITableViewCellSelectionStyle.Gray;
                cell.ContentView.BackgroundColor = UIColor.White;
            }
            ConfigureCell (cell, indexPath);
            return cell;
        }

        /// #pragma mark - UITableViewDataSource

        void ConfigureCell (MCSwipeTableViewCell cell, NSIndexPath indexPath)
        {

            UIView checkView = ViewWithImageName ("check");
            UIColor greenColor = new UIColor (85.0f / 255.0f, 213.0f / 255.0f, 80.0f / 255.0f, 1.0f);

            UIView crossView = ViewWithImageName ("cross");
            UIColor redColor = new UIColor (232.0f / 255.0f, 61.0f / 255.0f, 14.0f / 255.0f, 1.0f);

            UIView clockView = ViewWithImageName ("clock");
            UIColor yellowColor = new UIColor (254.0f / 255.0f, 217.0f / 255.0f, 56.0f / 255.0f, 1.0f);

            UIView listView = ViewWithImageName ("list");
            UIColor brownColor = new UIColor (206.0f / 255.0f, 149.0f / 255.0f, 98.0f / 255.0f, 1.0f);

            // Setting the default inactive state color to the tableView background color
            cell.DefaultColor = TableView.BackgroundView.BackgroundColor;

//            cell.Delegate = this;

            if ((indexPath.Row % kMCNumItems) == 0) {
                cell.TextLabel.Text = "Switch Mode Cell";
                cell.DetailTextLabel.Text = "Swipe to switch";
                cell.SetSwipeGestureWithView (checkView, greenColor, MCSwipeTableViewCellMode.Switch, MCSwipeTableViewCellState.State1, delegate(MCSwipeTableViewCell c, MCSwipeTableViewCellState state, MCSwipeTableViewCellMode mode) {
                    Console.WriteLine ("Did swipe Checkmark cell");
                });
                cell.SetSwipeGestureWithView (crossView, redColor, MCSwipeTableViewCellMode.Switch, MCSwipeTableViewCellState.State2, delegate(MCSwipeTableViewCell c, MCSwipeTableViewCellState state, MCSwipeTableViewCellMode mode) {
                    Console.WriteLine ("Did swipe Cross cell");
                });
                cell.SetSwipeGestureWithView (clockView, yellowColor, MCSwipeTableViewCellMode.Switch, MCSwipeTableViewCellState.State3, delegate(MCSwipeTableViewCell c, MCSwipeTableViewCellState state, MCSwipeTableViewCellMode mode) {
                    Console.WriteLine ("Did swipe Clock cell");
                });
                cell.SetSwipeGestureWithView (listView, brownColor, MCSwipeTableViewCellMode.Switch, MCSwipeTableViewCellState.State4, delegate(MCSwipeTableViewCell c, MCSwipeTableViewCellState state, MCSwipeTableViewCellMode mode) {
                    Console.WriteLine ("Did swipe List cell");
                });
            } else if ((indexPath.Row % kMCNumItems) == 1) {
                cell.TextLabel.Text = "Exit Mode Cell";
                cell.DetailTextLabel.Text = "Swipe to Delete";
                cell.SetSwipeGestureWithView (crossView, redColor, MCSwipeTableViewCellMode.Exit, MCSwipeTableViewCellState.State1, delegate(MCSwipeTableViewCell c, MCSwipeTableViewCellState state, MCSwipeTableViewCellMode mode) {
                    Console.WriteLine ("Did swipe Cross cell");
                    DeleteCell (cell);
                });
            } else if ((indexPath.Row % kMCNumItems) == 2) {
                cell.TextLabel.Text = "Mixed Mode Cell";
                cell.DetailTextLabel.Text = "Swipe to switch or delete";
                cell.ShouldAnimateIcons = true;
                cell.SetSwipeGestureWithView (checkView, greenColor, MCSwipeTableViewCellMode.Switch, MCSwipeTableViewCellState.State1, delegate(MCSwipeTableViewCell c, MCSwipeTableViewCellState state, MCSwipeTableViewCellMode mode) {
                    Console.WriteLine ("Did swipe Cross cell");
                });
                cell.SetSwipeGestureWithView (crossView, redColor, MCSwipeTableViewCellMode.Exit, MCSwipeTableViewCellState.State2, delegate(MCSwipeTableViewCell c, MCSwipeTableViewCellState state, MCSwipeTableViewCellMode mode) {
                    Console.WriteLine ("Did swipe Cross cell");
                    DeleteCell (cell);
                });
            } else if ((indexPath.Row % kMCNumItems) == 3) {
                cell.TextLabel.Text = "Un-animated Icons";
                cell.DetailTextLabel.Text = "Swipe";
                cell.ShouldAnimateIcons = false;
                cell.SetSwipeGestureWithView (checkView, greenColor, MCSwipeTableViewCellMode.Switch, MCSwipeTableViewCellState.State1, delegate(MCSwipeTableViewCell c, MCSwipeTableViewCellState state, MCSwipeTableViewCellMode mode) {
                    Console.WriteLine ("Did swipe Cross cell");
                });
                cell.SetSwipeGestureWithView (crossView, redColor, MCSwipeTableViewCellMode.Exit, MCSwipeTableViewCellState.State2, delegate(MCSwipeTableViewCell c, MCSwipeTableViewCellState state, MCSwipeTableViewCellMode mode) {
                    Console.WriteLine ("Did swipe Cross cell");
                    DeleteCell (cell);
                });
            } else if ((indexPath.Row % kMCNumItems) == 4) {
                cell.TextLabel.Text = "Right swipe only";
                cell.DetailTextLabel.Text = "Swipe";
                cell.SetSwipeGestureWithView (clockView, yellowColor, MCSwipeTableViewCellMode.Switch, MCSwipeTableViewCellState.State3, delegate(MCSwipeTableViewCell c, MCSwipeTableViewCellState state, MCSwipeTableViewCellMode mode) {
                    Console.WriteLine ("Did swipe Clock cell");
                });
                cell.SetSwipeGestureWithView (listView, brownColor, MCSwipeTableViewCellMode.Switch, MCSwipeTableViewCellState.State4, delegate(MCSwipeTableViewCell c, MCSwipeTableViewCellState state, MCSwipeTableViewCellMode mode) {
                    Console.WriteLine ("Did swipe List cell");
                });
            } else if ((indexPath.Row % kMCNumItems) == 5) {
                cell.TextLabel.Text = "Small triggers";
                cell.DetailTextLabel.Text = "Using 10% and 50%";
                cell.FirstTrigger = 0.1f;
                cell.SecondTrigger = 0.5f;

                cell.SetSwipeGestureWithView (checkView, greenColor, MCSwipeTableViewCellMode.Switch, MCSwipeTableViewCellState.State1, delegate(MCSwipeTableViewCell c, MCSwipeTableViewCellState state, MCSwipeTableViewCellMode mode) {
                    Console.WriteLine ("Did swipe Checkmark cell");
                });
                cell.SetSwipeGestureWithView (crossView, redColor, MCSwipeTableViewCellMode.Exit, MCSwipeTableViewCellState.State2, delegate(MCSwipeTableViewCell c, MCSwipeTableViewCellState state, MCSwipeTableViewCellMode mode) {
                    Console.WriteLine ("Did swipe Cross cell");
                    DeleteCell (cell);
                });
            } else if ((indexPath.Row % kMCNumItems) == 6) {
                cell.TextLabel.Text = "Exit Mode Cell + Confirmation";
                cell.DetailTextLabel.Text = "Swipe to delete";
                cell.SetSwipeGestureWithView (crossView, redColor, MCSwipeTableViewCellMode.Exit, MCSwipeTableViewCellState.State1, delegate(MCSwipeTableViewCell c, MCSwipeTableViewCellState state, MCSwipeTableViewCellMode mode) {
                    Console.WriteLine ("Did swipe Cross cell");
                    cellToDelete = cell;
                    alert = new UIAlertView("Delete?", "Are you sure you want to delete the cell?", null, "No", "Yes");
                    alert.Clicked += delegate(object sender, UIButtonEventArgs e) {
                        var clicked = e.ButtonIndex;
                        if(0 == clicked) {
                            cellToDelete.SwipeToOriginWithCompletion(delegate {
                                Console.WriteLine("Swiped back");
                            });
                            cellToDelete = null;
                        } else {
                            nbItems -= 1;
                            var indexPaths = new NSIndexPath[] { TableView.IndexPathForCell(cellToDelete) };
                            TableView.DeleteRows(indexPaths, UITableViewRowAnimation.Fade);
                            cellToDelete = null;
                        }
                    };
                    alert.Show();
                });

                ;
            }
        }

        float HeightForRowAtIndexPath (UITableView tableView, NSIndexPath indexPath)
        {
            return 70f;
        }

        /// #pragma mark - Table view delegate

        void DidSelectRowAtIndexPath (UITableView tableView, NSIndexPath indexPath)
        {
            var tableViewControler = new XamarinDemoViewController ();
            NavigationController.PushViewController (tableViewControler, true);
        }

        /// #pragma mark - MCSwipeTableViewCellDelegate

        /// When the user starts swiping the cell this method is called
        void SwipeTableViewCellDidStartSwiping (MCSwipeTableViewCell cell)
        {
            Console.WriteLine ("Did start swiping the cell!");
        }

        /// When the user ends swiping the cell this method is called
        void SwipeTableViewCellDidEndSwiping (MCSwipeTableViewCell cell)
        {
            Console.WriteLine ("Did end swiping the cell!");
        }

        /// When the user is dragging, this method is called and return the dragged percentage from the border
        void DidSwipeWithPercentage (MCSwipeTableViewCell cell, float percentage)
        {
            Console.WriteLine ("Did swipe with percentage : {0}", percentage);
        }

        /// #pragma mark - Utils

        void Reload (object sender, System.EventArgs eventArgs)
        {
            nbItems = kMCNumItems;
            TableView.ReloadSections (new NSIndexSet (0), UITableViewRowAnimation.Fade);
        }

        void DeleteCell (MCSwipeTableViewCell cell)
        {
            nbItems -= 1;
            var indexPath = TableView.IndexPathForCell (cell);
            var indexPathArray = new NSIndexPath[1]  { indexPath };
            TableView.DeleteRows (indexPathArray, UITableViewRowAnimation.Fade);
        }

        UIView ViewWithImageName (string imageName)
        {
            var image = UIImage.FromBundle (imageName);
            var imageView = new UIImageView (image);
            imageView.ContentMode = UIViewContentMode.Center;
            return imageView;
        }
    }
}

