﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BranchSwitcher {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BranchSwitcher.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap About {
            get {
                object obj = ResourceManager.GetObject("About", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Branch {
            get {
                object obj = ResourceManager.GetObject("Branch", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to About.
        /// </summary>
        internal static string ContextMenus_Create_About {
            get {
                return ResourceManager.GetString("ContextMenus_Create_About", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Exit.
        /// </summary>
        internal static string ContextMenus_Create_Exit {
            get {
                return ResourceManager.GetString("ContextMenus_Create_Exit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Explorer.
        /// </summary>
        internal static string ContextMenus_Create_Explorer {
            get {
                return ResourceManager.GetString("ContextMenus_Create_Explorer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Exit {
            get {
                object obj = ResourceManager.GetObject("Exit", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Explorer {
            get {
                object obj = ResourceManager.GetObject("Explorer", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon GreenCheck {
            get {
                object obj = ResourceManager.GetObject("GreenCheck", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to BranchSwitcher.
        /// </summary>
        internal static string ProcessIcon_Display_BranchRoot_Switcher {
            get {
                return ResourceManager.GetString("ProcessIcon_Display_BranchRoot_Switcher", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Another instance of the BranchSwitcher is already running.  Please exit that before starting this..
        /// </summary>
        internal static string Program_Main_Another_instance_of_the_BranchSwitcher_is_already_running___Please_exit_that_before_starting_this_ {
            get {
                return ResourceManager.GetString("Program_Main_Another_instance_of_the_BranchSwitcher_is_already_running___Please_e" +
                        "xit_that_before_starting_this_", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon SystemTrayApp {
            get {
                object obj = ResourceManager.GetObject("SystemTrayApp", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
    }
}
