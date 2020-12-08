namespace NewWebApp.Analysis
{
	/// <summary>
	/// Названия частей речи.
	/// </summary>
	public enum WordType
	{
		Adjective, // прилагательное
		Participle, // (дее)причастие
		Verb, // глагол
		Noun, // существительное
		Adverb, // наречие
		Numeral, // числительное
		Conjunction, // союз
		Preposition, // предлог
		Pronoun, // местоимение

		NotSet,
		Punctiation
	}

	public class WordTypeHelper
	{
		/// <summary>
		/// Получение названия части речи в виде строки.
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static string GetTypeName(WordType type)
		{
			switch (type)
			{
				case WordType.Adjective:
					return "прилагательное";

				case WordType.Participle:
					return "(дее)причастие";

				case WordType.Verb:
					return "глагол";

				case WordType.Noun:
					return "существительное";

				case WordType.Adverb:
					return "наречие";

				case WordType.Numeral:
					return "числительное";

				case WordType.Conjunction:
					return "союз";

				case WordType.Preposition:
					return "предлог";

				case WordType.Pronoun:
					return "местоимение";

				case WordType.Punctiation:
					return "пунктуация";

				default:
					return "не определено";
			}
		}
	}
}
