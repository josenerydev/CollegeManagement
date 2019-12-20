using FluentNHibernate.Mapping;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.Common
{
    public class GradeMap : ClassMap<Grade>
    {
        public GradeMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);
        }
    }
}
