
/*
*  Warewolf - The Easy Service Bus
*  Copyright 2015 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/


//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Dev2.Help {
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [DebuggerNonUserCode()]
    [CompilerGenerated()]
    public class HelpTextResources {
        
        private static ResourceManager resourceMan;
        
        private static CultureInfo resourceCulture;
        
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal HelpTextResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static ResourceManager ResourceManager {
            get {
                if (ReferenceEquals(resourceMan, null)) {
                    ResourceManager temp = new ResourceManager("Dev2.Help.HelpTextResources", typeof(HelpTextResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You are not authorized to deploy from this server.
        /// </summary>
        public static string DeploySecurityFromUnauthorized {
            get {
                return ResourceManager.GetString("DeploySecurityFromUnauthorized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You are not authorized to deploy to this server.
        /// </summary>
        public static string DeploySecurityToUnauthorized {
            get {
                return ResourceManager.GetString("DeploySecurityToUnauthorized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You are not authorized to connect to this server.
        /// </summary>
        public static string ExplorerSecurityServerUnauthorized {
            get {
                return ResourceManager.GetString("ExplorerSecurityServerUnauthorized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You are authorized to run and debug this resource.
        /// </summary>
        public static string ExplorerSecurityToolTipExecute {
            get {
                return ResourceManager.GetString("ExplorerSecurityToolTipExecute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You are not authorized to open, inspect, run or debug this resource.
        /// </summary>
        public static string ExplorerSecurityToolTipNone {
            get {
                return ResourceManager.GetString("ExplorerSecurityToolTipNone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You are authorized to open and inspect this resource.
        /// </summary>
        public static string ExplorerSecurityToolTipView {
            get {
                return ResourceManager.GetString("ExplorerSecurityToolTipView", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to By Default this group will be able to Edit or Delete this resource. 
        ///To do this they can also View and Execute..
        /// </summary>
        public static string SettingsSecurityResourceHelpContribute {
            get {
                return ResourceManager.GetString("SettingsSecurityResourceHelpContribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to By Default this group will be able to call or execute this workflow..
        /// </summary>
        public static string SettingsSecurityResourceHelpExecute {
            get {
                return ResourceManager.GetString("SettingsSecurityResourceHelpExecute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to To set specific permissions for a resource on this server, select the resource here.
        ///Any permissions applied to this resource will OVERWRITE the server settings above.
        ///By specifying a resource here, it will not inherit permissions from the server (above)..
        /// </summary>
        public static string SettingsSecurityResourceHelpResource {
            get {
                return ResourceManager.GetString("SettingsSecurityResourceHelpResource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to By Default this group will be able to open and view this resource.
        ///Typically this is used by Business Analysts to sign off work and participate in the development process..
        /// </summary>
        public static string SettingsSecurityResourceHelpView {
            get {
                return ResourceManager.GetString("SettingsSecurityResourceHelpView", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to To set resource specific permissions, enter the Windows Group name or &quot;Public&quot; here followed by the system access for that group. 
        ///Permissions are cumulative in nature e.g. If someone is a member of two groups and only one of those groups has Contribute permission, then that member WILL have Contribute permission.
        ///Public is an internal Warewolf group that applies to everyone..
        /// </summary>
        public static string SettingsSecurityResourceHelpWindowsGroup {
            get {
                return ResourceManager.GetString("SettingsSecurityResourceHelpWindowsGroup", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Edit and Delete this workflow.
        /// </summary>
        public static string SettingsSecurityResourceToolTipContribute {
            get {
                return ResourceManager.GetString("SettingsSecurityResourceToolTipContribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Run and Debug this workflow.
        /// </summary>
        public static string SettingsSecurityResourceToolTipExecute {
            get {
                return ResourceManager.GetString("SettingsSecurityResourceToolTipExecute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Click the Ellipsis to add a resource.
        /// </summary>
        public static string SettingsSecurityResourceToolTipResource {
            get {
                return ResourceManager.GetString("SettingsSecurityResourceToolTipResource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Open and inspect this resource.
        /// </summary>
        public static string SettingsSecurityResourceToolTipView {
            get {
                return ResourceManager.GetString("SettingsSecurityResourceToolTipView", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select Windows Group.
        /// </summary>
        public static string SettingsSecurityResourceToolTipWindowsGroup {
            get {
                return ResourceManager.GetString("SettingsSecurityResourceToolTipWindowsGroup", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Administrators can amend security permissions and change server settings.
        ///The local machine Administrators are automatically given this permission.
        ///Giving Public access to this permission is akin to turning security off and is not recommended..
        /// </summary>
        public static string SettingsSecurityServerHelpAdministrator {
            get {
                return ResourceManager.GetString("SettingsSecurityServerHelpAdministrator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to By Default this group will be able to Add New resources, Edit resources and Delete existing resources on this server. 
        ///To do this they can also View and Execute..
        /// </summary>
        public static string SettingsSecurityServerHelpContribute {
            get {
                return ResourceManager.GetString("SettingsSecurityServerHelpContribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to By Default this group will be able to deploy resources off this server..
        /// </summary>
        public static string SettingsSecurityServerHelpDeployFrom {
            get {
                return ResourceManager.GetString("SettingsSecurityServerHelpDeployFrom", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to By Default this group will be able to deploy resources onto this server.
        ///Deploy may mean overwriting existing work and can be done without Contribute privileges..
        /// </summary>
        public static string SettingsSecurityServerHelpDeployTo {
            get {
                return ResourceManager.GetString("SettingsSecurityServerHelpDeployTo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to By Default this group will be able to call or execute resources on this server..
        /// </summary>
        public static string SettingsSecurityServerHelpExecute {
            get {
                return ResourceManager.GetString("SettingsSecurityServerHelpExecute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to By Default this group will be able to open and view resources on the server. 
        ///Typically this is used by Business Analysts to sign off work and participate in the development process..
        /// </summary>
        public static string SettingsSecurityServerHelpView {
            get {
                return ResourceManager.GetString("SettingsSecurityServerHelpView", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to To set server wide permissions for security, enter the Windows Group name or &quot;Public&quot; here followed by the system access for that group. You can click on the ellipsis for help with identifying the correct windows group.
        ///By Default these permissions will permeate all resources on the server, unless specified below in Resource Permissions.
        ///Permissions are cumulative in nature e.g. If someone is a member of two groups and only one of those groups has Contribute permission, then that member WILL have Contribu [rest of string was truncated]&quot;;.
        /// </summary>
        public static string SettingsSecurityServerHelpWindowsGroup {
            get {
                return ResourceManager.GetString("SettingsSecurityServerHelpWindowsGroup", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Amend security and admin tasks.
        /// </summary>
        public static string SettingsSecurityServerToolTipAdministrator {
            get {
                return ResourceManager.GetString("SettingsSecurityServerToolTipAdministrator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Edit, Create and Delete workflows and services.
        /// </summary>
        public static string SettingsSecurityServerToolTipContribute {
            get {
                return ResourceManager.GetString("SettingsSecurityServerToolTipContribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Deploy resources off this server.
        /// </summary>
        public static string SettingsSecurityServerToolTipDeployFrom {
            get {
                return ResourceManager.GetString("SettingsSecurityServerToolTipDeployFrom", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Deploy resources to this server.
        /// </summary>
        public static string SettingsSecurityServerToolTipDeployTo {
            get {
                return ResourceManager.GetString("SettingsSecurityServerToolTipDeployTo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Run and Debug workflows.
        /// </summary>
        public static string SettingsSecurityServerToolTipExecute {
            get {
                return ResourceManager.GetString("SettingsSecurityServerToolTipExecute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Open and inspect resources.
        /// </summary>
        public static string SettingsSecurityServerToolTipView {
            get {
                return ResourceManager.GetString("SettingsSecurityServerToolTipView", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select Windows Group.
        /// </summary>
        public static string SettingsSecurityServerToolTipWindowsGroup {
            get {
                return ResourceManager.GetString("SettingsSecurityServerToolTipWindowsGroup", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You are not authorized to edit this resource.
        /// </summary>
        public static string WorkflowDesignerSecurityToolTipNone {
            get {
                return ResourceManager.GetString("WorkflowDesignerSecurityToolTipNone", resourceCulture);
            }
        }
    }
}
