using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ParseLibrary
{
    public class ParseFileData
    {

        private readonly string _datapattern = @"(\d{2}\.\d{4})\,\s(\d{2}\.\d{4})$";
        private List<string> data = new List<string>();
        private List<string> validdata = new List<string>();
        private List<string[]> outdata = new List<string[]>();

        public List<string[]> SetData(string PATH)
        {
            if(Path.GetExtension(PATH).Equals(".txt"))
            {
                using (StreamReader stream = new StreamReader(PATH))
                {
                    while (!stream.EndOfStream)
                    {
                        data.Add(stream.ReadLine());
                    }
                }
                foreach (var d in data)
                {
                    if (Regex.IsMatch(d, _datapattern, RegexOptions.IgnoreCase))
                        validdata.Add(d);
                }
                foreach (var vd in validdata)
                    outdata.Add(vd.Split(','));
            }
            return outdata;
        }
    }
}
