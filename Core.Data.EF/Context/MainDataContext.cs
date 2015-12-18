using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;
using Core.Domain.News;
using Core.Domain.Profiles;

namespace Core.Data.EF.Context
{
    public class MainDataContext : DbContext
    {
        public MainDataContext()
            : base("name=MainConnectionString")
        {
            
        }


        #region News

        public DbSet<NewsCheck> NewsChecks { get; set; }
        public DbSet<NewsItem> NewsItems { get; set; }

        #endregion

        #region Profiles

        public DbSet<User> Users { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(MainDataContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb, ex
                    );
            }
        }
    }
}
