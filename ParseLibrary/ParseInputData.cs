using System.Text.RegularExpressions;
using Dialog.Views;

namespace ParseLibrary
{
    public class ParseInputData
    {
        private readonly string _datapattern = @"(\d{2}\.\d{4})\,\s(\d{2}\.\d{4})$";
        private string data;
        private string[] parseData;

        public ParseInputData(string inputuserdata)
        {
            data = inputuserdata;
        }

        public string[] GetData()
        {
            if (Regex.IsMatch(data, _datapattern, RegexOptions.IgnoreCase))
            {
                parseData = data.Split(',');
            }
            else
            {
                parseData = new string[] { data };
                MainWindow window = new MainWindow("Invalid data!\nPleate input your data in next format:\nxx.xxxxx, yy.yyyyy");
                window.Show();
            }
            return parseData;
        }
    }
}
