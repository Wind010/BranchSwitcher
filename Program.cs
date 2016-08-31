using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace BranchSwitcher
{
	/// <summary>
	/// 
	/// </summary>
	static class Program
	{

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

		    try
		    {
                if (CheckExistingProcess() != null)
                {
                    MessageBox.Show(Resources.Program_Main_Another_instance_of_the_BranchSwitcher_is_already_running___Please_exit_that_before_starting_this_);
                    return;
                }

                List <BranchConfig> branchConfigs = Initialize();

                // Show the system tray icon.					
                using (var pi = new ProcessIcon(branchConfigs))
                {
                    pi.Display();

                    // Make sure the application runs!
                    Application.Run();
                }
		    }
		    catch (Exception ex)
		    {
		        MessageBox.Show(ex.ToString());
		    }
		}


        /// <summary>
        /// Initialize the application by loading settings from app.config.
        /// </summary>
        /// <returns><see cref="List{BranchConfig}"/> </returns>
	    public static List<BranchConfig> Initialize()
	    {
	        var branchConfigs = new List<BranchConfig>();

	        foreach (string key in ConfigurationManager.AppSettings.AllKeys)
	        {
                string[] branchRootAndLeafPath = ConfigurationManager.AppSettings[key].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                BranchConfig branchConfig = null;

	            if (branchRootAndLeafPath.Length > 1)
	            {
	                branchConfig = new BranchConfig(key, branchRootAndLeafPath[0], branchRootAndLeafPath[1]);
	            }
	            else
	            {
                    branchConfig = new BranchConfig(key, branchRootAndLeafPath[0], string.Empty);
	            }

	            branchConfigs.Add(branchConfig);
	        }

	        return branchConfigs;
	    }


        /// <summary>
        /// Check if this application is already running and return the process if it is.
        /// </summary>
        /// <returns><see cref="Process"/> </returns>
        public static Process CheckExistingProcess()
        // Returns a System.Diagnostics.Process pointing to
        // a pre-existing process with the same name as the
        // current one, if any; or null if the current process
        // is unique.
        {
            var curr = Process.GetCurrentProcess();
            Process[] procs = Process.GetProcessesByName(curr.ProcessName);
            foreach (Process p in procs)
            {
                if ((p.Id != curr.Id) && (p.MainModule.FileName == curr.MainModule.FileName))
                    return p;
            }

            return null;
        }



	}
}