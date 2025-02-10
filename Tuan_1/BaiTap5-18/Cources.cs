using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Tuan_1.BaiTap5_18
{
    internal class Cources
    {
        private string courceCode;
        private string courceName;
        private int numOSections;
        private string schedule;
        private int numOStudent;
        private string teacher;
        const int teacherSalary = 500000;

        public string GetCourseCode() => courceCode;
        public void SetCourseCode(string CourseCode)
        {
            if (string.IsNullOrEmpty(CourseCode))
                throw new ArgumentNullException("Ma trong!");
            if (CourseCode.Length != 5 || CourseCode[0] != 'K' || CourseCode[1] != 'H' &&
                CourseCode[2] != '1' && CourseCode[2] != '2' && CourseCode[2] != '3')
                throw new ArgumentException("Loi ma");
            this.courceCode = CourseCode;
        }

        public string GetCourseName() => courceName;
        public void SetCourseName(string CourseName)
        {

            if (string.IsNullOrEmpty(CourseName))
                throw new ArgumentNullException("Ten trong!");
            this.courceName = CourseName;
        }

        public int GetNumOSections() => numOSections;
        public void SetNumOSections(int NumOSections)
        {
            if (NumOSections <= 0)
                throw new ArgumentException("Loi so buoi!");
            this.numOSections = NumOSections;
        }

        public string GetSchedule() => schedule;
        public void SetSchedule(string Schedule)
        {
            if (string.IsNullOrEmpty(Schedule))
                throw new ArgumentNullException("Gio hoc rong!");
            if (string.Compare(Schedule, "2, 4, 6") != 0 && string.Compare(Schedule, "3, 5, 7") != 0 && string.Compare(Schedule, "7, CN") != 0)
                Schedule = "2, 4, 6";
            this.schedule = Schedule;
        }

        public int GetNumOStudent() => numOStudent;
        public void SetNumOStudent(int NumOStudent)
        {
            if (NumOStudent < 10 || NumOStudent > 20)
                throw new ArgumentException("Loi so luong hoc vien!");
            this.numOStudent = NumOStudent;
        }

        public string GetTeacher() => teacher;
        public void SetTeacher(string Teacher)
        {
            if (string.IsNullOrEmpty(Teacher))
                throw new ArgumentNullException("Ten giao vien trong");
            this.teacher = Teacher;
        }

        // Khởi tạo có tham số
        public Cources(string courceCode, string courceName, int numOSections, string schedule, int numOStudent, string teacher)
        {
            SetCourseCode(courceCode);
            SetCourseName(courceName);
            SetNumOSections(numOSections);
            SetSchedule(schedule);
            SetNumOStudent(numOStudent);
            SetTeacher(teacher);
        }

        // Khởi tạo không tham số
        public Cources() { }

        // Sao chép
        public Cources(Cources c)
        {
            SetCourseCode(c.courceCode);
            SetCourseName(c.courceName);
            SetNumOSections(c.numOSections);
            SetSchedule(c.schedule);
            SetNumOStudent(c.numOStudent);
            SetTeacher(c.teacher);
        }

        public int CalculateTuition()
        {
            if (string.Compare(GetSchedule(), "7, CN") == 0)
                return (int)(GetNumOSections() * teacherSalary * 1.2);
            return GetNumOStudent() * teacherSalary;
        }

        public int TeacherCompensation()
        {
            if(GetNumOStudent() >= 15) 
                return GetNumOSections() * teacherSalary + GetNumOStudent() * 10000 * GetNumOSections();
            return GetNumOSections() * teacherSalary;
        }

        public void Nhap()
        {
            while (true)
            {
                try
                {
                    Console.Write("\n\nMa khoa hoc: ");
                    string courseCode = Console.ReadLine();
                    Console.Write("Ten khoa hoc: ");
                    string courseName = Console.ReadLine();
                    Console.Write("So buoi: ");
                    int numOSections = int.Parse(Console.ReadLine());
                    Console.Write("Gio hoc: ");
                    string schedule = Console.ReadLine();
                    Console.Write("So luong hoc vien: ");
                    int numOStudent = int.Parse(Console.ReadLine());
                    Console.Write("Ten giao vien: ");
                    string teacher = Console.ReadLine();

                    SetCourseCode(courseCode);
                    SetCourseName(courseName);
                    SetNumOStudent(numOStudent);
                    SetNumOSections(numOSections);
                    SetSchedule(schedule);
                    SetTeacher(teacher);
                    break;
                }
                catch (Exception er)
                {
                    Console.WriteLine("Loi: {0}\nVui long nhap lai!", er);
                }
            }
        }

        public void Xuat()
        {
            Console.WriteLine($"\nMa khoa hoc: {courceCode}");
            Console.WriteLine($"Ten khoa hoc: {courceName}");
            Console.WriteLine($"So buoi: {numOSections}");
            Console.WriteLine($"Gio hoc: {schedule}");
            Console.WriteLine($"So luong hoc vien: {numOStudent}");
            Console.WriteLine($"Ten giao vien: {teacher}");
            Console.WriteLine($"Hoc phi: {CalculateTuition():N0}");
            Console.WriteLine($"Thu lao giao vien: {TeacherCompensation():N0}");
        }
    }
}
