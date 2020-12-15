using System.Collections.Generic;

namespace NewWebApp.Analysis
{
	public class SyntaxAnalyser
	{
		/// <summary>
		/// Падежные окончания существительных.
		/// </summary>
		public static List<string> Ends = new List<string>()
			{ "ом", "ем", "ой", "ей", "ою", "ею", "у", "ю", "ии",
			"ия", "ям", "ях", "ями", "ью", "ов", "ам", "ами", "ах" };

		/// <summary>
		/// Определение роли слова в предложении.
		/// </summary>
		/// <param name="word"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public static string GetSyntaxType(string word, WordType type)
		{
			// Сначала попытаемся определить член предложения "в лоб" -
			// основываясь на определённой части речи
			switch (type)
			{
				// Все прилагательные и причастия
				// определяются как определения:
				case WordType.Adjective:
				case WordType.Participle:
				case WordType.PronounDefinition:
					return "определение";

				// Все наречия и деепричастия
				// определяются как определения:
				case WordType.Adverb:
				case WordType.De_Participle:
					return "обстоятельство";

				// Все глаголы определяем как сказуемые:
				case WordType.Verb:
					return "сказуемое";

				// местоимение-подлежащее
				case WordType.PronounSubject:
					return "подлежащее";

				// местоимение-дополнение
				case WordType.PronounAddition:
					return "дополнение";

				// Пока что нам не удаётся определить роль числительного в предложении :(
				case WordType.Numeral:
					return "не определено";

				// Предлоги, союзы, частицы и пунктуация не опознаются!
				case WordType.Conjunction:
				case WordType.Preposition:
				case WordType.Particle:
				case WordType.Punctiation:
					return "не является";

				// Если не удалось определить часть речи,
				// то невозможно определить роль в предложении!
				case WordType.NotSet:
					return "не определено";

				// Сюда попадают только существительные,
				// которые нужно разбирать подробно:
				default:
					break;
			}

			// Если слово было определено как существительное,
			// пытаемся вручную определить его роль в приложении:

			int len_word = word.Length; // зафиксируем длину слова
			foreach (var item in Ends)
			{
				if (word.Substring(len_word - item.Length) == item)
					return "дополнение";
			}
			return "подлежащее";
		}
	}
}
