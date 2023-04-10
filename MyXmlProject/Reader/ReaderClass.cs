using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.VisualBasic;
using MyXmlProject.Models;
using MyXmlProject.XMLModels;
namespace MyXmlProject.Reader
{
    public interface ReaderXml
    {
        public XmlListOrders Read(string path);

    }
    public  class ReaderXmlClass : ReaderXml
    {
        public XmlListOrders Read(string path)
        {
            XmlListOrders objectToDeserialize = new XmlListOrders();
            XmlSerializer xmlserializer = new System.Xml.Serialization.XmlSerializer(objectToDeserialize.GetType());
           
            string pattern = @"<reg_date>.+<\/reg_date>";
            MatchEvaluator evaluator = new MatchEvaluator(WordScrambler);
            MatchEvaluator evaluatorsum = new MatchEvaluator(WordScramblerSum);

            using (StreamReader streamReader = new StreamReader(path))
            {
                string content =
                Regex.Replace(streamReader.ReadToEnd(), pattern, evaluator,
                                            RegexOptions.IgnorePatternWhitespace);
                content = Regex.Replace(content, @"<price>.+<\/price>", evaluatorsum,
                                            RegexOptions.IgnorePatternWhitespace);
                content = Regex.Replace(content, @"<sum>.+<\/sum>", evaluatorsum,
                                            RegexOptions.IgnorePatternWhitespace);
                byte[] byteArray = Encoding.UTF8.GetBytes(content);
                
                MemoryStream stream = new MemoryStream(byteArray);
                return (XmlListOrders)xmlserializer.Deserialize(new StreamReader(stream));
            }
      
        }
        public static string WordScrambler(Match match)
        {
            return match.Value.Replace(".", "-");
           
        }

        public static string WordScramblerSum(Match match)
        {
            return match.Value.Replace(",", ".");

        }


    }
}
