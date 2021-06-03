using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace DevFlow.Windowbase.Mvvm
{
	public class ObservableObject : INotifyPropertyChanged
    {
        private bool _isDesignTimeMode;
        protected Control UIView;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public bool IsDesignTimeMode
        {
            get { return _isDesignTimeMode; }
            set { _isDesignTimeMode = value; OnPropertyChanged(); }
        }

        public ObservableObject()
        {
            OnInitDesignTime();
        }

        protected virtual void OnInitDesignTime()
        {

        }

        protected virtual void OnLoaded(Control view)
        {

        }

        public void ViewRegister(Control view)
        {
            UIView = view;
            if (DesignerProperties.GetIsInDesignMode(view))
            {
                IsDesignTimeMode = true;
                OnInitDesignTime();
            }
            else
            {
                OnLoaded(view);
            }
        }
    }
}
