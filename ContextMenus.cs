using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using BranchSwitcher.Properties;

namespace BranchSwitcher
{
	/// <summary>
	/// 
	/// </summary>
	class ContextMenus
	{
        private ContextMenuStrip menu = new ContextMenuStrip();

        /// <summary>
        /// Is the About box displayed?
        /// </summary>
        bool _isAboutLoaded = false;


        private readonly List<BranchConfig> _branchConfigs = new List<BranchConfig>();


	    public ContextMenus(List<BranchConfig> branchConfigs)
	    {
	        _branchConfigs = branchConfigs;
	    }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns><see cref="ContextMenuStrip"/> </returns>
        public ContextMenuStrip Create()
		{
			// Add the default menu options.
			menu = new ContextMenuStrip();

            string currentBranchRoot = Environment.GetEnvironmentVariable(Constants.BranchRoot);
            string currentBranchLeafPath = Environment.GetEnvironmentVariable(Constants.BranchLeafPath);

            ToolStripMenuItem item;
		    foreach (BranchConfig branchConfig in _branchConfigs)
		    {
                // Branches
                item = new ToolStripMenuItem { Text = branchConfig.Name, ToolTipText = branchConfig.FullPath};
                item.Click += new EventHandler(BranchConfig_Click);
                item.Image = Resources.Branch;
                menu.Items.Add(item);

                // If branchConfig is currently set, then set the check icon.
                if (branchConfig.BranchRoot.Equals(currentBranchRoot, StringComparison.OrdinalIgnoreCase) &&
                    branchConfig.BranchLeafPath.Equals(currentBranchLeafPath, StringComparison.OrdinalIgnoreCase))
                {
                    item.Image = Resources.GreenCheck.ToBitmap();
                }
		    }

		    // Windows Explorer.
			item = new ToolStripMenuItem {Text = Resources.ContextMenus_Create_Explorer};
		    item.Click += new EventHandler(Explorer_Click);
            item.Image = Resources.Explorer;
			menu.Items.Add(item);

			// About.
			item = new ToolStripMenuItem {Text = Resources.ContextMenus_Create_About};
		    item.Click += new EventHandler(About_Click);
			item.Image = Resources.About;
			menu.Items.Add(item);

			// Separator.
			var sep = new ToolStripSeparator();
			menu.Items.Add(sep);

			// Exit.
			item = new ToolStripMenuItem {Text = Resources.ContextMenus_Create_Exit};
		    item.Click += new System.EventHandler(Exit_Click);
			item.Image = Resources.Exit;
			menu.Items.Add(item);

			return menu;
		}


        /// <summary>
        /// Handles the Click event of the Explorer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> Instance containing the event data.</param>
        void BranchConfig_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;

            // Reset to default icons (unselected branch).
            foreach (ToolStripItem tsmi in menu.Items)
            {
                // We should only reset the icons for the branches.
                if (tsmi.GetType() == typeof(ToolStripMenuItem))
                {
                    tsmi.Image = Resources.Branch;
                }
            }
            
            item.Image = Resources.GreenCheck.ToBitmap();

            string branchName = string.Empty;

            foreach (BranchConfig branchConfig in _branchConfigs)
            {
                if (item == null)
                {
                    throw new Exception("No matching branch name loaded.");
                }

                if (branchConfig.Name.Equals(item.Text, StringComparison.OrdinalIgnoreCase))
                {
                    // The SetEnvironmentVariable takes too long and can be fixed setting unmanaged flags, but I go this route:
                    branchConfig.SetBranchAsync();
                    branchName = branchConfig.Name;
                }
            }

            string msg = string.Format("Branch set to:  {0}{1}Remember to close and re-open applications that you expect to take this branch switch.",
                branchName, Environment.NewLine);

            ShowNotification(msg, 5);
        }


        /// <summary>
        /// Handles the Click event of the Explorer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Explorer_Click(object sender, EventArgs e)
		{
			Process.Start("explorer", null);
		}


		/// <summary>
		/// Handles the Click event of the About control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void About_Click(object sender, EventArgs e)
		{
			if (!_isAboutLoaded)
			{
				_isAboutLoaded = true;
				new AboutBox().ShowDialog();
				_isAboutLoaded = false;
			}
		}


		/// <summary>
		/// Processes a menu item.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void Exit_Click(object sender, EventArgs e)
		{
			// Quit without further ado.
			Application.Exit();
		}


        /// <summary>
        /// Show notification.
        /// </summary>
        /// <param name="msg">string</param>
        /// <param name="displaySeconds">short</param>
        private void ShowNotification(string msg, short displaySeconds)
        {
            var notification = new NotifyIcon()
            {
                Visible = true,
                Icon = System.Drawing.SystemIcons.Information,
                BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info,
                BalloonTipTitle = Constants.BranchSwitcher,
                BalloonTipText = msg
            };

            notification.ShowBalloonTip(displaySeconds);

            // Remove the icon after the balloon tip is closed.
            notification.BalloonTipClosed += (sender, e) => {
                var thisIcon = (NotifyIcon)sender;
                thisIcon.Visible = false;
                thisIcon.Dispose();
            };
        }



	}
}