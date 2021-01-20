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
                .HasKey(o => o.id);

            builder.Property(p => p.ean)
                .HasColumnName("EAN")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();
            
            
            builder.Property(p => p.title)
                .HasColumnName("TITLE")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(p => p.description)
                .HasColumnName("DESCRIPTION")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();
        }
    }
}
