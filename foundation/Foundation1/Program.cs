using System;
using System.Collections.Generic;

namespace MarvelYouTubeTracker
{
    public class Comment
    {
        public string CommenterName { get; private set; }
        public string Text { get; private set; }

        public Comment(string commenterName, string text)
        {
            CommenterName = commenterName;
            Text = text;
        }
    }

    public class Video
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int LengthInSeconds { get; private set; }
        private List<Comment> _comments;

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
            _comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return _comments.Count;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Length: {LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in _comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var video1 = new Video("How to Use Mjolnir", "Thor Odinson", 600);
            var video2 = new Video("Tech Innovations at Stark Industries", "Tony Stark", 900);
            var video3 = new Video("The Wakanda Experience", "T'Challa", 1200);

            video1.AddComment(new Comment("Loki", "I could wield Mjolnir if I wanted to."));
            video1.AddComment(new Comment("Hulk", "Mjolnir too small for Hulk!"));
            video1.AddComment(new Comment("Jane Foster", "Great explanation, Thor!"));

            video2.AddComment(new Comment("Pepper Potts", "Proud of you, Tony."));
            video2.AddComment(new Comment("Rhodey", "Can't wait to try the new suit."));
            video2.AddComment(new Comment("Happy Hogan", "When can I get my upgrade?"));

            video3.AddComment(new Comment("Shuri", "You forgot to mention my inventions!"));
            video3.AddComment(new Comment("Okoye", "Wakanda Forever!"));
            video3.AddComment(new Comment("Nakia", "Great video, T'Challa."));

            List<Video> videos = new List<Video> { video1, video2, video3 };

            foreach (var video in videos)
            {
                video.DisplayInfo();
            }
        }
    }
}
