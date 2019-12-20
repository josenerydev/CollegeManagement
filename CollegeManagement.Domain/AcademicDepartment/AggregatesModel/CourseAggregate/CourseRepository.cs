using CollegeManagement.Domain.SeedWork;
using System.Linq;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.CourseAggregate
{
    public class CourseRepository : Repository<Course>
    {
        public CourseRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Course GetByName(string name)
        {
            return Query<Course>().SingleOrDefault(x => x.Name == name);
        }
    }
}
