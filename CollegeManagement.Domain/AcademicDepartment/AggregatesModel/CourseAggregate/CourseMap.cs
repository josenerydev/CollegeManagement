using FluentNHibernate.Mapping;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.CourseAggregate
{
    public class CourseMap : ClassMap<Course>
    {
        public CourseMap()
        {
            Id(x => x.Id);

            Map(x => x.Name).CustomType<string>().Access.CamelCaseField(Prefix.Underscore);
            Map(x => x.Credits).CustomType<int>().Access.CamelCaseField(Prefix.Underscore);
        }
    }
}
