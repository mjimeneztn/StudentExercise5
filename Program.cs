using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using StudentExercises5;
using StudentExercises5.Data;


namespace StudentExercises5
{
    class Program
    {
       /* Create menu options to allow the user to perform the following tasks:
Display all students.
Display all instructors.
Display all exercises.
Display all cohorts.
Search students by last name.
Create a new cohort.
Create a new student and assign them to an existing cohort.
Create a new instructor and assign them to an existing cohort.
Display all students in a given cohort.
Move an existing student to another existing cohort.
List the exercises for a given student.
Assign an existing exercise to an existing student */

        static void Main(string[] args)
        {
            Repository repository = new Repository();
            while (true)
            {
               
                Console.WriteLine();
                Console.WriteLine("------------------------");
                Console.WriteLine("Choose a menu option:");
                Console.WriteLine("1. Display All Students.");
                Console.WriteLine("2. Display All Instructors .");
                Console.WriteLine("3. Display All Cohorts.");
                Console.WriteLine("4. Search students by last name");
                Console.WriteLine("5. Create a New Cohort.");
                Console.WriteLine("6. Add a student");
                Console.WriteLine("7. Add an Instructor");
                Console.WriteLine("8. Display Students by Cohort ");
                string option = Console.ReadLine();
                if (option == "1")
                {

                    List<Student> students = repository.GetAllStudents();
                    foreach (Student stu in students)
                    {

                        Console.WriteLine($"{stu.Id} {stu.GetFullName()}");
                    }

                }

                else if (option == "2")
                {
                    List<Instructor> instructors = repository.GetInstructorsWithCohort();
                    foreach (Instructor i in instructors)
                    {
                        Console.WriteLine($"{i.GetFullName()}");
                    }

                }
                else if (option == "3")
                {
                    List<Cohort> cohorts = repository.GetAllCohorts();
                    foreach (Cohort c in cohorts)
                    {
                        Console.WriteLine($"{c.Id} {c.CohortName}");
                    }
                }
                else if (option == "4")
                {
                    Console.WriteLine($"Enter by Last Name:");
                   Console.Write("> ");
                    string choice = Console.ReadLine();
                    List<Student> students = repository.GetStudentByLastName(choice);
                    if (students.Count >= 1)
                    {
                        foreach (Student s in students)
                            Console.WriteLine($"{s.FirstName} {s.LastName}");
                    } else
                    {
                        Console.WriteLine("that last name is not in our records");

                    }

                }
                else if (option == "5") {
                    Console.WriteLine("What is the name of your cohort?");
                    Console.Write("> ");
                    string choice = Console.ReadLine();
                    var newcohort = new Cohort()
                    {
                        CohortName = $"{choice}"

                    };
                repository.CreateCohort(newcohort);


                }
                else if(option == "6")
                {
                    Console.WriteLine("What is student's First name?");
                    string fname = Console.ReadLine();
                    Console.WriteLine("What is Student's Last name?");
                    string lname = Console.ReadLine();
                    Student student = new Student
                    {
                        FirstName = fname,
                        LastName = lname,
                    };
                    Console.WriteLine("Select cohort ID for student?");
                    List < Cohort > cohorts = repository.GetAllCohorts();
                    foreach(Cohort c in cohorts)
                    {
                        Console.WriteLine($"{c.Id} {c.CohortName}");
                    }
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Cohort newCohort = cohorts.Find(cohort => cohort.Id == choice );
                    if (newCohort != null)
                    {
                        repository.AddStudentWithCohort(student, newCohort);
                    }
                
                } else if (option == "7")
                {
                    Console.WriteLine("What is Instructors's First name?");
                    string fname = Console.ReadLine();
                    Console.WriteLine("What is Instructors's Last name?");
                    string lname = Console.ReadLine();
                    Instructor instructor = new Instructor
                    {
                        FirstName = fname,
                        LastName = lname
                    };
                    Console.WriteLine("Assign cohort for Instructor by Id");
                    List<Cohort> cohorts = repository.GetAllCohorts();
                    foreach (Cohort c in cohorts)
                    {
                        Console.WriteLine($"{c.Id} {c.CohortName}");
                    }
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Cohort newCohort = cohorts.Find(cohort => cohort.Id == choice);
                    if (newCohort != null)
                    {
                        repository.AddInstructorWithCohort(instructor, newCohort);
                          
                    }

                } else if (option == "8")
                {
                    Console.WriteLine("Select Cohort by ID to view students");
                    List<Cohort> cohorts = repository.GetAllCohorts();
                    foreach (Cohort c in cohorts)
                    {
                        Console.WriteLine($"{c.Id} {c.CohortName}");
                    }
                    int choice = Convert.ToInt32(Console.ReadLine());
                    List<Student> students = repository.GetStudentsByCohortId(choice);
                    if (students.Count >= 1)
                    {
                        foreach (Student s in students)
                        {
                            Console.WriteLine($"{s.FirstName} {s.LastName}");
                        }
                      
                    }
                    else
                    {
                        Console.WriteLine("There are currently 0 students in this cohort");
                    }

                }
                else
                {
                    Console.WriteLine($"Invalid option: {option}");
                }
            }
        }
    }
}
