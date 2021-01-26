using Clientes.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clientes.Infraestrutura.EntityFramework.Mappers
{
    public class ComicMap : IEntityTypeConfiguration<Comic>
    {
        public void Configure(EntityTypeBuilder<Comic> builder)
        {
            builder.ToTable("COMIC")
                .HasKey(o => o.Id);

            builder.Property(p => p.Title)
                .HasColumnName("TITLE")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(p => p.Ean)
                .HasColumnName("EAN")
                .HasColumnType("VARCHAR(100)");

            builder.Property(p => p.Description)
                .HasColumnName("DESCRIPTION")
                .HasColumnType("VARCHAR(200)");
        }
    }
}
