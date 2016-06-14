using MvcSample.Domain.Entities;
using FluentNHibernate.Mapping;

namespace MvcSample.Domain.Maps
{
    public class ContactMap : ClassMap<Contact>
    {
        public ContactMap()
        {
            Schema("dbo");
            Table("Users");

            Id(x => x.Id).Column("Id").Not.Nullable().GeneratedBy.Identity();

            Map(c => c.Email, "Email").Nullable();
            Map(c => c.Name, "Name").Nullable();
            Map(c => c.Mobile, "Mobile").Nullable();
        }
    }
}