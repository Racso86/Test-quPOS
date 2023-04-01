// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, QU POS!");
var matrix = new string[]
        {
            "abcdc",
            "fgwio",
            "chill",
            "pqnsd",
            "uvdxy"
        };

var wordstream = new string[]
{
            "cold",
            "wind",
            "chill",
            "snow",
            "agisy"
};
var wordstream2 = new string[]
{
            "chill",
            "cold",
            "123",
            "5431",
            "1323"
};
var finder = new WordFinder(matrix);
var topWords = finder.Find(wordstream2);

foreach (var word in topWords)
{
    Console.WriteLine(word);
    Console.WriteLine(" ");
}