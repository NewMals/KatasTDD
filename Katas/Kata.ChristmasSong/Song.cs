namespace ChrismasSong;

public class Song
{
    private readonly Dictionary<int, string> _daysNumbers = new()
    {
        { 1, "first" },
        { 2, "second" },
        { 3, "third" },
        { 4, "fourth" },
        { 5, "fifth" },
        { 6, "sixth" },
        { 7, "seventh" },
        { 8, "eight" },
        { 9, "ninth" },
        { 10, "tenth" },
        { 11, "eleventh" },
        { 12, "twelfth" }
    };

    private readonly List<string> _linesSong =
    [
        "A partridge in a pear tree.",
        "Two turtle doves and",
        "Three french hens",
        "Four calling birds",
        "Five golden rings",
        "Six geese a-laying",
        "Seven swans a-swimming",
        "Eight maids a-milking",
        "Nine ladies dancing",
        "Ten lords a-leaping",
        "Eleven pipers piping",
        "Twelve drummers drumming"
    ];

    public const string SecondLine = "My true love sent to me:";

    public string GetStropheFirstLine(int strophe) => 
        $"On the {_daysNumbers.First(f => f.Key == strophe ).Value} day of Christmas{(strophe > 5 ? "," : "")}";
    

    public string GetContentStrophe(int strophe)
    {
        if(strophe < 1 || strophe > _linesSong.Count)
            throw new Exception("Estrofa no existe");
        
        var content = new List<string>
        {
            GetStropheFirstLine(strophe),
            SecondLine
        };
        
        content.AddRange(_linesSong.Take(strophe).Reverse());
        return string.Join("\n", content);
    }
    
    public string GetSong() =>
        _linesSong
            .Select(line => _linesSong.IndexOf(line) + 1)
            .Aggregate(string.Empty, 
                (current, index) => current + $"{GetContentStrophe(index)}{(index == _linesSong.Count ? "" : "\n\n")}"
            );
    
}