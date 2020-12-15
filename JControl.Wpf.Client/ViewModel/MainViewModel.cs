using GalaSoft.MvvmLight;
using JControl.Wpf.Client.Views;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace JControl.Wpf.Client.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private IModule selectedModule;
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (this.Modules.Count > 0)
            {
                this.SelectedModule = this.Modules[0];
            }
        }

        public List<IModule> Modules 
        {
            get 
            {
                return SimpleIoc.Default.GetInstance<List<IModule>>()
                                        .OrderBy(m=>m.Index)
                                        .ToList();
            
            }
        
        }

        public IModule SelectedModule
        {
            get
            {
                return selectedModule;
            }
            set
            {
                if (value != selectedModule)
                {
                    if (selectedModule != null)
                    {
                        selectedModule.Deactivate();
                    }
                    selectedModule = value;
                    this.RaisePropertyChanged("SelectedModule");
                    this.RaisePropertyChanged("UserInterface");
                }
            }
        }



        public Visibility IsShowDialog
        {
            get { return _IsShowDialog; }
            set { Set(ref _IsShowDialog, value); }
        }

        private Visibility _IsShowDialog = Visibility.Hidden;



        public UserControl ShowDialogView
        {
            get { return _ShowDialogView; }
            set 
            { 
                Set(ref _ShowDialogView, value);
                if (value != null)
                    IsShowDialog = Visibility.Visible;
                else
                    IsShowDialog = Visibility.Hidden;
            }
        }

        private UserControl _ShowDialogView = null;



        private RelayCommand<object> _SelectModuleCommand;

        /// <summary>
        /// Gets the SelectModuleCommand.
        /// </summary>
        public RelayCommand<object> SelectModuleCommand
        {
            get
            {
                return _SelectModuleCommand
                    ?? (_SelectModuleCommand = new RelayCommand<object>(
                    p =>
                    {
                        var index =int.Parse(p.ToString());

                        SelectedModule = this.Modules.First(x => x.Index == index);
                    }));
            }
        }
        
        public UserControl UserInterface
        {
            get
            {
                if (SelectedModule == null) return null;
                return SelectedModule.UserInterface;
            }
        }


    }
}