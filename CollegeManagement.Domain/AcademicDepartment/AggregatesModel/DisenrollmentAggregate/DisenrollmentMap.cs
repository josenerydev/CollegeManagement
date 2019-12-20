using FluentNHibernate.Mapping;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.DisenrollmentAggregate
{
    public class DisenrollmentMap : ClassMap<Disenrollment>
    {
        public DisenrollmentMap()
        {
            Id(x => x.Id);

            Map(x => x.DateTime);
            Map(x => x.Comment).CustomType<string>().Access.CamelCaseField(Prefix.Underscore);

            References(x => x.Student);
            References(x => x.Course);
        }
    }
}
