using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoPratico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Infraestructure.data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Name)
                .HasConversion(u => u.Value, u => Name.CreateName(u).Value)
                .HasMaxLength(15)
                .HasColumnType("varchar")
                .IsRequired();

            builder
                .Property(u => u.LastName)
                .HasConversion(u => u.Value, u => UserLastName.CreateName(u).Value)
                .HasMaxLength(15)
                .HasColumnType("varchar")
                .IsRequired();

            builder
                .Property(u => u.Email)
                .HasConversion(u => u.Value, u => UserEmail.Add(u).Value)
                .HasMaxLength(30)
                .HasColumnType("varchar")
                .IsRequired();

            builder
                .Property(u => u.Pass)
                .HasConversion(u => u.Value, u => UserPass.Create(u).Value)
                .HasMaxLength(30)
                .HasColumnType("varchar")
                .IsRequired();


            builder.HasOne<Recipe>(r => r.Recipes);
               
                

                





        }
    }
}
