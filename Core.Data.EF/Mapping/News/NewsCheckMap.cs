using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.News;

namespace Core.Data.EF.Mapping.News
{
    public class NewsCheckMap : EntityTypeConfiguration<NewsCheck>
    {
        public NewsCheckMap()
        {
            ToTable("NewsChecks");
            HasKey(t => t.Id);
            Property(t => t.WhenChecked).IsRequired();
            Property(t => t.Status).IsRequired();

            HasRequired(t => t.WhoChecked).WithMany().HasForeignKey(t => t.UserId).WillCascadeOnDelete(true);
            
        }
    }
}
