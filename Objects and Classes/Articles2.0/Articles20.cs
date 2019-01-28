using System;
using System.Collections.Generic;
using System.Linq;

class Articles20
{
    public Articles20(string title, string content, string author)
    {
        this.Title = title;
        this.Content = content;
        this.Author = author;                
    }

    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }

    public override string ToString()
    {
        return $"{this.Title} - {this.Content}: {this.Author}";
    }

    static void Main(string[] args)
    {
        List<Articles20> collectionOfArticles = new List<Articles20>();
        int n = int.Parse(Console.ReadLine());

        while (n > 0)
        {
            string[] input = Console.ReadLine().Split(',');
            collectionOfArticles.Add(new Articles20(input[0].TrimStart(), input[1].TrimStart(), input[2].TrimStart()));
            n--;
        }

        string article = Console.ReadLine();
        List<Articles20> newList;

        if (article.Equals("title"))
        {
            newList = collectionOfArticles.OrderBy(x => x.Title).ToList();
        }
        else if (article.Equals("content"))
        {
            newList = collectionOfArticles.OrderBy(x => x.Content).ToList();
        }
        else
        {
            newList = collectionOfArticles.OrderBy(x => x.Author).ToList();
        }

        foreach (var item in newList)
        {
            Console.WriteLine($"{item.Title} - {item.Content}: {item.Author}");
        }
    }   
}

