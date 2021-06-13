using System.Windows.Input;

namespace DevFlow.Data.Menu
{
    public class MenuModel
    {
        public int Seq { get; set; }
        public string Name { get; set; }
        public GeoIcon IconType { get; set; }

        public ICommand MenuClickCommand { get; set; }
    }
}
