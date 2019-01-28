
class Phrases
{
    //readonly field can be used for runtime constants
    readonly int count;

    public Phrases(string[] newPhrases)
    {
        this.SpokenPhrases = newPhrases;
        this.count = SpokenPhrases.Length;
    }

    public string[] SpokenPhrases { get; set; }
    public int GetCountOfPhrases
    {
        get
        {
            return this.count;
        }
    }

}

