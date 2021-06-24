using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DevFlow.Foundation.Mvvm
{
	public class ObservableData : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
