namespace UniversityCourseAndResultManagementSystem.Common.QueryParameters
{
    public class CourseQueryParameters : QueryParametersBase
    {
        private bool _isAssignedCheck = false;
        public bool IsAssignedCheck
        {
            get { return _isAssignedCheck; }
            set { _isAssignedCheck = value; }
        }
    }
}
