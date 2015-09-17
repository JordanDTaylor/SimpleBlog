using System;
using System.Collections.Generic;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace SimpleBlog.Models
{
    public class Post
    {
        public virtual int Id { get; set; }
        public virtual User User { get; set; }

        public virtual string Title { get; set; }
        public virtual string Slug { get; set; }
        public virtual string Content { get; set; }

        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
        public virtual DateTime? DeletedAt { get; set; }

        public virtual bool IsDeleted => DeletedAt != null;

        public virtual IList<Tag> Tags { get; set; }

    }

    public class PostMap : ClassMapping<Post>
    {
        public PostMap()
        {
            Table("posts");

            Id(post => post.Id, idMapper => idMapper.Generator(Generators.Identity));

            ManyToOne(post=> post.User, author =>
            {
                author.Column("user_id");
                author.NotNullable(true);
            });

            Property(post => post.Title, title => title.NotNullable(true));
            Property(post => post.Slug, slug => slug.NotNullable(true));
            Property(post => post.Content, content => content.NotNullable(true));

            Property(post => post.CreatedAt, createAt =>
            {
                createAt.Column("created_at");
                createAt.NotNullable(true);
            });

            Property(post => post.UpdatedAt, updatedAt => updatedAt.Column("updated_at"));
            Property(post => post.DeletedAt, deletedAt => deletedAt.Column("deleted_at"));

            Bag(x => x.Tags, x =>
            {
                x.Key(k => k.Column("post_id"));
                x.Table("post_tags");

            }, x => x.ManyToMany(k => k.Column("tag_id")));
        }
    }
}