    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Windows.Forms;

//Install-Package HtmlAgilityPack
namespace TextPreProcessing
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
    class TextCleaner
    {
       static string removeStopWords(string input)
        {
            Dictionary<string, bool> _stops = new Dictionary<string, bool>
    {
    { "u", true },
    { "r", true },
    { "a", true },
    { "about", true },
    { "above", true },
    { "across", true },
    { "after", true },
    { "afterwards", true },
    { "again", true },
    { "against", true },
    { "all", true },
    { "almost", true },
    { "alone", true },
    { "along", true },
    { "already", true },
    { "also", true },
    { "although", true },
    { "always", true },
    { "am", true },
    { "among", true },
    { "amongst", true },
    { "amount", true },
    { "an", true },
    { "and", true },
    { "another", true },
    { "any", true },
    { "anyhow", true },
    { "anyone", true },
    { "anything", true },
    { "anyway", true },
    { "anywhere", true },
    { "are", true },
    { "around", true },
    { "as", true },
    { "at", true },
    { "back", true },
    { "be", true },
    { "became", true },
    { "because", true },
    { "become", true },
    { "becomes", true },
    { "becoming", true },
    { "been", true },
    { "before", true },
    { "beforehand", true },
    { "behind", true },
    { "being", true },
    { "below", true },
    { "beside", true },
    { "besides", true },
    { "between", true },
    { "beyond", true },
    { "bill", true },
    { "both", true },
    { "bottom", true },
    { "but", true },
    { "by", true },
    { "call", true },
    { "can", true },
    { "cannot", true },
    { "cant", true },
    { "co", true },
    { "computer", true },
    { "con", true },
    { "could", true },
    { "couldnt", true },
    { "cry", true },
    { "de", true },
    { "describe", true },
    { "detail", true },
    { "do", true },
    { "done", true },
    { "down", true },
    { "due", true },
    { "during", true },
    { "each", true },
    { "eg", true },
    { "eight", true },
    { "either", true },
    { "eleven", true },
    { "else", true },
    { "elsewhere", true },
    { "empty", true },
    { "enough", true },
    { "etc", true },
    { "even", true },
    { "ever", true },
    { "every", true },
    { "everyone", true },
    { "everything", true },
    { "everywhere", true },
    { "except", true },
    { "few", true },
    { "fifteen", true },
    { "fify", true },
    { "fill", true },
    { "find", true },
    { "fire", true },
    { "first", true },
    { "five", true },
    { "for", true },
    { "former", true },
    { "formerly", true },
    { "forty", true },
    { "found", true },
    { "four", true },
    { "from", true },
    { "front", true },
    { "full", true },
    { "further", true },
    { "get", true },
    { "give", true },
    { "go", true },
    { "had", true },
    { "has", true },
    { "have", true },
    { "he", true },
    { "hence", true },
    { "her", true },
    { "here", true },
    { "hereafter", true },
    { "hereby", true },
    { "herein", true },
    { "hereupon", true },
    { "hers", true },
    { "herself", true },
    { "him", true },
    { "himself", true },
    { "his", true },
    { "how", true },
    { "however", true },
    { "hundred", true },
    { "i", true },
    { "ie", true },
    { "if", true },
    { "in", true },
    { "inc", true },
    { "indeed", true },
    { "interest", true },
    { "into", true },
    { "is", true },
    { "it", true },
    { "its", true },
    { "itself", true },
    { "keep", true },
    { "last", true },
    { "latter", true },
    { "latterly", true },
    { "least", true },
    { "less", true },
    { "ltd", true },
    { "made", true },
    { "many", true },
    { "may", true },
    { "me", true },
    { "meanwhile", true },
    { "might", true },
    { "mill", true },
    { "mine", true },
    { "more", true },
    { "moreover", true },
    { "most", true },
    { "mostly", true },
    { "move", true },
    { "much", true },
    { "must", true },
    { "my", true },
    { "myself", true },
    { "name", true },
    { "namely", true },
    { "neither", true },
    { "never", true },
    { "nevertheless", true },
    { "next", true },
    { "nine", true },
    { "no", true },
    { "nobody", true },
    { "none", true },
    { "nor", true },
    { "not", true },
    { "nothing", true },
    { "now", true },
    { "nowhere", true },
    { "of", true },
    { "off", true },
    { "often", true },
    { "on", true },
    { "once", true },
    { "one", true },
    { "only", true },
    { "onto", true },
    { "or", true },
    { "other", true },
    { "others", true },
    { "otherwise", true },
    { "our", true },
    { "ours", true },
    { "ourselves", true },
    { "out", true },
    { "over", true },
    { "own", true },
    { "part", true },
    { "per", true },
    { "perhaps", true },
    { "please", true },
    { "put", true },
    { "rather", true },
    { "re", true },
    { "same", true },
    { "see", true },
    { "seem", true },
    { "seemed", true },
    { "seeming", true },
    { "seems", true },
    { "serious", true },
    { "several", true },
    { "she", true },
    { "should", true },
    { "show", true },
    { "side", true },
    { "since", true },
    { "sincere", true },
    { "six", true },
    { "sixty", true },
    { "so", true },
    { "some", true },
    { "somehow", true },
    { "someone", true },
    { "something", true },
    { "sometime", true },
    { "sometimes", true },
    { "somewhere", true },
    { "still", true },
    { "such", true },
    { "system", true },
    { "take", true },
    { "ten", true },
    { "than", true },
    { "that", true },
    { "the", true },
    { "their", true },
    { "them", true },
    { "themselves", true },
    { "then", true },
    { "thence", true },
    { "there", true },
    { "thereafter", true },
    { "thereby", true },
    { "therefore", true },
    { "therein", true },
    { "thereupon", true },
    { "these", true },
    { "they", true },
    { "thick", true },
    { "thin", true },
    { "third", true },
    { "this", true },
    { "those", true },
    { "though", true },
    { "three", true },
    { "through", true },
    { "throughout", true },
    { "thru", true },
    { "thus", true },
    { "to", true },
    { "together", true },
    { "too", true },
    { "top", true },
    { "toward", true },
    { "towards", true },
    { "twelve", true },
    { "twenty", true },
    { "two", true },
    { "un", true },
    { "under", true },
    { "until", true },
    { "up", true },
    { "upon", true },
    { "us", true },
    { "very", true },
    { "via", true },
    { "was", true },
    { "we", true },
    { "well", true },
    { "were", true },
    { "what", true },
    { "whatever", true },
    { "when", true },
    { "whence", true },
    { "whenever", true },
    { "where", true },
    { "whereafter", true },
    { "whereas", true },
    { "whereby", true },
    { "wherein", true },
    { "whereupon", true },
    { "wherever", true },
    { "whether", true },
    { "which", true },
    { "while", true },
    { "whither", true },
    { "who", true },
    { "whoever", true },
    { "whole", true },
    { "whom", true },
    { "whose", true },
    { "why", true },
    { "will", true },
    { "with", true },
    { "within", true },
    { "without", true },
    { "would", true },
    { "yet", true },
    { "you", true },
    { "your", true },
    { "yours", true },
    { "yourself", true },
    { "yourselves", true }
    };

            /// <summary>
            /// Chars that separate words.
            /// </summary>
            char[] _delimiters = new char[]
            {
    ' ',
    ',',
    ';',
    '.'
            };

            // 1
            // Split parameter into words
            var words = input.Split(_delimiters,
                StringSplitOptions.RemoveEmptyEntries);
            // 2
            // Allocate new dictionary to store found words
            var found = new Dictionary<string, bool>();
            // 3
            // Store results in this StringBuilder
            StringBuilder builder = new StringBuilder();
            // 4
            // Loop through all words
            foreach (string currentWord in words)
            {
                // 5
                // Convert to lowercase
                string lowerWord = currentWord.ToLower();
                // 6
                // If this is a usable word, add it
                if (!_stops.ContainsKey(lowerWord) &&
                !found.ContainsKey(lowerWord))
                {
                    builder.Append(currentWord).Append(' ');
                    found.Add(lowerWord, true);
                }
            }
            // 7
            // Return string with words removed
            return builder.ToString().Trim();
        }
        public static string cleanText(string myEncodedString)
        {
            // Encode the string.
            myEncodedString = HttpUtility.HtmlDecode(myEncodedString.Replace("”", "\"").Replace("“", "\"").Replace("’", "'"));
            // myEncodedString = HttpUtility.HtmlDecode(myEncodedString);
            myEncodedString = Regex.Replace(myEncodedString, @"http[^\s]+", "");
            Dictionary<string, string> d = new Dictionary<string, string>()
                {
                {"<3", "love"},
                {":)","happy" },
                {":-)","happy" },
                {":(","sad" },
                {":-(","sad" },
                  { "ain't", "am not" },
                  { "aren't", "are not" },
                  {"can't", "cannot"},
                  {"can't've", "cannot have"},
                  {"'cause", "because"},
                  {"could've", "could have"},
                  {"couldn't", "could not"},
                  {"couldn't've", "could not have"},
                  {"didn't", "did not"},
                  {"doesn't", "does not"},
                  {"don't", "do not"},
                  {"hadn't", "had not"},
                  {"hadn't've", "had not have"},
                  {"hasn't", "has not"},
                  {"haven't", "have not"},
                  {"he'd", "he would"},
                  {"he'd've", "he would have"},
                  { "he'll", "he will"},
                  {"he'll've", "he will have"},
                  {  "he's", "he is"},
                  { "how'd", "how did"},
                  { "how'd'y", "how do you"},
                  { "how'll", "how will"},
                  { "how's", "how is"},
                  {"I'd", "I would"},
                  {"I'd've", "I would have"},
                  {"I'll", "I will"},
                  {"I'll've", "I will have"},
                  {"I'm", "I am"},
                  {"I've", "I have"},
                  {"isn't", "is not"},
                  {"it'd", "it had"},
                  {"it'd've", "it would have"},
                  {"it'll", "it will"},
                  {"it'll've", "it will have"},
                  {"it's", "it is"},
                  {"let's", "let us"},
                  {"ma'am", "madam"},
                  {"mayn't", "may not"},
                  {"might've", "might have"},
                  {"mightn't", "might not"},
                  {"mightn't've", "might not have"},
                  {"must've", "must have"},
                  {"mustn't", "must not"},
                  {"mustn't've", "must not have"},
                  {"needn't", "need not"},
                  {"needn't've", "need not have"},
                  {"o'clock", "of the clock"},
                  {"oughtn't", "ought not"},
                  {"oughtn't've", "ought not have"},
                  {"shan't", "shall not"},
                  {"sha'n't", "shall not"},
                  {"shan't've", "shall not have"},
                  {"she'd", "she would"},
                  {"she'd've", "she would have"},
                  {"she'll", "she will"},
                  {"she'll've", "she will have"},
                  {"she's", "she is"},
                  {"should've", "should have"},
                  {"shouldn't", "should not"},
                  {"shouldn't've", "should not have"},
                  {"so've", "so have"},
                  {"so's", "so is"},
                  {"that'd", "that would"},
                  {"that'd've", "that would have"},
                  {"that's", "that is"},
                  {"there'd", "there had"},
                  {"there'd've", "there would have"},
                  {"there's", "there is"},
                  {"they'd", "they would"},
                  {"they'd've", "they would have"},
                  {"they'll", "they will"},
                  {"they'll've", "they will have"},
                  {"they're", "they are"},
                  {"they've", "they have"},
                  {"to've", "to have"},
                  {"wasn't", "was not"},
                  {"we'd", "we had"},
                  {"we'd've", "we would have"},
                  {"we'll", "we will"},
                  {"we'll've", "we will have"},
                  {"we're", "we are"},
                  {"we've", "we have"},
                  {"weren't", "were not"},
                  {"what'll", "what will"},
                  {"what'll've", "what will have"},
                  {"what're", "what are"},
                  {"what's", "what is"},
                  {"what've", "what have"},
                  {"when's", "when is"},
                  {"when've", "when have"},
                  {"where'd", "where did"},
                  {"where's", "where is"},
                  {"where've", "where have"},
                  {"who'll", "who will"},
                  {"who'll've", "who will have"},
                  {"who's", "who is"},
                  {"who've", "who have"},
                  {"why's", "why is"},
                  {"why've", "why have"},
                  {"will've", "will have"},
                  {"won't", "will not"},
                  {"won't've", "will not have"},
                  {"would've", "would have"},
                  {"wouldn't", "would not"},
                  {"wouldn't've", "would not have"},
                  {"y'all", "you all"},
                  {"y'alls", "you alls"},
                  {"y'all'd", "you all would"},
                  {"y'all'd've", "you all would have"},
                  {"y'all're", "you all are"},
                  {"y'all've", "you all have"},
                  {"you'd", "you had"},
                  {"you'd've", "you would have"},
                  {"you'll", "you you will"},
                  {"you'll've", "you you will have"},
                  {"you're", "you are"},
                  {"you've", "you have"}
                };


            // myEncodedString = Encoding.UTF8.GetString(Encoding.Default.GetBytes(myEncodedString));
            byte[] bytes = Encoding.Default.GetBytes(myEncodedString);
        myEncodedString = Encoding.UTF8.GetString(bytes);
            myEncodedString = myEncodedString.ToLower();
       // Console.WriteLine("\n\nHTML Encoded string is " + myEncodedString);
            foreach (KeyValuePair<string, string> pair in d)
            {
                //Console.WriteLine("1");
                string name = pair.Key.ToLower();
        string pattern = pair.Value.ToLower();
        // Console.WriteLine(pair.Key + pair.Value);
        myEncodedString= myEncodedString.Replace(name,pattern);
            }
          myEncodedString= removeStopWords(myEncodedString);
            myEncodedString= new string(myEncodedString.Where(c => !char.IsPunctuation(c)).ToArray());
            return myEncodedString;
        }


        private static void AppendBytes(StringBuilder sb, List<byte> bytes)
        {
            if (bytes.Count != 0)
            {
                var str = System.Text.Encoding.UTF8.GetString(bytes.ToArray());
                sb.Append(str);
                bytes.Clear();
            }
        }
    }
    
    class DataRetrieval
    {
        

       
    }
}
