using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace HtmlConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = @"&lt;p&gt;替换前，，&lt;/p&gt;&lt;p&gt;hello，，，&lt;/p&gt;&lt;p&gt;替换前，，，，&lt;/p&gt;&lt;p&gt;&lt;br/&gt;&lt;/p&gt;";
            var str1 = @"&lt;p&gt;&lt;em style=&quot;font-size: 1pc;&quot;&gt;&amp;lt;html&amp;gt;&amp;lt;div&amp;gt;&lt;/em&gt;&lt;br/&gt;&lt;/p&gt;";
            #region 方案一
            var convertHtmlOne = NoHTML(str);
            var convertValueOne = ReplaceHtmlTag(convertHtmlOne);
            #endregion
            #region 方案二
            var convertHtmlTwo = System.Web.HttpUtility.HtmlDecode(str);
            var convertValueTwo = ReplaceHtmlTag(convertHtmlTwo);
            #endregion
            #region 方案三
            var convertHtmlThree = System.Web.HttpUtility.HtmlDecode(str1);
            var convertValueThree = ReplaceHtmlTag(convertHtmlThree);
            var sss = System.Web.HttpUtility.HtmlEncode(convertValueThree);
            #endregion
        }
        public static string ReplaceHtmlTag(string html, int length = 0)
        {
            string strText = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
            strText = System.Text.RegularExpressions.Regex.Replace(strText, "&[^;]+;", "");

            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);

            return strText;
        }
        public static string NoHTML(string Htmlstring)
        {

            //删除脚本  &amp;sect;  

            Htmlstring = Htmlstring.Replace("&sect;", "");
            Htmlstring = Htmlstring.Replace("&mdash;", "-");
            Htmlstring = Htmlstring.Replace("&middot;", ".");

            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

            //删除HTML    

            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"([/r/n])[/s]+", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "/", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "/xa1", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "/xa2", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "/xa3", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "/xa9", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&#(/d+);", "", RegexOptions.IgnoreCase);


            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");



            Htmlstring.Replace("/r/n", "");


            return Htmlstring;

        }
    }
}
