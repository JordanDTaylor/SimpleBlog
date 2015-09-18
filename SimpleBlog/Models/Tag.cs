using System.Collections.Generic;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace SimpleBlog.Models
{
    public class Tag
    {
        public virtual int Id { get; set; }
        public virtual string Slug { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<Post> Posts { get; set; } = new List<Post>();
    }

    public class TagMap : ClassMapping<Tag>
    {
        public TagMap()
        {
            Table("tags");

            Id(tag => tag.Id, idMapper => idMapper.Generator(Generators.Identity));

            Property(tag=>tag.Name, name=> name.NotNullable(true));
            Property(tag=>tag.Slug, slug=> slug.NotNullable(true));

            Bag(x=>x.Posts, x =>
            {
                x.Key(k => k.Column("tag_id"));
                x.Table("post_tags");
               
            }, x=>x.ManyToMany(k=>k.Column("post_id")));
        }
    }
}