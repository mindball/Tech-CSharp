

class Authors
{
    //readonly field can be used for runtime constants
    readonly int count;

    public Authors(string[] namesOfAuthors)
    {
        this.Names = namesOfAuthors;
        this.count = Names.Length;
    }

    public string[] Names { get; set; }

    public int GetCountOfAuthors
    {
        get
        {
            return this.count;
        }
    }
}

