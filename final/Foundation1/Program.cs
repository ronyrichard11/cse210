using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // create some videos
        Video video1 = new Video("Me at the Zoo", "Jawed", 120);
        video1.AddComment("San Diego Zoo", "We're so honored that the first ever YouTube video was filmed here!");
        video1.AddComment("AlanMMO", "An instant classic for sure!");
        videos.Add(video1);

        Video video2 = new Video("WINTRADING IN EU?", "loltyler1", 900);
        video2.AddComment("Charlie1523", "Common Tyler1 W!");
        video2.AddComment("yamatosdeath1", "Tyler1 will never climb. I will make sure of it!");
        video2.AddComment("Eve", "Can't wait for the next vid tyler!");
        videos.Add(video2);

        // iterate through the list of videos and display their info
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (in seconds): {video.Length}");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"{comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; }
    public List<Comment> Comments { get; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(string name, string text)
    {
        Comments.Add(new Comment(name, text));
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string Name { get; }
    public string Text { get; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}
