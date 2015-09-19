using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SimpleBlog.Infrastructure;
using SimpleBlog.Models;

namespace SimpleBlog.ViewModels
{
    public class TagCheckbox
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }

    public class PostsIndex
    {
        public PagedData<Post> Posts { get; set; }
    }

    public class PostsForm
    {
        public bool IsNew { get; set; }
        public int? PostId { get; set; }

        [Required, MaxLength(128)]
        public string Title { get; set; }

        [Required, MaxLength(128)]
        public string Slug { get; set; }

        [Required, DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public IList<TagCheckbox> Tags { get; set; }
    }


    public class PostsShow
    {
        public Post Post { get; set; }
    }

    public class PostsTag
    {
        public Tag Tag { get; set; }
        public PagedData<Post> Posts { get; set; } 
    }

}