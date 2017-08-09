/*
 * NPinyin包含一个公开类Pinyin，该类实现了取汉字文本首字母、文本对应拼音、以及
 * 获取和拼音对应的汉字列表等方法。由于汉字字库大，且多音字较多，因此本组中实现的
 * 拼音转换不一定和词语中的字的正确读音完全吻合。但绝大部分是正确的。
 * 汪思言 2012年7月23日晚 
 */

using System.Text;
namespace WoodenBench.staClass
{
    public static partial class PinYin
    {
        public static string GetInitials(string ChineseString)
        {
            ChineseString = ChineseString.Trim();
            StringBuilder chars = new StringBuilder();
            for (var i = 0; i < ChineseString.Length; ++i)
            {
                string py = GetPinyin(ChineseString[i]);
                if (py != "") chars.Append(py[0]);
            }

            return chars.ToString().ToUpper();
        }

        public static string GetPinyin(string ChineseString)
        {
            StringBuilder sbPinyin = new StringBuilder();
            for (var i = 0; i < ChineseString.Length; ++i)
            {
                string py = GetPinyin(ChineseString[i]);
                if (py != "") sbPinyin.Append(py);
                sbPinyin.Append("_");
            }

            return sbPinyin.ToString().Trim();
        }
        
        public static string GetPinyin(char ChineseChar)
        {
            short hash = GetHashIndex(ChineseChar);
            for (var i = 0; i < hashes[hash].Length; ++i)
            {
                short index = hashes[hash][i];
                var pos = PinYinCode[index].IndexOf(ChineseChar, 7);
                if (pos != -1)
                    return PinYinCode[index].Substring(0, 6).Trim();
            }
            return ChineseChar.ToString();
        }

        private static short GetHashIndex(char ChineseChar)
        {
            return (short)((uint)ChineseChar % PinYinCode.Length);
        }
    }
}
