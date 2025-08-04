using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create Video 1
        Video video1 = new Video("This mechanism shrinks when pulled", "Veritasium", 1384);
        video1.AddComment(new Comment("HeisenbergFam", "'it feels like it violates physics' 'thats why its fun' The most physicist thing I've heard"));
        video1.AddComment(new Comment("Wifies", "The analogy of the roads to the contraction of the springs is insanely well done. What a crazy good way to explain the series/parallel in two completely different settings"));
        video1.AddComment(new Comment("cursor1245", "If I will ever be part of a Veritasium survey I will just say the most counter intuitive answer."));
        video1.AddComment(new Comment("zacprunty", "I don’t think the veritasium editing team gets enough credit. The visuals these guys put together are top notch."));
        videos.Add(video1);

        // Create Video 2
        Video video2 = new Video("The Most Dangerous Building in Manhattan", "Veritasium", 2003);
        video2.AddComment(new Comment("Jarrod_Naude", "The fact that they were allowed to destroy that church and then replace it with what looks like the entrance to a fancy metro is crazy."));
        video2.AddComment(new Comment("Memineo", "I love how the video is so well made, it feels like a movie."));
        video2.AddComment(new Comment("FitnessBeginner", "So in fact it is not the most dangerous building in Manhattan, but the most dangerous building in the world?"));
        videos.Add(video2);

        // Create Video 3
        Video video3 = new Video("The Most Important Material Ever Made", "Veritasium", 1334);
        video3.AddComment(new Comment("DevStudent", "Amazing video! The way you explain complex topics is really engaging."));
        video3.AddComment(new Comment("Lilislife", "Clear explanations. Subscribing for more content."));
        video3.AddComment(new Comment("Anais", "Good refresher even for experienced developers."));
        video3.AddComment(new Comment("Baby_yoda", "The examples were really helpful."));
        videos.Add(video3);

        

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine(); // Empty line for separation
        }
    }
}