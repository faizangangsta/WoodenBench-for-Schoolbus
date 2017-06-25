/*
 * NPinyin包含一个公开类Pinyin，该类实现了取汉字文本首字母、文本对应拼音、以及
 * 获取和拼音对应的汉字列表等方法。由于汉字字库大，且多音字较多，因此本组中实现的
 * 拼音转换不一定和词语中的字的正确读音完全吻合。但绝大部分是正确的。
 * 汪思言 2012年7月23日晚 
 */

using System.Text;
namespace WoodenBench_Desktop.staClass.Pinyin
{
    public static class Pinyin
	{
		public static string GetInitials(string text)
		{
			text = text.Trim();
			StringBuilder chars = new StringBuilder();
			for (var i = 0; i < text.Length; ++i)
			{
				string py = GetPinyin(text[i]);
				if (py != "") chars.Append(py[0]);
			}

			return chars.ToString().ToUpper();
		}
		public static string GetInitials(string text, Encoding encoding)
		{
			string temp = ConvertEncoding(text, encoding, Encoding.UTF8);
			return ConvertEncoding(GetInitials(temp), Encoding.UTF8, encoding);
		}
		public static string GetPinyin(string text)
		{
			StringBuilder sbPinyin = new StringBuilder();
			for (var i = 0; i < text.Length; ++i)
			{
				string py = GetPinyin(text[i]);
				if (py != "") sbPinyin.Append(py);
				sbPinyin.Append(" ");
			}

			return sbPinyin.ToString().Trim();
		}
		public static string GetPinyin(string text, Encoding encoding)
		{
			string temp = ConvertEncoding(text.Trim(), encoding, Encoding.UTF8);
			return ConvertEncoding(GetPinyin(temp), Encoding.UTF8, encoding);
		}
		public static string GetChineseText(string pinyin)
		{
			string key = pinyin.Trim().ToLower();
			foreach (string str in PyCode.codes)
			{
				if (str.StartsWith(key + " ") || str.StartsWith(key + ":"))
					return str.Substring(7);
			}
            			return "";
		}
		public static string GetChineseText(string pinyin, Encoding encoding)
		{
			string text = ConvertEncoding(pinyin, encoding, Encoding.UTF8);
			return ConvertEncoding(GetChineseText(text), Encoding.UTF8, encoding);
		}
		public static string GetPinyin(char ch)
		{
			short hash = GetHashIndex(ch);
			for (var i = 0; i < PyHash.hashes[hash].Length; ++i)
			{
				short index = PyHash.hashes[hash][i];
				var pos = PyCode.codes[index].IndexOf(ch, 7);
				if (pos != -1)
					return PyCode.codes[index].Substring(0, 6).Trim();
			}
			return ch.ToString();
		}
		/// <summary>
		/// 返回单个字符的汉字拼音
		/// </summary>
		/// <param name="ch">编码为encoding的中文字符</param>
		/// <returns>编码为"encoding"的"ch"对应的拼音</returns>
		public static string GetPinyin(char ch, Encoding encoding)
		{
			ch = ConvertEncoding(ch.ToString(), encoding, Encoding.UTF8)[0];
			return ConvertEncoding(GetPinyin(ch), Encoding.UTF8, encoding);
		}
		public static string ConvertEncoding(string text, Encoding srcEncoding, Encoding dstEncoding)
		{
			byte[] srcBytes = srcEncoding.GetBytes(text);
			byte[] dstBytes = Encoding.Convert(srcEncoding, dstEncoding, srcBytes);
			return dstEncoding.GetString(dstBytes);
		}
		/// <summary>
		/// 取文本索引值
		/// </summary>
		/// <param name="ch">字符</param>
		/// <returns>文本索引值</returns>
		private static short GetHashIndex(char ch)
		{
			return (short)((uint)ch % PyCode.codes.Length);
		}
	}
}
