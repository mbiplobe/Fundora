class MinimumAttendancePolicy : IAttendancePolicy
{
    public bool CanSitForExam(Student student)
    {
        return student.Attendance >= 75;
    }
}
