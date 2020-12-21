namespace NewWebApp.Analysis
{
	/// <summary>
	/// Названия частей речи.
	/// </summary>
	public enum WordType
	{
		Adjective, // прилагательное
		Participle, // причастие
		De_Participle, // деепричастие
		Verb, // глагол
		Noun, // существительное
		Adverb, // наречие
		Numeral, // числительное
		Conjunction, // союз
		Preposition, // предлог

		PronounSubject, // местоимение-подлежащее
		PronounDefinition, // местоимение-определение
		PronounAddition, // местоимение-дополнение

		Particle, // частица

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
					return "причастие";

				case WordType.De_Participle:
					return "деепричастие";

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

				case WordType.PronounAddition:
				case WordType.PronounDefinition:
				case WordType.PronounSubject:
					return "местоимение";

				case WordType.Particle:
					return "частица";

				case WordType.Punctiation:
					return "пунктуация";

				default:
					return "не определено";
			}
		}
	}
}
