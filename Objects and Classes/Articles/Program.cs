using System;

class Articles
{
    //private string title;
    //private string content;
    //private string author;

    public Articles(string title, string content, string author)
    {
        this.Title = title;
        this.Content = content;
        this.Author = author;
    }

    public string Title { get; set; }
    public string Content { get; set; }
    public string  Author { get; set; }

    public void Edit(string newContent)
    {
        this.Content = newContent;
    }
    
    public void ChangeAuthor(string newAuthor)
    {
        this.Author = newAuthor;
    }

    public void Rename(string newTitle)
    {
        this.Title = newTitle;
    }

    public override string ToString()
    {
        return $"{this.Title} - {this.Content}: {this.Author}";
    }

    static void Main()
    {
        string[] input = Console.ReadLine().Split(',');
        Articles newArticle = new Articles(input[0].TrimStart(), input[1].TrimStart(), input[2].TrimStart());

        int n = int.Parse(Console.ReadLine());

        while(n > 0)
        {
            input = Console.ReadLine().Split(':');
            switch (input[0])
            {
                case "Edit":
                    newArticle.Edit(input[1].TrimStart());
                    break;
                case "ChangeAuthor":
                    newArticle.ChangeAuthor(input[1].TrimStart());
                    break;
                case "Rename":
                    newArticle.Rename(input[1].TrimStart());
                    break;
            }

            n--;
        }
        

        Console.WriteLine(newArticle);


    }
}



