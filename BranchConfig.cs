//-----------------------------------------------------------------------
// <copyright file="BranchConfig.cs" company="Agilysys">
//     Copyright (c) Agilysys Corporation.  All rights reserved.
// </copyright>
// <summary>
//      Class that models the the configuration for the branch.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.IO;

using System.Threading.Tasks;

namespace BranchSwitcher
{

    /// <summary>
    /// Models the configuration for the branch.
    /// </summary>
    public class BranchConfig
    {
        /// <summary>
        /// Branch name.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Branch root i.e. C:\TFS\8.7
        /// </summary>
        public string BranchRoot {get; set;}


        /// <summary>
        /// Sub path - C:\TFS\8.7\[Dev]
        /// </summary>
	    public string BranchLeafPath { get; set; }

        
        /// <summary>
        /// The BranchRoot and BranchLeafPath combined.  Full path to the "BranchRoot".
        /// </summary>
        public string FullPath
        {
            get
            {
                if (String.IsNullOrWhiteSpace(BranchRoot))
                {
                    return string.Empty;
                }

                if (string.IsNullOrWhiteSpace(BranchLeafPath))
                {
                    return BranchRoot;
                }
                else
                {
                    return Path.Combine(BranchRoot, BranchLeafPath);
                }
            }
        }


        public BranchConfig(string branchName, string branchRoot, string branchLeafPath)
        {
            if (String.IsNullOrWhiteSpace(branchName))
            {
                throw new ArgumentNullException("branchName");
            }

            if (String.IsNullOrWhiteSpace(branchRoot))
            {
                throw new ArgumentNullException("branchRoot");
            }

            // BranchLeaf Path can be empty and we assume Main.

            Name = branchName;
            BranchRoot = branchRoot;
            BranchLeafPath = branchLeafPath;
        }


        /// <summary>
        /// Runs the SetBranch method asynchrounously.
        /// </summary>
        public void SetBranchAsync()
        {
            Task task = Task.Run((Action)SetBranch);
        }

        /// <summary>
        /// Sets the environment variable for BranchRoot and BranchLeafPath if defined.
        /// </summary>
        public void SetBranch()
        {

            if (string.IsNullOrEmpty(BranchRoot))
            {
                Environment.SetEnvironmentVariable(Constants.BranchRoot, null, EnvironmentVariableTarget.User);
            }
            else
            {
                Environment.SetEnvironmentVariable(Constants.BranchRoot, BranchRoot, EnvironmentVariableTarget.User);
            }

            if (string.IsNullOrEmpty(BranchLeafPath))
            {
                Environment.SetEnvironmentVariable(Constants.BranchLeafPath, null, EnvironmentVariableTarget.User);
            }
            else
            {
                Environment.SetEnvironmentVariable(Constants.BranchLeafPath, BranchLeafPath, EnvironmentVariableTarget.User);
            }
        }



    }
}
