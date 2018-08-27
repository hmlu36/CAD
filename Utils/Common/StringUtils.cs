using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnet.Utils.Common {
    public static class StringUtils {
        static char[] all_whitespaces = new char[] {
            // SpaceSeparator category
            '\u0020', '\u1680', '\u180E', '\u2000', '\u2001', '\u2002', '\u2003',
            '\u2004', '\u2005', '\u2006', '\u2007', '\u2008', '\u2009', '\u200A',
            '\u202F', '\u205F', '\u3000',
            // LineSeparator category
            '\u2028',
            // ParagraphSeparator category
            '\u2029',
            // Latin1 characters
            '\u0009', '\u000A', '\u000B', '\u000C', '\u000D', '\u0085', '\u00A0',
            // ZERO WIDTH SPACE (U+200B) & ZERO WIDTH NO-BREAK SPACE (U+FEFF)
            '\u200B', '\uFEFF'
        };

        // 全形轉半形對照表
        static Dictionary<string, string> mappingTale = new Dictionary<string, string> {
            {"　",  " "}, {"１",  "1"}, {"２",  "2"}, {"３",  "3"}, {"４",  "4"}, {"５",  "5"}, {"６",  "6"}, {"７",  "7"}, {"８",  "8"}, {"９",  "9"}, {"０",  "0"}, {"＋",  "+"}, {"－",  "-"}, {"＝",  "="},
            {"＼",  "\\"}, {"～",  "~"}, {"！",  "!"}, {"＠",  "@"}, {"＃",  "#"}, {"＄",  "$"}, {"％",  "%"}, {"︿",  "^"}, {"＆",  "&"}, {"＊",  "*"}, {"（",  "("}, {"）",  ")"}, {"＿",  "_"}, {"｜",  "|"},
            {"〔",  "["}, {"〕",  "]"}, {"｛",  "{"}, {"｝",  "}"}, {"；",  ";"}, {"’",  "'"}, {"：",  ":"}, {"”",  "\""}, {"，",  ","}, {"‧",  "."}, {"／",  "/"}, {"＜",  "<"}, {"＞",  ">"}, {"？",  "?"},
            {"ａ",  "a"}, {"ｂ",  "b"}, {"ｃ",  "c"}, {"ｄ",  "d"}, {"ｅ",  "e"}, {"ｆ",  "f"}, {"ｇ",  "g"}, {"ｈ",  "h"}, {"ｉ",  "i"}, {"ｊ",  "j"}, {"ｋ",  "k"}, {"ｌ",  "l"}, {"ｍ",  "m"},
            {"ｎ",  "n"}, {"ｏ",  "o"}, {"ｐ",  "p"}, {"ｑ",  "q"}, {"ｒ",  "r"}, {"ｓ",  "s"}, {"ｔ",  "t"}, {"ｕ",  "u"}, {"ｖ",  "v"}, {"ｗ",  "w"}, {"ｘ",  "x"}, {"ｙ",  "y"}, {"ｚ",  "z"},
            {"Ａ",  "A"}, {"Ｂ",  "B"}, {"Ｃ",  "C"}, {"Ｄ",  "D"}, {"Ｅ",  "E"}, {"Ｆ",  "F"}, {"Ｇ",  "G"}, {"Ｈ",  "H"}, {"Ｉ",  "I"}, {"Ｊ",  "J"}, {"Ｋ",  "K"}, {"Ｌ",  "L"}, {"Ｍ",  "M"},
            {"Ｎ",  "N"}, {"Ｏ",  "O"}, {"Ｐ",  "P"}, {"Ｑ",  "Q"}, {"Ｒ",  "R"}, {"Ｓ",  "S"}, {"Ｔ",  "T"}, {"Ｕ",  "U"}, {"Ｖ",  "V"}, {"Ｗ",  "W"}, {"Ｘ",  "X"}, {"Ｙ",  "Y"}, {"Ｚ",  "Z"}
        };

        public static string EMPTY = "";

        public static string trim(Object str) {
            if (str == null) {
                return null;
            } else {
                return string.IsNullOrEmpty(str.ToString()) ? null : str.ToString().Trim(all_whitespaces);
            }
        }

        public static string trimToNull(Object str) {
            string ts = trim(str);
            return string.IsNullOrEmpty(ts) ? null : ts;
        }

        public static string trimToEmpty(Object str) {
            string ts = trim(str);
            return string.IsNullOrEmpty(ts) ? EMPTY : ts;
        }

        public static int trimToZero(Object str) {
            string ts = trim(str);
            return string.IsNullOrEmpty(ts) ? 0 : Convert.ToInt32(ts);
        }

        public static Decimal trimToDecimal(Object str) {
            string ts = trim(str);
            try {
                return (string.IsNullOrEmpty(ts) || "/".Equals(ts)) ? 0 : Convert.ToDecimal(ts.Replace("%", "").Replace("$", "").Replace("&nbsp;", ""));
            } catch (Exception) {
                return new Decimal(0);
            }
        }

        public static bool TrimIsNull(Object str) {
            return trim(str) == null;
        }

        public static string nvl(string str, string replaceStr) {
            return TrimIsNull(str) ? replaceStr : str;
        }

        public static string GetLast(this string source, int tail_length) {
            if (tail_length >= source.Length) {
                return source;
            }

            return source.Substring(source.Length - tail_length);
        }

        public static bool ContainUnsupportChar(string str) {
            Encoding big5 = Encoding.GetEncoding("big5");
            foreach (char c in str) {
                //強迫轉碼成Big5，看會不會變成問號
                string cInBig5 = big5.GetString(big5.GetBytes(new char[] { c }));

                //原來不是問號，轉碼後變問號，判定為難字，雙引號會將文字段落進行分段處理
                if ((c != '?' && cInBig5 == "?") || c == '”' || c == '\"') {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 轉換為半形數字
        /// </summary>
        public static string ConvertToHalf(this string str) {
            string result = "";
            foreach (char c in str) {
                if (mappingTale.ContainsKey(c.ToString())) {
                    result += c.ToString().Replace(c.ToString(), mappingTale[c.ToString()]);
                } else {
                    result += c.ToString();
                }
            }
            return result;
        }
    }
}