using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestLinq : MonoBehaviour
{
    private void Demo()
    {
        List<string> listStr = new List<string>() { "nam", "hung", "anh", "tuan", "tuan" };
        List<string> listStr2 = new List<string>() { "nam", "hung", "anh", "tuan", "tuan" };
        //Vi du ve select
        listStr = listStr.Select(x => x + "_1").ToList();

        Student aStudent = new Student("anh", 15, Gender.Male);
        List<Student> studentList = new List<Student>() { new Student("anh", 13, Gender.Male), new Student("hung", 21, Gender.Male) };
        List<string> nameList = studentList.Select(x => x.StudentName).ToList();

        //giam dan
        List<Student> studentByAge = studentList.OrderBy(x => x.StudentAge).ToList();

        //tim hoc vien dau tien tuoi bang 21
        Student student = studentList.First(x => x.StudentAge == 21);
        //Student1 student2 = studentList.Where(x => x.StudentAge == 21).First();

        //ghep mang
        List<string> listStr3 = listStr.Concat(listStr2).ToList();
        //loc ra nhung phan tu trung nhau
        listStr = listStr.Distinct().ToList();
    }

    private void Ex()
    {
        List<Student> students = new List<Student>();
        //1: lọc ra những phần tử có giới tính nam và tên  là hung
        var studentfilter = students.Where(s => s.StudentName.Equals("Hung") && s.Gender == Gender.Male).ToList();
        var studentFilter = from student in students where student.StudentName.Equals("hung") && student.Gender == Gender.Male select student;
        //2: tạo ra 1 danh sách bao gồm chỉ tuổi và sắp xếp giảm dần
        List<int> sortedAges = students.Select(n => n.StudentAge).OrderByDescending(age => age).ToList();
        //3: lọc ra những phần tử có tuổi lớn hơn 18 và sau đó tạo 1 danh sách chỉ bao gồm tên
        var studentnews = students.Where(s => s.StudentAge >= 18).Select(s => s.StudentName).ToList();
        //var studentNames = from studentName in (from student in students select student.StudentName) where studentName.Equals("nam") select studentName;
        //Làm đến 8:45
    }
}

public class Student
{
    public string StudentName;
    public int StudentAge;
    public Gender Gender;

    public Student(string studentName, int studentAge, Gender gender)
    {
        StudentName = studentName;
        StudentAge = studentAge;
        Gender = gender;
    }

    public override bool Equals(object obj)
    {
        return (obj as Student).StudentName == this.StudentName;
    }
}

public enum Gender
{
    Male,
    Female,
    Other
}