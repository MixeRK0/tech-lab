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
		/// Окончания и суффиксы причастий.
		/// </summary>
		public static List<string> EndParticiples = new List<string>()
			{ "ивш","ывш","ующ","ем","нн","вш","вший","ющ","ущи","ющи","ящий","щих","щие" };

		/// <summary>
		/// Окончания и суффиксы деепричастий.
		/// </summary>
		public static List<string> EndDeParticiples = new List<string>()
			{ "ляя","вши","ши","уя","ая","уясь","аясь","яясь","вшись","ав","ев" };

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
			new Tuple<WordType, List<string>>(WordType.De_Participle, EndDeParticiples),
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
		/// Сравнивает слово со списком часто распространённых местоимений
		/// и в случае совпадения возвращает его роль в предложении.
		/// </summary>
		/// <param name="word"></param>
		/// <returns></returns>
		public static bool IsPronoun(string word, out WordType type)
		{
			switch (word)
			{
				// Список местоимений, выступающих подлежащими:
				case "я":
				case "ты":
				case "он":
				case "оно":
				case "мы":
				case "она":
				case "вы":
				case "они":
				case "некто":
				case "никто":
				case "нечто":
				case "ничто":
					type = WordType.PronounSubject;
					return true;

				// Список местоимений, выступающих дополнениями:
				case "мне":
				case "меня":
				case "мной":
				case "мною":
				case "тебе":
				case "тебя":
				case "тобой":
				case "тобою":
				case "ему":
				case "нему":
				case "ей":
				case "ею":
				case "ней":
				case "нам":
				case "нами":
				case "нас":
				case "вам":
				case "вами":
				case "вас":
				case "им":
				case "ним":
				case "себя":
				case "кто":
				case "что":
				case "столько":
				case "некому":
				case "никому":
				case "то":
				case "это":
				case "сам":
				case "сколько":
					type = WordType.PronounAddition;
					return true;

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
				case "тот":
				case "такой":
				case "такого":
				case "таких":
				case "таков":
				case "любой":
				case "всякий":
				case "каждый":
				case "другой":
				case "самый":
				case "иной":
				case "какой":
				case "каков":
				case "чей":
				case "весь":
				case "его":
				case "её":
				case "их":
				case "этот":
				case "эта":
				case "эти":
				case "эту":
				case "этой":
				case "этим":
				case "этих":
					type = WordType.PronounDefinition;
					return true;

				default:
					type = WordType.NotSet;
					return false;
			}
		}

		/// <summary>
		/// Сравнивает слово со списком часто распространённых частиц.
		/// </summary>
		/// <param name="word"></param>
		/// <returns></returns>
		public static bool IsParticle(string word)
		{
			switch (word)
			{
				case "б":
				case "бы":
				case "да":
				case "нет":
				case "давай":
				case "давайте":
				case "пусть":
				case "пускай":
				case "ли":
				case "разве":
				case "неужели":
				case "вон":
				case "вот":
				case "именно":
				case "точно":
				case "ровно":
				case "подлинно":
				case "же":
				case "лишь":
				case "уж":
				case "ведь":
				case "даже":
				case "только":
				case "едва":
				case "вряд":
				case "навряд":
				case "всего":
				case "ещё":
				case "ишь":
				case "всё":
				case "всё-таки":
				case "ну":
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
				if ((word[i] < 'а' || word[i] > 'я') && word[i] != 'ё' && word[i] != '-')
					return WordType.Punctiation;

			// В конце может через дефис добавляться частица "то" или "ка".
			// Эту частицу, если она есть, мы уберём, чтобы не мешала.
			if (word.Length > 3)
			{
				string temp = word.Substring(word.Length - 3);
				if (temp == "-ка" || temp == "-то")
					word = word.Substring(0, word.Length - 3);
			}

			// Сначала прогоним слово через "табличные" функции:
			if (IsPreposition(word))
				return WordType.Preposition;
			if (IsConjuction(word))
				return WordType.Conjunction;
			if (IsPronoun(word, out WordType pronounType))
				return pronounType;
			if (IsParticle(word))
				return WordType.Particle;
			WordType result = WordType.NotSet;

			// После этого будем сравнивать суффиксы и окончания:
			int[] res = new int[8];
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
					else if ((type == WordType.Participle || type == WordType.De_Participle)
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
			for (int i = 0; i < 8; i++)
				if (max < res[i])
				{
					max = res[i];
					result = (WordType)i;
				}
			return result;
		}
	}
}
