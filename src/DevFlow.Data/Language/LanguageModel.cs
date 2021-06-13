using System.Windows.Input;

namespace DevFlow.Data.Language
{
    public class LanguageModel
    {
        public string Name { get; set; }
        public LanguageType Language { get; set; }
        public ICommand LanguageClickCommand { get; set; }

        public LanguageModel(string name, LanguageType languageType)
        {
            Name = name;
            Language = languageType;
        }
    }
}
