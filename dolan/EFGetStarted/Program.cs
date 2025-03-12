using System;
using Microsoft.EntityFrameworkCore;
using System.Linq; // Required for LINQ operations
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        using (var db = new MyDBContext())
        {
            // Ensure database is created (optional, for testing)
            db.Database.EnsureCreated();

            // Insert multiple blogs
            Console.WriteLine("Inserting multiple blogs...");
            db.Blogs.AddRange(
                new Blog { Url = "http://blogs.msdn.com/adonet" },
                new Blog { Url = "https://devblogs.microsoft.com/dotnet" },
                new Blog { Url = "https://medium.com/dotnet" }
            );
            db.SaveChanges();

            // List all blogs
            Console.WriteLine("\nAll blogs:");
            var blogs = db.Blogs.ToList();
            foreach (var b in blogs)
            {
                Console.WriteLine($"BlogId: {b.BlogId}, URL: {b.Url}");
            }

            // Find a specific blog by URL
            Console.WriteLine("\nQuerying for a blog with '.net' in URL:");
            var netBlog = db.Blogs.FirstOrDefault(b => b.Url.Contains("dotnet"));
            if (netBlog != null)
                Console.WriteLine($"Found: BlogId: {netBlog.BlogId}, URL: {netBlog.Url}");
            else
                Console.WriteLine("No matching blog found.");

            // Update the first blog
            Console.WriteLine("\nUpdating the first blog and adding a post...");
            var firstBlog = db.Blogs.OrderBy(b => b.BlogId).First();
            firstBlog.Url = "https://updatedblog.com";
            firstBlog.Posts.Add(new Post { Title = "Updated Post", Content = "Updated Content!" });
            db.SaveChanges();

            // Show blogs with posts
            Console.WriteLine("\nBlogs with at least one post:");
            var blogsWithPosts = db.Blogs
                .Where(b => b.Posts.Any())
                .Include(b => b.Posts)
                .ToList();

            foreach (var b in blogsWithPosts)
            {
                Console.WriteLine($"BlogId: {b.BlogId}, URL: {b.Url}, Posts: {b.Posts.Count}");
            }

            // Delete blogs with ID > 1
            Console.WriteLine("\nDeleting blogs with ID > 1...");
            db.Blogs.RemoveRange(db.Blogs.Where(b => b.BlogId > 1));
            db.SaveChanges();

            // Display remaining blogs
            Console.WriteLine("\nRemaining blogs after deletion:");
            foreach (var b in db.Blogs.ToList())
            {
                Console.WriteLine($"BlogId: {b.BlogId}, URL: {b.Url}");
            }
        }
    }
}
