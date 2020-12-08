using System;
using System.Collections.Generic;

namespace NewWebApp.Analysis
{
	public class WordAnalyser
	{
		#region Комбинации букв для слов
		/// <summary>
		/// Окончания прилагательных.
		/// </summary>
		public static List<string> EndAdjectives = new List<string>()
			{ "ее","ие","ые","ое","ими","ыми","ей","ий","ый","ой","ем","им","ым","ом",
			"его","ого","ему","ому","их","ых","ую","юю","ая","яя","ою","ею" };

		/// <summary>
		/// Окончания и суффиксы причастий и деепричастий.
		/// </summary>
		public static List<string> EndParticiples = new List<string>()
			{ "ивш","ывш","ующ","ем","нн","вш","ющ","ущи","ющи","ящий","щих","щие","ляя" };

		/// <summary>
		/// Окончания глаголов.
		/// </summary>
		public static List<string> EndVerbs = new List<string>()
			{ "ила","ыла","ена","ейте","уйте","ите","или","ыли","ей","уй","ил","ыл","им","ым","ен",
			"ило","ыло","ено","ят","ует","уют","ит","ыт","ены","ить","ыть","ишь","ую","ю","ла","на",
			"ете","йте","ли","й","л","ем","н","ло","ет","ют","ны","ть","ешь","нно" };

		/// <summary>
		/// Окончания существительных.
		/// </summary>
		public static List<string> EndNouns = new List<string>()
			{ "а","ев","ов","ье","иями","ями","ами","еи","ии","и","ией","ей","ой","ий","й","иям","ям",
			"ием","ем","ам","ом","о","у","ах","иях","ях","ы","ь","ию","ью","ю","ия","ья","я","ок","мва",
			"яна","ровать","ег","ги","га","сть","сти","вне" };

		/// <summary>
		/// Окончания наречий.
		/// </summary>
		public static List<string> EndAdverbs = new List<string>()
			{ "чно","еко","соко","боко","роко","имо","мно","жно","жко","ело","тно","льно","здо","зко","шо","хо","но" };

		/// <summary>
		/// Окончания числительных.
		/// </summary>
		public static List<string> EndNumerals = new List<string>()
			{ "чуть","много","мало","еро","вое","рое","еро","сти","одной","двух","рех","еми","яти","ьми","ати",
			"дного","сто","ста","тысяча","тысячи","две","три","одна","умя","тью","мя","тью","мью","тью","одним" };

		/// <summary>
		/// Комбинации для союзов (???)
		/// </summary>
		public static List<string> EndConjunctions = new List<string>()
			{ "более","менее","очень","крайне","скоре","некотор","кажд","други","котор","когд","однак",
			"если","чтоб","хот","смотря","как","также","так","зато","что","или","потом","эт","тог","тоже",
			"словно","ежели","кабы","коли","ничем","чем" };
		#endregion

		public static List<Tuple<WordType, List<string>>> Groups = new List<Tuple<WordType, List<string>>>
		{
			new Tuple<WordType, List<string>>(WordType.Adjective, EndAdjectives),
			new Tuple<WordType, List<string>>(WordType.Participle, EndParticiples),
			new Tuple<WordType, List<string>>(WordType.Verb, EndVerbs),
			new Tuple<WordType, List<string>>(WordType.Noun, EndNouns),
			new Tuple<WordType, List<string>>(WordType.Adverb, EndAdverbs),
			new Tuple<WordType, List<string>>(WordType.Numeral, EndNumerals),
			new Tuple<WordType, List<string>>(WordType.Conjunction, EndConjunctions)
		};

		#region "Табличные" функции проверки
		/// <summary>
		/// Определение, является ли слово предлогом.
		/// </summary>
		/// <param name="word"></param>
		/// <returns></returns>
		public static bool IsPreposition(string word)
		{
			switch (word)
			{
				case "без":
				case "безо":
				case "близ":
				case "в":
				case "во":
				case "вместо":
				case "вне":
				case "для":
				case "до":
				case "за":
				case "из":
				case "изо":
				case "из-за":
				case "из-под":
				case "к":
				case "ко":
				case "кроме":
				case "между":
				case "меж":
				case "на":
				case "над":
				case "о":
				case "об":
				case "обо":
				case "от":
				case "ото":
				case "перед":
				case "передо":
				case "пред":
				case "предо":
				case "по":
				case "под":
				case "подо":
				case "при":
				case "про":
				case "ради":
				case "с":
				case "со":
				case "сквозь":
				case "среди":
				case "у":
				case "через":
				case "чрез":
					return true;

				default:
					return false;
			}
		}

		/// <summary>
		/// Сравнивает слово со списком часто распространённых союзов.
		/// </summary>
		/// <param name="word"></param>
		/// <returns></returns>
		public static bool IsConjuction(string word)
		{
			switch (word)
			{
				case "а":
				case "и":
				case "или":
				case "но":
				case "где":
				case "тоже":
				case "также":
				case "когда":
				case "даже":
				case "как":
				case "либо":
				case "однако":
				case "пока":
				case "потому":
				case "словно":
				case "хотя":
				case "тем":
				case "чем":
				case "чтоб":
				case "чтобы":
					return true;

				default:
					return false;
			}
		}

		/// <summary>
		/// Сравнивает слово со списком часто распространённых местоимений.
		/// </summary>
		/// <param name="word"></param>
		/// <returns></returns>
		public static bool IsPronoun(string word)
		{
			switch (word)
			{
				case "я":
				case "мне":
				case "меня":
				case "мной":
				case "мною":
				case "ты":
				case "тебе":
				case "тебя":
				case "тобой":
				case "тобою":
				case "он":
				case "ему":
				case "нему":
				case "она":
				case "ей":
				case "ею":
				case "ней":
				case "оно":
				case "мы":
				case "нам":
				case "нами":
				case "нас":
				case "вы":
				case "вам":
				case "вами":
				case "вас":
				case "они":
				case "им":
				case "ним":
				case "себя":
				case "мой":
				case "моему":
				case "моей":
				case "моим":
				case "твой":
				case "твоему":
				case "твоей":
				case "твоим":
				case "ваш":
				case "вашему":
				case "вашей":
				case "вашим":
				case "наш":
				case "нашему":
				case "нашей":
				case "нашим":
				case "свой":
				case "его":
				case "её":
				case "их":
				case "то":
				case "это":
				case "тот":
				case "такой":
				case "такого":
				case "таких":
				case "таков":
				case "столько":
				case "весь":
				case "любой":
				case "всякий":
				case "каждый":
				case "сам":
				case "другой":
				case "самый":
				case "иной":
				case "кто":
				case "что":
				case "какой":
				case "каков":
				case "чей":
				case "сколько":
				case "некто":
				case "нечто":
				case "никто":
				case "ничто":
				case "некому":
				case "никому":
					return true;

				default:
					return false;
			}
		}
		#endregion

		/// <summary>
		/// Функция определения части речи.
		/// </summary>
		/// <param name="word"></param>
		/// <returns></returns>
		public static WordType GetWordType(string word)
		{
			// Если это не чисто буквенная комбинация, проверка бессмысленна:
			word = word.ToLower();
			for (var i = 0; i < word.Length; i++)
				if ((word[i] < 'а' || word[i] > 'я') && word[i] != '-')
					return WordType.Punctiation;

			// Сначала прогоним слово через "табличные" функции:
			if (IsPreposition(word))
				return WordType.Preposition;
			if (IsConjuction(word))
				return WordType.Conjunction;
			if (IsPronoun(word))
				return WordType.Pronoun;
			WordType result = WordType.NotSet;

			// После этого будем сравнивать суффиксы и окончания:
			int[] res = new int[7];
			int len_word = word.Length; // зафиксируем длину слова
			foreach (var group in Groups)
			{
				WordType type = group.Item1;
				int index = (int)type;
				foreach (var part in group.Item2)
				{
					int len_part = part.Length; // зафиксируем длину комбинации

					// Проверка окончания (для любой части речи):
					if (len_word >= len_part
						&& word.Substring(len_word - len_part) == part
						&& res[index] < len_part)
					{
						if (word != part)
							res[index] = len_part;
						else
							res[index] = 99;
					}

					// Для (дее)причастия - проверка суффикса и окончания (от 40% и правее от длины слова):
					else if (type == WordType.Participle
						&& word.IndexOf(part) >= Math.Round(0.4 * len_word))
						res[index] = len_part;

					// Для союза - проверяем начало слова:
					else if (type == WordType.Conjunction && len_word >= len_part
						&& word.Substring(0, len_part) == part && res[index] < len_part)
					{
						if (word != part)
							res[index] = len_part;
						else
							res[index] = 99;
					}

					else if (word == part)
						res[index] = 99;
				}
			}

			// Определяем "наиболее подходящую" часть речи:
			int max = 0;
			for (int i = 0; i < 7; i++)
				if (max < res[i])
				{
					max = res[i];
					result = (WordType)i;
				}
			return result;
		}
	}
}
