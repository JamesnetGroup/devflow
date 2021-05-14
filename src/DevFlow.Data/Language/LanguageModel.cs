﻿namespace DevFlow.Data.Language
{
	public class LanguageModel
	{
		public string Name { get; set; }
		public LanguageType Language { get; set; }

		public LanguageModel(string name, LanguageType languageType)
		{
			this.Name = name;
			this.Language = languageType;
		}
	}
}
