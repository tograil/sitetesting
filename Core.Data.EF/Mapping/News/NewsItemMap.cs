using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.News;

namespace Core.Data.EF.Mapping.News
{
    public class NewsItemMap : EntityTypeConfiguration<NewsItem>
    {
        public NewsItemMap()
        {
            ToTable("NewsItems");

            HasKey(t => t.Id);
            Property(t => t.Title).HasMaxLength(400).IsRequired();
            Property(t => t.Body).IsMaxLength().IsRequired();
            Property(t => t.ImagePath).HasMaxLength(500).IsRequired();


        }
    }
}
