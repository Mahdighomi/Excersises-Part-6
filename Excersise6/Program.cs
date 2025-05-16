using Excersise6;
using System.Runtime.CompilerServices;


StudentManagment.LoadStudents();
while (true)
{
    Console.WriteLine("Student Record System");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. View Students");
    Console.WriteLine("3. Delete Student");
    Console.WriteLine("4. Exit");
    Console.Write("Enter your choice: ");

    switch (Console.ReadLine())
    {
        case "1":
            StudentManagment.AddStudent();
            break;
        case "2":
            StudentManagment.ViewStudent();
            break;
        case "3":
            StudentManagment.DeleteStudent();
            break;
        case "4":
            StudentManagment.SaveStudent();
            return;
        default:
            Console.Clear();
            Console.WriteLine("Invalid choice! Please try again.\n");
            break;
    }
}




