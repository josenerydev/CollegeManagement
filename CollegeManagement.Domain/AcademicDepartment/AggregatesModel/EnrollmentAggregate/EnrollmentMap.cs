using FluentNHibernate.Mapping;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.EnrollmentAggregate
{
    public class EnrollmentMap : ClassMap<Enrollment>
    {
        public EnrollmentMap()
        {
            Id(x => x.Id);

            References(x => x.Grade);
            References(x => x.Student);
            References(x => x.Course);
        }
    }
}
