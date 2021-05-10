using System;
using System.Collections.Generic;
using System.Windows.Controls;
using DevFlow.Controls;
using DevFlow.Data;
using DevFlow.Wallpaper.Helper;
using DevFlow.Windowbase.Mvvm;

namespace DevFlow.Wallpaper.ViewModels
{
    public class HistoryViewModel : ObservableObject
    {
        private List<HistoryModel> _histories;
        private HistoryImageManager _imgLoader;
        private HistoryModel _currentImage;

        #region . Histories .

        public List<HistoryModel> Histories
        {
            get { return _histories; }
            set { _histories = value; OnPropertyChanged(); }
        }
        #endregion

        #region . CurrentImage .

        public HistoryModel CurrentImage
        {
            get { return _currentImage; }
            set { _currentImage = value; OnPropertyChanged(); ImageSelected(value); }
        }
        #endregion

        #region . Constructor .

        public HistoryViewModel()
        {
            _imgLoader = HistoryImageManager.Instance;
        }
        #endregion

        #region . OnLoaded . 

        protected override void OnLoaded(UserControl view)
        {
            Histories = _imgLoader.GetHistories(Environment.CurrentDirectory);
            _imgLoader.ThumbnailLoadAsync(Histories);

            if (view is View v)
            {
                v.Minimizing = Minimizing;
            }
        }
        #endregion

        private void Minimizing(View obj)
        {
            if (obj.Parent is Grid grid)
            {
                grid.Children.Remove(obj);
            }

            int.TryParse("", out int num);
        }

        #region . OnInitDesignTime .

        protected override void OnInitDesignTime()
        {
            base.OnInitDesignTime();
        }
        #endregion

        #region . ImageSelected . 

        private void ImageSelected(HistoryModel value)
        {
            _imgLoader.PreviewLoadAsync(value);
        }
        #endregion
    }
}
