using DevFlow.Data;
using DevFlow.History.Helper;
using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace DevFlow.History.ViewModels
{
    public class HistoryViewModel : ObservableObject
    {
        private List<HistoryModel> _histories;
        private ImageLoader _imgLoader;
        private HistoryModel _currentImage;

        public List<HistoryModel> Histories
        {
            get { return _histories; }
            set { _histories = value; OnPropertyChanged(); }
        }
        public HistoryModel CurrentImage
        {
            get { return _currentImage; }
            set { _currentImage = value; OnPropertyChanged(); }
        }
        public override void OnInitDesignTime()
        {
            base.OnInitDesignTime();
        }

        public HistoryViewModel()
        { 
            _imgLoader = ImageLoader.Instance;
        }

        public override void OnLoaded(UserControl view)
        {
            Histories = _imgLoader.GetHistories(Environment.CurrentDirectory);
            _imgLoader.LoadAsync(Histories);
        }
    }
}
