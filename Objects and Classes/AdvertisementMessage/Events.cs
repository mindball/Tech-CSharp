class Events
{
    //readonly field can be used for runtime constants
    readonly int count;

    public Events(string[] events)
    {
        this.CurrentEvents = events;
        this.count = CurrentEvents.Length;
    }

    public string[] CurrentEvents { get; set; }

    public int GetCountOfEvents
    {
        get
        {
            return this.count;
        }
    }
}

