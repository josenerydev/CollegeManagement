using FluentNHibernate.Mapping;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.StudentAggregate
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Id(x => x.Id);

            Map(x => x.Name).CustomType<string>().Access.CamelCaseField(Prefix.Underscore);
            Map(x => x.Email).CustomType<string>().Access.CamelCaseField(Prefix.Underscore);

            HasMany(x => x.Enrollments).Access.CamelCaseField(Prefix.Underscore).Inverse().Cascade.AllDeleteOrphan();
            HasMany(x => x.Disenrollments).Access.CamelCaseField(Prefix.Underscore).Inverse().Cascade.AllDeleteOrphan();
        }
    }
}
