using System;
class Cities
{
    //readonly field can be used for runtime constants
    readonly int countOfCities;

    public Cities(string[] cities)
    {
        this.CitiesOfCountry = cities;
        this.countOfCities = CitiesOfCountry.Length;
    }

    public string[] CitiesOfCountry { get; set; }

    public int GetCountOfCity
    {
        get
        {
            return this.countOfCities;
        }
    }
}

