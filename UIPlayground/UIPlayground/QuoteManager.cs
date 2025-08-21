using System;

namespace UIPlayground
{
    public class QuoteManager
    {
        private Random _random = new Random();
        private string[] _quotes = {
            "...you must remember that the journey itself has meaning. ...The destination is not everything.",
            "If you can change something, change it. If you can't, don't waste time thinking about it",
            "Never stop searching, even if only for a brief flash of light. If nothing else, we have the present moment"
        };


        public string GetRandomQuote()
        {
            return _quotes[_random.Next(_quotes.Length)];
        }
    }
}
