using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace LAB4_PART1_Strings.Model
{
    public class HTMLPageParser
    {
        #region Members

        string mUrlAddress;

        #endregion

        public HTMLPageParser(string urlAddress)
        {
            if (String.IsNullOrEmpty(urlAddress))
                throw new ArgumentNullException(nameof(urlAddress));

            mUrlAddress = urlAddress;
        }

        public IEnumerable<(string link, string linkAddess)> GetAllLinks()
        {
            foreach (Match m in Regex.Matches(GetPage(), PageParserRegexes.LinkRegex))
                yield return (m.Groups["link"].Value, m.Groups["title"].Value);
        }

        public IEnumerable<string> GetAllAddresses()
        {
            foreach (Match m in Regex.Matches(GetPage(), PageParserRegexes.EmailRegex))
                yield return m.Value;
        }

        public IEnumerable<(string phone, string mobileOperator)> GetAllPhones()
        {
            foreach (Match m in Regex.Matches(GetPage(), PageParserRegexes.PhoneRegex))
                yield return (m.Value, GetMobileOperatorByCode(m.Groups["operator"].Value));
        }

        #region Private methods

        private string GetPage()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(mUrlAddress);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();

                    using (var reader = new StreamReader(receiveStream, response.CharacterSet is null ?
                        Encoding.UTF8 : Encoding.GetEncoding(response.CharacterSet)))
                    {
                        return reader.ReadToEnd();
                    }
                }
                else
                {
                    throw new ArgumentException("Wrong url address.");
                }
            }
        }


        private static string GetMobileOperatorByCode(string code)
        {
            return PageParserConstants.MobileOperatorsCodes.ContainsKey(code) ? 
                PageParserConstants.MobileOperatorsCodes[code] : PageParserConstants.NullMobileOperator;
        }
        #endregion
    }
}
