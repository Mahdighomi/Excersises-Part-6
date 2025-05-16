using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excersise6
{
    public class StudentManagment
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        private const string FilePath = "C:\\UNI.txt"; 
        private static readonly Dictionary<int, string> Students = new Dictionary<int, string>();



        public static void AddStudent()
        {
            try
            {
                Console.Write("Enter student ID: ");
                int id = int.Parse(Console.ReadLine());

                if (Students.ContainsKey(id))
                {
                    Console.Clear();
                    Console.WriteLine("Student ID already exists!\n");
                    return;
                }

                Console.Write("Enter student name: ");
                string name = Console.ReadLine();

                Students.Add(id, name);
                SaveStudent();
                Console.Clear();
                Console.WriteLine("Student added successfully!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\n");
            }
        }
        public static void ViewStudent()
        {
            if (Students.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No students found!\n");
                return;
            }
            Console.Clear();
            Console.WriteLine("\nStudent List:");
            foreach (var student in Students.OrderBy(s => s.Key))
            {
                Console.WriteLine($"ID: {student.Key}, Name: {student.Value}");
            }
            Console.WriteLine();
        }
        public static void DeleteStudent()
        {
            try
            {
                Console.Write("Enter student ID to delete: ");
                int id = int.Parse(Console.ReadLine());

                if (Students.Remove(id))
                {
                    Console.Clear();
                    SaveStudent();
                    Console.WriteLine("Student deleted successfully!\n");
                }
                else
                {
                    Console.WriteLine("Student not found!\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\n");
            }
        }
        public static void SaveStudent()
        {
            try
            {
                using (FileStream fileStream = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    foreach (var student in Students)
                    {
                        writer.WriteLine($"{student.Key} || {student.Value}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving students: {ex.Message}\n");
            }
        }
        public static void LoadStudents()
        {
            try
            {
                if (!File.Exists(FilePath)) return;

                Students.Clear();
                foreach (string line in File.ReadAllLines(FilePath))
                {
                    string[] parts = line.Split(new[] { "||" }, StringSplitOptions.None);
                    if (parts.Length == 2 && int.TryParse(parts[0], out int id))  
                    {
                        Students[id] = parts[1];
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading students: {ex.Message}\n");
            }
        }
    }
}
