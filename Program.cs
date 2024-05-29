using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


//Vitalii Bobyr - 05/27/24
//Programming 120 - Nested If's and Arrays


class Program
{
    internal static class Method
    {
        static void Main()
        {

            bool condition = true;
            
            #region start_menu
            while (condition)
            {
                Console.OutputEncoding = Encoding.Unicode;
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Create student grade");
                Console.WriteLine("2. Generate and Display 20 Random Grades");
                Console.WriteLine("3. Exit");
                string choice;
                choice = Console.ReadLine().ToLower();
                #endregion
                #region Options
                try
                {

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Create student grade and Calculate than Display Average Grade plus Letter Grade\n");
                            Console.WriteLine("Every student has 10 differente grades, and this mean that you need put 10 differente numbers");
                            int[] studentGrades = new int[10];
                            double Average=0, sum=0;
                            for (int i = 0; i < studentGrades.Length;i++)
                            {   
                               
                                Console.WriteLine("Put some number from 0 to 100");
                                start:
                                int grade = int.Parse(Console.ReadLine());
                                if (grade <= 0 || grade > 100) 
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Try another number from 0 to 100");
                                    Console.ResetColor();
                                    goto start; 
                                }
                                else { studentGrades[i] = grade; }
                            }
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            for (int i = 0; i < studentGrades.Length; i++)
                            {
                                Console.WriteLine($"Index[{i}] : Grade {studentGrades[i]} : Letter Grade: {GradeConvertor(studentGrades[i])}");
                            }
                                Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Our Grades: ");
                            for (int i = 0;i < studentGrades.Length;i++)
                            {
                                Console.Write($" {studentGrades[i]}");
                                sum += studentGrades[i];
                            }
                            Console.WriteLine();
                            
                            Average = sum/studentGrades.Length;
                            Console.Write($"Total sum of all grades in the array: {sum}");
                            Console.Write("  Average Grade: ");
                            Console.Write(Math.Round(Average,2));
                            Console.Write($"  Letter Grade: {GradeConvertor(Average)}");
                            

                            Console.ResetColor();
                            Console.WriteLine();

                            break;

                           case "2":
                            Console.WriteLine("Generate and Display 20 Random Grades");
                            int[] studentGrades_rand = new int[20];
                            double sum_rand = 0,  Average_rand = 0;
                            Random random = new Random();

                            for (int i = 0; i < studentGrades_rand.Length; i++)
                            {
                                studentGrades_rand[i] = random.Next(50,100);
                            }

                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            for (int i = 0; i < studentGrades_rand.Length; i++)
                            {
                                Console.WriteLine($"Index[{i}] : Grade {studentGrades_rand[i]} : Letter Grade: {GradeConvertor(studentGrades_rand[i])}");
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Our Grades: ");
                            for (int i = 0; i < studentGrades_rand.Length; i++)
                            {
                                Console.Write($" {studentGrades_rand[i]}");
                                sum_rand += studentGrades_rand[i];
                            }
                            Console.WriteLine();

                            Average_rand = sum_rand / studentGrades_rand.Length;
                            Console.Write($"Total sum of all grades in the array: {sum_rand}");
                            Console.Write("  Average Grade: ");
                            Console.Write(Math.Round(Average_rand, 2));
                            Console.Write($"  Letter Grade: {GradeConvertor(Average_rand)}");
                            Console.ResetColor();
                            Console.WriteLine();
                            break;

                        case "3":
                            Console.WriteLine("Exit from progarm");
                            condition = false;
                            break;
                                                   
                        default:
                            Console.WriteLine("Invalid option. Please choose again.");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Something going wrong! Please try again!");
                    break;
                };
                #endregion
            }
        }
    }


    static string GradeConvertor(double grade)
    {
        if (grade >= 95) { return "A+"; }
        if (grade >= 90) { return "A-"; }
        if (grade >= 87) { return "B+"; }
        if (grade >= 80) { return "B-"; }
        if (grade >= 77) { return "C+"; }
        if (grade >= 70) { return "C-"; }
        if (grade >= 67) { return "D+"; }
        if (grade >= 60) { return "D-"; }
        return "F";
    }


}

/*If the grade is greater than 100, return "Invalid Input".
For grades between 90 and 100, return "A", and add "-" if the grade is less than or equal to 95.
For grades between 80 and 89, return "B", add "+" if the grade is more than 87, and add "-" if the grade is less than or equal to 83.
For grades between 70 and 79, return "C", add "+" if the grade is more than 77, and add "-" if the grade is less than or equal to 73.
For grades between 60 and 69, return "D", add "+" if the grade is more than 67, and add "-" if the grade is less than or equal to 63.
For grades below 60, return "F".*/