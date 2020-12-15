using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NewWebApp.Analysis
{
	public class TextAnalyser
	{
		public static List<Tuple<string, string, string>> Analyse(string text)
		{
			List<Tuple<string, string, string>> result = new List<Tuple<string, string, string>>();

			// Разбиваем полученную строку на слова:
			string pattern = @"(\w+(-\w+)?)(.|,|!|\?|;|:)?";
			MatchCollection matches = Regex.Matches(text, pattern);

			// Строка могла быть пустой, из-за чего делаем проверку:
			if (matches.Count > 0)
			{
				for (int i = 0; i < matches.Count; i++)
				{
					// Вытаскиваем найденное слово:
					string word = matches[i].Groups[1].Value;
					string type = WordTypeHelper.GetTypeName(WordAnalyser.GetWordType(word)); // получаем часть речи
					string syntax = SyntaxAnalyser.GetSyntaxType(word, WordAnalyser.GetWordType(word)); // получаем роль в предложении
					result.Add(Tuple.Create(word, type, syntax)); // добавляем в список

					// Вытаскиваем знак пунктуации после слова, если он есть:
					word = matches[i].Groups[3].Value;
					word = word.Replace(" ", "").Replace("\r", "");
					if (word != "")
					{
						type = WordTypeHelper.GetTypeName(WordAnalyser.GetWordType(word)); // получаем часть речи
						syntax = SyntaxAnalyser.GetSyntaxType(word, WordAnalyser.GetWordType(word)); // получаем роль в предложении
						result.Add(Tuple.Create(word, type, syntax)); // добавляем в список
					}
				}
			}

			return result;
		}
	}
}
