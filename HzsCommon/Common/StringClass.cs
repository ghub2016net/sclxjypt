using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;

namespace HzsCommon
{
    public class StringClass
    {
        public StringClass()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 字符串截取函数
        /// <summary>
        /// 字符串截取函数
        /// </summary>
        /// <param name="inputString">要截取的字符串</param>
        /// <param name="len">要截取的长度</param>
        /// <returns>string</returns>
        /// 
        public static string CutString(string inputString, int len)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }

                try
                {
                    tempString += inputString.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > len)
                    break;
            }
            //如果截过则加上半个省略号 
            //byte[] mybyte = System.Text.Encoding.Default.GetBytes(inputString);
            //if (mybyte.Length > len)
            //    tempString += "…"; 
            return tempString;
        }
        #endregion

        public static double ToDouble(object strValue)
        {
            if (strValue != null)
            {
                if (strValue.ToString() != "")
                {
                    return Convert.ToDouble(strValue);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        #region 生成由日期组成的唯一的文件名
        /// <summary>
        /// 生成由日期组成的唯一的文件名
        /// </summary>
        /// <returns>string</returns>
        /// 
        public static string makeFileName()
        {
            string newFileName;
            string dateName = System.DateTime.Now.ToString("yyyyMMddhhmmss");
            System.Random srd = new Random();
            int srdName = srd.Next(1000);
            newFileName = dateName + srdName.ToString();
            return newFileName;
        }

        public static string makeFileName24()
        {
            return DateTime.Now.Year.ToString() + (DateTime.Now.Month >= 10 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month.ToString()) + (DateTime.Now.Day >= 10 ? DateTime.Now.Day.ToString() : "0" + DateTime.Now.Day.ToString()) + (DateTime.Now.Hour >= 10 ? DateTime.Now.Hour.ToString() : "0" + DateTime.Now.Hour.ToString()) + (DateTime.Now.Minute >= 10 ? DateTime.Now.Minute.ToString() : "0" + DateTime.Now.Minute.ToString()) + (DateTime.Now.Second >= 10 ? DateTime.Now.Second.ToString() : "0" + DateTime.Now.Second.ToString());
        }
        #endregion

        #region 过滤特殊字符
        /// <summary>
        /// 过滤特殊字符
        /// </summary>
        /// <param name="inputStr">字符串</param>
        /// <returns>string</returns>
        public static string cutBadStr(string inputStr)
        {

            //strContent = strContent.Replace("&", "&amp");
            //strContent = strContent.Replace("´", "∵");
            //strContent = strContent.Replace("<", "&lt");
            //strContent = strContent.Replace(">", "&gt");
            //strContent = strContent.Replace("chr(60)", "&lt");
            //strContent = strContent.Replace("chr(37)", "&gt");
            //strContent = strContent.Replace("\"", "&quot"); //不允许使用
            //strContent = strContent.Replace(";", ";");
            //strContent = strContent.Replace("\n", "<br />");
            //strContent = strContent.Replace(" ", "&nbsp");
            //inputStr = inputStr.ToLower().Replace(";", "■");
            inputStr = inputStr.ToLower().Replace("，", "");
            inputStr = inputStr.ToLower().Replace(",", "");
            inputStr = inputStr.ToLower().Replace("'", "");
            inputStr = inputStr.ToLower().Replace("’", "");
            inputStr = inputStr.ToLower().Replace("<", "");
            inputStr = inputStr.ToLower().Replace(">", "");
            //inputStr = inputStr.ToLower().Replace("\n", "<br />");
            //inputStr = inputStr.ToLower().Replace("%", "");
            //inputStr = inputStr.ToLower().Replace(".", "");
            //inputStr = inputStr.ToLower().Replace(":", "");
            //inputStr = inputStr.ToLower().Replace("#", "");
            //inputStr = inputStr.ToLower().Replace("&", "");
            //inputStr = inputStr.ToLower().Replace("$", "");
            //inputStr = inputStr.ToLower().Replace("^", "");
            //inputStr = inputStr.ToLower().Replace("*", "");
            //inputStr = inputStr.ToLower().Replace("`", "");
            //inputStr = inputStr.ToLower().Replace(" ", "");
            //inputStr = inputStr.ToLower().Replace("~", "");
            //inputStr = inputStr.ToLower().Replace("or", "");
            //inputStr = inputStr.ToLower().Replace("and", "");
            return inputStr;
        }
        #endregion

        #region 转换成html
        public static string htmlStr(string strContent)
        {
            //strContent = strContent.Replace(";", "");
            strContent = strContent.ToLower().Replace("■", ",");
            strContent = strContent.ToLower().Replace("∴", "'");
            //strContent = strContent.ToLower().Replace("∴", "’");
            strContent = strContent.Replace("&lt", "<");
            strContent = strContent.Replace("&gt", ">");
            strContent = strContent.Replace("<;", "<");
            strContent = strContent.Replace(">;", ">");
            //strContent = strContent.Replace("■", ";");
            //strContent = strContent.Replace("&amp", "&");
            //strContent = strContent.Replace("&lt","chr(60)");
            //strContent = strContent.Replace("&gt","chr(37)");
            //strContent = strContent.Replace("&quot","\"");
            //strContent = strContent.Replace("<br />","\n");
            //strContent = strContent.Replace("&nbsp"," ");
            return strContent;
        }
        #endregion


        #region 过滤html标记
        /// <summary>
        /// 过滤html标记
        /// </summary>
        /// <param name="HTMLStr">要过滤的字符串</param>
        /// <returns>string</returns>
        /// 

        public static string CutHTML(string strHtml)
        {
            string[] aryReg ={   
                  @"<script[^>]*?>.*?</script>",   
            
                  @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>",   
                  @"([\r\n])[\s]+",   
                  @"&(quot|#34);",   
                  @"&(amp|#38);",   
                  @"&(lt|#60);",   
                  @"&(gt|#62);",     
                  @"&(nbsp|#160);",     
                  @"&(iexcl|#161);",   
                  @"&(cent|#162);",   
                  @"&(pound|#163);",   
                  @"&(copy|#169);",   
                  @"&#(\d+);",   
                  @"-->",   
                  @"<!--.*\n"   
                 };

            string[] aryRep =   {   
                     "",   
                     "",   
                     "",   
                     "\"",   
                     "&",   
                     "<",   
                     ">",   
                     "   ",   
                     "\xa1",//chr(161),   
                     "\xa2",//chr(162),   
                     "\xa3",//chr(163),   
                     "\xa9",//chr(169),   
                     "",   
                     "\r\n",   
                     ""   
                    };

            string newReg = aryReg[0];
            string strOutput = strHtml;
            for (int i = 0; i < aryReg.Length; i++)
            {
                Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);
                strOutput = regex.Replace(strOutput, aryRep[i]);
            }
            strOutput.Replace("<", "");
            strOutput.Replace(">", "");
            strOutput.Replace("\r\n", "");
            return strOutput;
        }
        #endregion

        #region 标题固定长度


        /// <summary>
        /// <table style="font-size:12px">
        /// <tr><td><b>功能描述</b>：填充或截断原始字符串为指定长度 </td></tr>
        /// <tr><td><b>创 建 人</b>： </td></tr>
        /// <tr><td><b>创建时间</b>：</td></tr>
        /// </table>
        /// </summary>
        /// <param name="strOriginal">原始字符串</param>
        /// <param name="maxTrueLength">字符串的字节长度</param>
        /// <param name="chrPad">填充字符</param>
        /// <param name="blnCutTail">字符串的字节长度超过maxTrueLength时截断多余字符</param>
        /// <returns>填充或截断后的字符串</returns>
        static public string PadRightTrueLen(string strOriginal, int maxTrueLength, char chrPad, bool blnCutTail)
        {
            string strNew = strOriginal;

            if (strOriginal == null || maxTrueLength <= 0)
            {
                strNew = "";
                return strNew;
            }

            int trueLen = TrueLength(strOriginal);
            if (trueLen > maxTrueLength)//超过maxTrueLength
            {
                if (blnCutTail)//截断
                {
                    for (int i = strOriginal.Length - 1; i > 0; i--)
                    {
                        strNew = strNew.Substring(0, i);
                        if (TrueLength(strNew) == maxTrueLength)
                            break;
                        else if (TrueLength(strNew) < maxTrueLength)
                        {
                            strNew += chrPad.ToString();
                            break;
                        }
                    }
                }
            }
            else//填充
            {
                for (int i = 0; i < maxTrueLength - trueLen; i++)
                {
                    strNew += chrPad.ToString();
                }
            }

            return strNew;
        }

        //主方法
        public static string CutStringTitle(string inputString, int i)
        {
            return PadRightTrueLen(inputString, i, ' ', true);
        }

        /// <summary>
        /// <table style="font-size:12px">
        /// <tr><td><b>功能描述</b>：字符串的字节长度 </td></tr>
        /// <tr><td><b>创 建 人</b>： </td></tr>
        /// <tr><td><b>创建时间</b>：</td></tr>
        /// </table>
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>字符串的字节长度</returns>
        static public int TrueLength(string str)
        {
            int lenTotal = 0;
            int n = str.Length;
            string strWord = "";
            int asc;
            for (int i = 0; i < n; i++)
            {
                strWord = str.Substring(i, 1);
                asc = Convert.ToChar(strWord);
                if (asc < 0 || asc > 127)
                    lenTotal = lenTotal + 2;
                else
                    lenTotal = lenTotal + 1;
            }

            return lenTotal;
        }
        #endregion

        #region 替换特殊字符
        /// <summary>
        /// 特殊字符串替换
        /// </summary> 
        public static string repString(string strTemp)
        {
            if (strTemp == null)
                strTemp = "";
            strTemp = strTemp.Replace(" ", "");
            strTemp = strTemp.Replace("*", "");
            strTemp = strTemp.Replace("?", "");
            strTemp = strTemp.Replace("#", "");
            strTemp = strTemp.Replace("@", "");
            strTemp = strTemp.Replace("^", "");
            strTemp = strTemp.Replace("&", "");
            strTemp = strTemp.Replace("+", "");
            strTemp = strTemp.Replace("-", "");
            strTemp = strTemp.Replace("(", "");
            strTemp = strTemp.Replace(")", "");
            strTemp = strTemp.Replace("!", "");
            strTemp = strTemp.Replace("`", "");
            strTemp = strTemp.Replace("~", "");
            strTemp = strTemp.Replace("<", "");
            strTemp = strTemp.Replace(">", "");
            strTemp = strTemp.Replace("'", "");
            strTemp = strTemp.Replace("\"", "");
            strTemp = strTemp.Replace("\\", "");
            strTemp = strTemp.Replace("|", "");
            strTemp = strTemp.Replace("=", "");
            strTemp = strTemp.Replace(",", "");
            return strTemp;
        }
        #endregion


        #region 删除html格式
        /// <summary>
        /// 清除html特殊字符
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static string clearHtml(string strContent)
        {
            strContent = strContent.Replace("&", "");
            strContent = strContent.Replace("´", "");
            strContent = strContent.Replace("<", "");
            strContent = strContent.Replace(">", "");
            strContent = strContent.Replace("chr(60)", "");
            strContent = strContent.Replace("chr(37)", "");
            strContent = strContent.Replace("\"", "");
            strContent = strContent.Replace(";", "");
            strContent = strContent.Replace("\n", "<br/>");
            strContent = strContent.Replace("\\", "");
            return strContent;
        }
        #endregion

        #region md5 加密
        public static string EncryptMD5(string cleanString)
        {
            Byte[] clearBytes = new UnicodeEncoding().GetBytes(cleanString);
            Byte[] hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);
            return BitConverter.ToString(hashedBytes);
        }

        public static string MD5(string str)
        {
            //byte[] b = Encoding.Default.GetBytes(str);
            //b = new MD5CryptoServiceProvider().ComputeHash(b);
            //string ret = "";
            //for(int i = 0; i < b.Length; i++)
            //    ret += b[i].ToString("x").PadLeft(2,'0');
            //return ret;
            string ret = "";
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            ret = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(str)), 4, 8);
            ret = ret.Replace("-", "");
            return ret.ToLower();
        }
        #endregion


        #region DEC 加密过程
        ///
        public static string Encrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();　//把字符串放到byte数组中

            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            //byte[]　inputByteArray=Encoding.Unicode.GetBytes(pToEncrypt);

            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);　//建立加密对象的密钥和偏移量
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);　 //原文使用ASCIIEncoding.ASCII方法的GetBytes方法
            MemoryStream ms = new MemoryStream();　　 //使得输入密码必须输入英文文本
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            if (cs != null)
            {
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
            }
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }
        #endregion

        #region  DEC 解密过程

        public static string Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);　//建立加密对象的密钥和偏移量，此值重要，不能修改
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);

            //if (cs != null)
            //{
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.Flush();
            cs.FlushFinalBlock();
            // }
            StringBuilder ret = new StringBuilder();　//建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象

            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
        ///其中的sKey非常重要,定义的时候定义成string然后赋值等于八个字母或数字,注意,必须8个
        ///这个也很实用,譬如你想进入文章页面,传入的参数的aid=10000
        ///这时把10000给加密
        ///然后接受的时候解密.这样能有效的防止sql注入攻击!!!Ò®æÙ
        #endregion

        #region  获得日期（包括毫秒）
        public static string getDatatime()
        {
            string FDate = DateTime.Now.Year.ToString() + "-" + (DateTime.Now.Month >= 10 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month.ToString()) + "-" + (DateTime.Now.Day >= 10 ? DateTime.Now.Day.ToString() : "0" + DateTime.Now.Day.ToString()) + " " + (DateTime.Now.Hour >= 10 ? DateTime.Now.Hour.ToString() : "0" + DateTime.Now.Hour.ToString()) + ":" + (DateTime.Now.Minute >= 10 ? DateTime.Now.Minute.ToString() : "0" + DateTime.Now.Minute.ToString()) + ":" + (DateTime.Now.Second >= 10 ? DateTime.Now.Second.ToString() : "0" + DateTime.Now.Second.ToString());
            //string FDate = DateTime.Now.Year.ToString() + "-" + (DateTime.Now.Month >= 10 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month.ToString()) + "-" + (DateTime.Now.Day >= 10 ? DateTime.Now.Day.ToString() : "0" + DateTime.Now.Day.ToString()) + " " + DateTime.Now.ToLongTimeString();
            return FDate;
        }
        #endregion

        #region  获得日期
        public static string getData()
        {
            string FDate = DateTime.Now.Year.ToString() + "-" + (DateTime.Now.Month >= 10 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month.ToString()) + "-" + (DateTime.Now.Day >= 10 ? DateTime.Now.Day.ToString() : "0" + DateTime.Now.Day.ToString());
            return FDate;
        }

        public static string getHourAndMAndS()
        {
            return (DateTime.Now.Hour >= 10 ? DateTime.Now.Hour.ToString() : "0" + DateTime.Now.Hour.ToString()) + ":" + (DateTime.Now.Minute >= 10 ? DateTime.Now.Minute.ToString() : "0" + DateTime.Now.Minute.ToString()) + ":" + (DateTime.Now.Second >= 10 ? DateTime.Now.Second.ToString() : "0" + DateTime.Now.Second.ToString());
        }
        #endregion

        #region 过滤重复的字符
        public static string shanchuchongfu(string zifuchuan)
        {
            //原始
            string[] s = zifuchuan.Split(',');
            //保存的string
            string savestring = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != "")
                {
                    savestring = addstring(s[i], savestring);
                }
            }
            return savestring;

        }

        private static string addstring(string val, string list)
        {
            string[] s = list.Split(',');
            bool flag = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == val)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                list += val + ",";
            }
            return list;
        }
        #endregion

        /// <summary>
        /// Removes the HTML.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <returns></returns>
        public static string RemoveHTML(string html)
        {
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" no[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"\<img[^\>]+\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex9 = new System.Text.RegularExpressions.Regex(@"<[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记 
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性 
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件 
            html = regex4.Replace(html, ""); //过滤iframe 
            html = regex5.Replace(html, ""); //过滤frameset 
            html = regex6.Replace(html, ""); //过滤frameset 
            html = regex7.Replace(html, ""); //过滤frameset 
            html = regex8.Replace(html, ""); //过滤frameset 
            html = regex9.Replace(html, "");
            html = html.Replace(" ", "");
            html = html.Replace("</strong>", "");
            html = html.Replace("<strong>", "");
            return html;
        }
        /// <summary>
        /// Regexdoms the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public static string regexdom(string url)
        {
            string text = url;
            string pattern = @"(?<=http://)[\w\.]+[^/]";　//C#正则表达式提取匹配URL的模式，
            string s = "";
            MatchCollection mc = Regex.Matches(text, pattern);//满足pattern的匹配集合               
            foreach (Match match in mc)
            {
                s = match.ToString();
            } return s;
        }



    }
}
