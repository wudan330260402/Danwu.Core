using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using Danwu.Domain.Model;

namespace Infrastructure.Repository.EntityFramework
{
    public class UserTypeConfiguration : EntityTypeConfiguration<User>
    {

        public UserTypeConfiguration() {
            HasKey<Guid>(u => u.ID);
            Property(u => u.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

    }
}
