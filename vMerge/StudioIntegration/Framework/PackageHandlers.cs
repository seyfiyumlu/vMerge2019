
// PackageHandlers.cs - generated by VsctGenerator!
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Input;
using Microsoft.VisualStudio.Shell;

namespace alexbegh.vMerge.StudioIntegration.Framework
{
    partial class PackageHandlers
    {
        #region Inner Classes/Structs
        public class CommandParameters
        {
            public CommandParameters(Guid callerGuid, uint callerId) { CallerGuid = callerGuid; CallerId = callerId; }
            public Guid CallerGuid { get; private set; }
            public uint CallerId { get; private set; }
        }

        public class ChoiceCommandParameters : CommandParameters
        {
            public ChoiceCommandParameters(Guid callerGuid, uint callerId, object selected) : base(callerGuid, callerId) { Selected = selected; }
            public object Selected { get; set; }
        }
        #endregion

        #region Commands
        #region SwitchToSettings
        #region Private
        private ICommand _SwitchToSettings;
        private Func<IEnumerable> _SwitchToSettings_GetList;
        private Func<object> _SwitchToSettings_GetSelectedChoice;
        private OleMenuCommand _SwitchToSettings_OleCommand;
        private readonly ChoiceCommandParameters SwitchToSettings_Args = new ChoiceCommandParameters(GuidList.ToolsMenu.Guid, GuidList.ToolsMenu.SwitchToSettings, null);

        private void SwitchToSettings_CanExecuteChanged(object caller, EventArgs args)
        {
            _SwitchToSettings_OleCommand.Enabled = _SwitchToSettings.CanExecute(SwitchToSettings_Args);
        }

        private void SwitchToSettings_DropDownCombo(object sender, EventArgs e)
        {
            if (e == EventArgs.Empty)
            {
                // We should never get here; EventArgs are required.
                throw (new ArgumentException("EventArgs are required")); // force an exception to be thrown
            }

            OleMenuCmdEventArgs eventArgs = e as OleMenuCmdEventArgs;

            if (eventArgs != null)
            {
                string newChoice = eventArgs.InValue as string;
                IntPtr vOut = eventArgs.OutValue;

                if (vOut != IntPtr.Zero && newChoice != null)
                {
                    throw (new ArgumentException("Invalid parameters")); // force an exception to be thrown
                }
                else if (vOut != IntPtr.Zero)
                {
                    // when vOut is non-NULL, the IDE is requesting the current value for the combo
                    if (_SwitchToSettings_GetSelectedChoice != null)
                        SwitchToSettings_Args.Selected = _SwitchToSettings_GetSelectedChoice();

                    Marshal.GetNativeVariantForObject(SwitchToSettings_Args.Selected != null ? SwitchToSettings_Args.Selected.ToString() : null, vOut);
                }

                else if (newChoice != null)
                {
                    if (_SwitchToSettings_GetList == null)
                        return;

                    var list = _SwitchToSettings_GetList().Cast<object>();
                    var idx = list.Where(item => item.ToString()==newChoice).FirstOrDefault();
                    
                    if (idx!=null)
                    {
                        SwitchToSettings_Args.Selected = idx;
                        if (_SwitchToSettings!=null)
                        {
                            _SwitchToSettings.Execute(SwitchToSettings_Args);
                        }
                    }
                    else
                    {
                        throw (new ArgumentException("Choice not in list")); // force an exception to be thrown
                    }
                }
                else
                {
                    // We should never get here
                    throw (new ArgumentException("Choice must not be null")); // force an exception to be thrown
                }
            }
            else
            {
                // We should never get here; EventArgs are required.
                throw (new ArgumentException("EventArgs are required")); // force an exception to be thrown
            }
        }

        private void SwitchToSettings_GetList(object sender, EventArgs e)
        {
            if ((null == e) || (e == EventArgs.Empty))
            {
                // We should never get here; EventArgs are required.
                throw (new ArgumentNullException("EventArgs are required")); // force an exception to be thrown
            }

            OleMenuCmdEventArgs eventArgs = e as OleMenuCmdEventArgs;

            if (eventArgs != null)
            {
                object inParam = eventArgs.InValue;
                IntPtr vOut = eventArgs.OutValue;

                if (inParam != null)
                {
                    throw (new ArgumentException("Invalid input parameter")); // force an exception to be thrown
                }
                else if (vOut != IntPtr.Zero)
                {
                    if (_SwitchToSettings_GetList != null)
                    {
                        var list = _SwitchToSettings_GetList().Cast<object>().Select(obj => obj.ToString()).ToArray();
                        Marshal.GetNativeVariantForObject(list, vOut);
                    }
                }
                else
                {
                    throw (new ArgumentException("OutParam is required")); // force an exception to be thrown
                }
            }
        }
        #endregion

        public void SetSwitchToSettingsChoiceHandler<Type>(Func<CommandParameters, IEnumerable<Type>> handler)
        {
            _SwitchToSettings_GetList = () => { return handler(SwitchToSettings_Args); };
        }

        public void SetSwitchToSettingsGetSelectedChoiceHandler<Type>(Func<CommandParameters, Type> handler)
        {
            _SwitchToSettings_GetSelectedChoice = () => { return handler(SwitchToSettings_Args); };
        }

        public ICommand SwitchToSettings
        {
            get { return _SwitchToSettings; }
            set
            {
                if (value==_SwitchToSettings)
                    return;

                if (_SwitchToSettings!=null )
                {
                    _SwitchToSettings.CanExecuteChanged -= SwitchToSettings_CanExecuteChanged;
                }
                _SwitchToSettings = value;
                if (_SwitchToSettings!=null )
                {
                    _SwitchToSettings.CanExecuteChanged += SwitchToSettings_CanExecuteChanged;
                    _SwitchToSettings_OleCommand.Enabled = _SwitchToSettings.CanExecute(SwitchToSettings_Args);
                }
            }
        }

        public OleMenuCommand SwitchToSettings_OleMenuCommand
        {
            get { return _SwitchToSettings_OleCommand; }
        }
        #endregion

        #region ShowWorkItemView
        #region Private
        private ICommand _ShowWorkItemView;
        private OleMenuCommand _ShowWorkItemView_OleCommand;
        private readonly CommandParameters ShowWorkItemView_Args = new CommandParameters(GuidList.ToolsMenu.Guid, GuidList.ToolsMenu.ShowWorkItemView);

        private void ShowWorkItemView_CanExecuteChanged(object caller, EventArgs args)
        {
            _ShowWorkItemView_OleCommand.Enabled = _ShowWorkItemView.CanExecute(ShowWorkItemView_Args);
        }

        private void ShowWorkItemView_Invoked(object caller, EventArgs args)
        {
            if (_ShowWorkItemView!=null)
            {
                _ShowWorkItemView.Execute(ShowWorkItemView_Args);
            }
        }
        #endregion

        public ICommand ShowWorkItemView
        {
            get { return _ShowWorkItemView; }
            set
            {
                if (value==_ShowWorkItemView)
                    return;

                if (_ShowWorkItemView!=null )
                {
                    _ShowWorkItemView.CanExecuteChanged -= ShowWorkItemView_CanExecuteChanged;
                }
                _ShowWorkItemView = value;
                if (_ShowWorkItemView!=null )
                {
                    _ShowWorkItemView.CanExecuteChanged += ShowWorkItemView_CanExecuteChanged;
                    _ShowWorkItemView_OleCommand.Enabled = _ShowWorkItemView.CanExecute(ShowWorkItemView_Args);
                }
            }
        }

        public OleMenuCommand ShowWorkItemView_OleMenuCommand
        {
            get { return _ShowWorkItemView_OleCommand; }
        }
        #endregion

        #region ShowChangesetView
        #region Private
        private ICommand _ShowChangesetView;
        private OleMenuCommand _ShowChangesetView_OleCommand;
        private readonly CommandParameters ShowChangesetView_Args = new CommandParameters(GuidList.ToolsMenu.Guid, GuidList.ToolsMenu.ShowChangesetView);

        private void ShowChangesetView_CanExecuteChanged(object caller, EventArgs args)
        {
            _ShowChangesetView_OleCommand.Enabled = _ShowChangesetView.CanExecute(ShowChangesetView_Args);
        }

        private void ShowChangesetView_Invoked(object caller, EventArgs args)
        {
            if (_ShowChangesetView!=null)
            {
                _ShowChangesetView.Execute(ShowChangesetView_Args);
            }
        }
        #endregion

        public ICommand ShowChangesetView
        {
            get { return _ShowChangesetView; }
            set
            {
                if (value==_ShowChangesetView)
                    return;

                if (_ShowChangesetView!=null )
                {
                    _ShowChangesetView.CanExecuteChanged -= ShowChangesetView_CanExecuteChanged;
                }
                _ShowChangesetView = value;
                if (_ShowChangesetView!=null )
                {
                    _ShowChangesetView.CanExecuteChanged += ShowChangesetView_CanExecuteChanged;
                    _ShowChangesetView_OleCommand.Enabled = _ShowChangesetView.CanExecute(ShowChangesetView_Args);
                }
            }
        }

        public OleMenuCommand ShowChangesetView_OleMenuCommand
        {
            get { return _ShowChangesetView_OleCommand; }
        }
        #endregion

        #region ShowVMergeHelp
        #region Private
        private ICommand _ShowVMergeHelp;
        private OleMenuCommand _ShowVMergeHelp_OleCommand;
        private readonly CommandParameters ShowVMergeHelp_Args = new CommandParameters(GuidList.guidRootHelp.Guid, GuidList.guidRootHelp.ShowVMergeHelp);

        private void ShowVMergeHelp_CanExecuteChanged(object caller, EventArgs args)
        {
            _ShowVMergeHelp_OleCommand.Enabled = _ShowVMergeHelp.CanExecute(ShowVMergeHelp_Args);
        }

        private void ShowVMergeHelp_Invoked(object caller, EventArgs args)
        {
            if (_ShowVMergeHelp!=null)
            {
                _ShowVMergeHelp.Execute(ShowVMergeHelp_Args);
            }
        }
        #endregion

        public ICommand ShowVMergeHelp
        {
            get { return _ShowVMergeHelp; }
            set
            {
                if (value==_ShowVMergeHelp)
                    return;

                if (_ShowVMergeHelp!=null )
                {
                    _ShowVMergeHelp.CanExecuteChanged -= ShowVMergeHelp_CanExecuteChanged;
                }
                _ShowVMergeHelp = value;
                if (_ShowVMergeHelp!=null )
                {
                    _ShowVMergeHelp.CanExecuteChanged += ShowVMergeHelp_CanExecuteChanged;
                    _ShowVMergeHelp_OleCommand.Enabled = _ShowVMergeHelp.CanExecute(ShowVMergeHelp_Args);
                }
            }
        }

        public OleMenuCommand ShowVMergeHelp_OleMenuCommand
        {
            get { return _ShowVMergeHelp_OleCommand; }
        }
        #endregion

        #region TargetBranch
        #region Private
        private ICommand _TargetBranch;
        private Func<IEnumerable> _TargetBranch_GetList;
        private OleMenuCommand[] _TargetBranch_OleCommands;
        private readonly ChoiceCommandParameters TargetBranch_Args = new ChoiceCommandParameters(GuidList.MergeContextMenu.Guid, GuidList.MergeContextMenu.TargetBranch, null);
        private List<object> _TargetBranch_List;

        private void TargetBranch_BeforeQueryStatus(object caller, EventArgs args)
        {
            OleMenuCommand menuCommand = caller as OleMenuCommand;
            if (null != menuCommand)
            {
                int itemIndex = menuCommand.CommandID.ID - (int)GuidList.MergeContextMenu.TargetBranch;
                if( itemIndex==0 )
                {
                    _TargetBranch_List.Clear();
                    if (_TargetBranch_GetList!=null)
                    {
                        _TargetBranch_List.AddRange(_TargetBranch_GetList().Cast<object>());
                    }
                }

                if (_TargetBranch_List.Count==0)
                {
                    if (itemIndex==0)
                    {
                        menuCommand.Visible = true;
                        menuCommand.Enabled = false;
                        menuCommand.Text = @"No branches available";
                    }
                    else
                    {
                        menuCommand.Visible = false;
                        menuCommand.Enabled = false;
                    }
                }
                else if (itemIndex >= _TargetBranch_List.Count)
                {
                    menuCommand.Visible = false;
                    menuCommand.Enabled = false;
                }
                else
                {
                    menuCommand.Visible = true;
                    menuCommand.Enabled = true;
                    menuCommand.Text = _TargetBranch_List[itemIndex].ToString();
                }
            }
        }

        private void TargetBranch_Invoked(object caller, EventArgs args)
        {
            if (_TargetBranch!=null)
            {
                OleMenuCommand menuCommand = caller as OleMenuCommand;
                if (null != menuCommand)
                {
                    int itemIndex = menuCommand.CommandID.ID - (int)GuidList.MergeContextMenu.TargetBranch;
                    TargetBranch_Args.Selected = _TargetBranch_List[itemIndex];
                    _TargetBranch.Execute(TargetBranch_Args);
                }
            }
        }
        #endregion

        public void SetTargetBranchChoiceHandler<Type>(Func<CommandParameters, IEnumerable<Type>> handler)
        {
            _TargetBranch_GetList = () => { return handler(TargetBranch_Args); };
        }

        public ICommand TargetBranch
        {
            get { return _TargetBranch; }
            set
            {
                if (value==_TargetBranch)
                    return;

                _TargetBranch = value;
            }
        }
        #endregion

        #region MatchingProfiles
        #region Private
        private ICommand _MatchingProfiles;
        private Func<IEnumerable> _MatchingProfiles_GetList;
        private OleMenuCommand[] _MatchingProfiles_OleCommands;
        private readonly ChoiceCommandParameters MatchingProfiles_Args = new ChoiceCommandParameters(GuidList.MergeContextMenu.Guid, GuidList.MergeContextMenu.MatchingProfiles, null);
        private List<object> _MatchingProfiles_List;

        private void MatchingProfiles_BeforeQueryStatus(object caller, EventArgs args)
        {
            OleMenuCommand menuCommand = caller as OleMenuCommand;
            if (null != menuCommand)
            {
                int itemIndex = menuCommand.CommandID.ID - (int)GuidList.MergeContextMenu.MatchingProfiles;
                if( itemIndex==0 )
                {
                    _MatchingProfiles_List.Clear();
                    if (_MatchingProfiles_GetList!=null)
                    {
                        _MatchingProfiles_List.AddRange(_MatchingProfiles_GetList().Cast<object>());
                    }
                }

                if (_MatchingProfiles_List.Count==0)
                {
                    if (itemIndex==0)
                    {
                        menuCommand.Visible = true;
                        menuCommand.Enabled = false;
                        menuCommand.Text = @"No profiles yet";
                    }
                    else
                    {
                        menuCommand.Visible = false;
                        menuCommand.Enabled = false;
                    }
                }
                else if (itemIndex >= _MatchingProfiles_List.Count)
                {
                    menuCommand.Visible = false;
                    menuCommand.Enabled = false;
                }
                else
                {
                    menuCommand.Visible = true;
                    menuCommand.Enabled = true;
                    menuCommand.Text = _MatchingProfiles_List[itemIndex].ToString();
                }
            }
        }

        private void MatchingProfiles_Invoked(object caller, EventArgs args)
        {
            if (_MatchingProfiles!=null)
            {
                OleMenuCommand menuCommand = caller as OleMenuCommand;
                if (null != menuCommand)
                {
                    int itemIndex = menuCommand.CommandID.ID - (int)GuidList.MergeContextMenu.MatchingProfiles;
                    MatchingProfiles_Args.Selected = _MatchingProfiles_List[itemIndex];
                    _MatchingProfiles.Execute(MatchingProfiles_Args);
                }
            }
        }
        #endregion

        public void SetMatchingProfilesChoiceHandler<Type>(Func<CommandParameters, IEnumerable<Type>> handler)
        {
            _MatchingProfiles_GetList = () => { return handler(MatchingProfiles_Args); };
        }

        public ICommand MatchingProfiles
        {
            get { return _MatchingProfiles; }
            set
            {
                if (value==_MatchingProfiles)
                    return;

                _MatchingProfiles = value;
            }
        }
        #endregion

        #region RefreshBranches
        #region Private
        private ICommand _RefreshBranches;
        private OleMenuCommand _RefreshBranches_OleCommand;
        private readonly CommandParameters RefreshBranches_Args = new CommandParameters(GuidList.MergeContextMenu.Guid, GuidList.MergeContextMenu.RefreshBranches);

        private void RefreshBranches_CanExecuteChanged(object caller, EventArgs args)
        {
            _RefreshBranches_OleCommand.Enabled = _RefreshBranches.CanExecute(RefreshBranches_Args);
        }

        private void RefreshBranches_Invoked(object caller, EventArgs args)
        {
            if (_RefreshBranches!=null)
            {
                _RefreshBranches.Execute(RefreshBranches_Args);
            }
        }
        #endregion

        public ICommand RefreshBranches
        {
            get { return _RefreshBranches; }
            set
            {
                if (value==_RefreshBranches)
                    return;

                if (_RefreshBranches!=null )
                {
                    _RefreshBranches.CanExecuteChanged -= RefreshBranches_CanExecuteChanged;
                }
                _RefreshBranches = value;
                if (_RefreshBranches!=null )
                {
                    _RefreshBranches.CanExecuteChanged += RefreshBranches_CanExecuteChanged;
                    _RefreshBranches_OleCommand.Enabled = _RefreshBranches.CanExecute(RefreshBranches_Args);
                }
            }
        }

        public OleMenuCommand RefreshBranches_OleMenuCommand
        {
            get { return _RefreshBranches_OleCommand; }
        }
        #endregion

        #region TargetBranch2
        #region Private
        private ICommand _TargetBranch2;
        private Func<IEnumerable> _TargetBranch2_GetList;
        private OleMenuCommand[] _TargetBranch2_OleCommands;
        private readonly ChoiceCommandParameters TargetBranch2_Args = new ChoiceCommandParameters(GuidList.OpenChangesetViewContextMenu.Guid, GuidList.OpenChangesetViewContextMenu.TargetBranch2, null);
        private List<object> _TargetBranch2_List;

        private void TargetBranch2_BeforeQueryStatus(object caller, EventArgs args)
        {
            OleMenuCommand menuCommand = caller as OleMenuCommand;
            if (null != menuCommand)
            {
                int itemIndex = menuCommand.CommandID.ID - (int)GuidList.OpenChangesetViewContextMenu.TargetBranch2;
                if( itemIndex==0 )
                {
                    _TargetBranch2_List.Clear();
                    if (_TargetBranch2_GetList!=null)
                    {
                        _TargetBranch2_List.AddRange(_TargetBranch2_GetList().Cast<object>());
                    }
                }

                if (_TargetBranch2_List.Count==0)
                {
                    if (itemIndex==0)
                    {
                        menuCommand.Visible = true;
                        menuCommand.Enabled = false;
                        menuCommand.Text = @"No branches available";
                    }
                    else
                    {
                        menuCommand.Visible = false;
                        menuCommand.Enabled = false;
                    }
                }
                else if (itemIndex >= _TargetBranch2_List.Count)
                {
                    menuCommand.Visible = false;
                    menuCommand.Enabled = false;
                }
                else
                {
                    menuCommand.Visible = true;
                    menuCommand.Enabled = true;
                    menuCommand.Text = _TargetBranch2_List[itemIndex].ToString();
                }
            }
        }

        private void TargetBranch2_Invoked(object caller, EventArgs args)
        {
            if (_TargetBranch2!=null)
            {
                OleMenuCommand menuCommand = caller as OleMenuCommand;
                if (null != menuCommand)
                {
                    int itemIndex = menuCommand.CommandID.ID - (int)GuidList.OpenChangesetViewContextMenu.TargetBranch2;
                    TargetBranch2_Args.Selected = _TargetBranch2_List[itemIndex];
                    _TargetBranch2.Execute(TargetBranch2_Args);
                }
            }
        }
        #endregion

        public void SetTargetBranch2ChoiceHandler<Type>(Func<CommandParameters, IEnumerable<Type>> handler)
        {
            _TargetBranch2_GetList = () => { return handler(TargetBranch2_Args); };
        }

        public ICommand TargetBranch2
        {
            get { return _TargetBranch2; }
            set
            {
                if (value==_TargetBranch2)
                    return;

                _TargetBranch2 = value;
            }
        }
        #endregion


        #endregion

        #region Registration
        public void Register(OleMenuCommandService commandService)
        {
            if (commandService==null)
                throw new ArgumentNullException("commandService");
            {
                var menuCommandID = new CommandID(GuidList.ToolsMenu.Guid, (int)GuidList.ToolsMenu.SwitchToSettings);
                _SwitchToSettings_OleCommand = new OleMenuCommand(SwitchToSettings_DropDownCombo, menuCommandID);
                commandService.AddCommand(_SwitchToSettings_OleCommand);

                CommandID getListCommandID = new CommandID(GuidList.ToolsMenu.Guid, (int)GuidList.ToolsMenu.idVMergeActiveMergeProfileCommandList);
                MenuCommand getListCommand = new OleMenuCommand(new EventHandler(SwitchToSettings_GetList), getListCommandID);
                commandService.AddCommand(getListCommand);
            }

            {
                var menuCommandID = new CommandID(GuidList.ToolsMenu.Guid, (int)GuidList.ToolsMenu.ShowWorkItemView);
                _ShowWorkItemView_OleCommand = new OleMenuCommand(ShowWorkItemView_Invoked, menuCommandID);
                commandService.AddCommand(_ShowWorkItemView_OleCommand);
            }

            {
                var menuCommandID = new CommandID(GuidList.ToolsMenu.Guid, (int)GuidList.ToolsMenu.ShowChangesetView);
                _ShowChangesetView_OleCommand = new OleMenuCommand(ShowChangesetView_Invoked, menuCommandID);
                commandService.AddCommand(_ShowChangesetView_OleCommand);
            }

            {
                var menuCommandID = new CommandID(GuidList.guidRootHelp.Guid, (int)GuidList.guidRootHelp.ShowVMergeHelp);
                _ShowVMergeHelp_OleCommand = new OleMenuCommand(ShowVMergeHelp_Invoked, menuCommandID);
                commandService.AddCommand(_ShowVMergeHelp_OleCommand);
            }

            {
                _TargetBranch_OleCommands = new OleMenuCommand[50];
                _TargetBranch_List = new List<object>();
                for(int idx = 0; idx < 50; ++idx)
                {
                    var menuCommandID = new CommandID(GuidList.MergeContextMenu.Guid, (int)GuidList.MergeContextMenu.TargetBranch + idx);
                    _TargetBranch_OleCommands[idx] = new OleMenuCommand(TargetBranch_Invoked, menuCommandID);
                    _TargetBranch_OleCommands[idx].BeforeQueryStatus += TargetBranch_BeforeQueryStatus;
                    commandService.AddCommand(_TargetBranch_OleCommands[idx]);
                }
            }

            {
                _MatchingProfiles_OleCommands = new OleMenuCommand[50];
                _MatchingProfiles_List = new List<object>();
                for(int idx = 0; idx < 50; ++idx)
                {
                    var menuCommandID = new CommandID(GuidList.MergeContextMenu.Guid, (int)GuidList.MergeContextMenu.MatchingProfiles + idx);
                    _MatchingProfiles_OleCommands[idx] = new OleMenuCommand(MatchingProfiles_Invoked, menuCommandID);
                    _MatchingProfiles_OleCommands[idx].BeforeQueryStatus += MatchingProfiles_BeforeQueryStatus;
                    commandService.AddCommand(_MatchingProfiles_OleCommands[idx]);
                }
            }

            {
                var menuCommandID = new CommandID(GuidList.MergeContextMenu.Guid, (int)GuidList.MergeContextMenu.RefreshBranches);
                _RefreshBranches_OleCommand = new OleMenuCommand(RefreshBranches_Invoked, menuCommandID);
                commandService.AddCommand(_RefreshBranches_OleCommand);
            }

            {
                _TargetBranch2_OleCommands = new OleMenuCommand[50];
                _TargetBranch2_List = new List<object>();
                for(int idx = 0; idx < 50; ++idx)
                {
                    var menuCommandID = new CommandID(GuidList.OpenChangesetViewContextMenu.Guid, (int)GuidList.OpenChangesetViewContextMenu.TargetBranch2 + idx);
                    _TargetBranch2_OleCommands[idx] = new OleMenuCommand(TargetBranch2_Invoked, menuCommandID);
                    _TargetBranch2_OleCommands[idx].BeforeQueryStatus += TargetBranch2_BeforeQueryStatus;
                    commandService.AddCommand(_TargetBranch2_OleCommands[idx]);
                }
            }


        }
        #endregion
    }
}
