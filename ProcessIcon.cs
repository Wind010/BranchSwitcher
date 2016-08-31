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
	class ProcessIcon : IDisposable
	{
		/// <summary>
		/// The NotifyIcon object.
		/// </summary>
		private readonly NotifyIcon _notifyIcon;


        /// <summary>
        /// List of branch configurations
        /// </summary>
        private readonly List<BranchConfig> _branchConfigs = new List<BranchConfig>();

		/// <summary>
		/// Initializes a new instance of the <see cref="ProcessIcon"/> class.
		/// </summary>
        public ProcessIcon(List<BranchConfig> branchConfigs)
		{
            _branchConfigs = branchConfigs;

			// Instantiate the NotifyIcon object.
			_notifyIcon = new NotifyIcon();
		}

		/// <summary>
		/// Displays the icon in the system tray.
		/// </summary>
		public void Display()
		{
			// Put the icon in the system tray and allow it react to mouse clicks.			
			_notifyIcon.MouseClick += new MouseEventHandler(ni_MouseClick);
			_notifyIcon.Icon = Resources.SystemTrayApp;
			_notifyIcon.Text = Resources.ProcessIcon_Display_BranchRoot_Switcher;
			_notifyIcon.Visible = true;

			// Attach a context menu.
			_notifyIcon.ContextMenuStrip = new ContextMenus(_branchConfigs).Create();
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		public void Dispose()
		{
			// When the application closes, this will remove the icon from the system tray immediately.
			_notifyIcon.Dispose();
		}

		/// <summary>
		/// Handles the MouseClick event of the ni control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
		void ni_MouseClick(object sender, MouseEventArgs e)
		{
			// Handle mouse button clicks.
			if (e.Button == MouseButtons.Left)
			{
				// Start Windows Explorer.
				Process.Start("explorer", null);
			}
		}
	}
}