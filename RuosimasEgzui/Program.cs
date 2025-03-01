using System;

namespace RuosimasEgzui
{
    class Program
    {
        static void Main(string[] args)
        {
            Grupe students = InOut.ReadStudents(@"../../../Studentai.csv");

            int lowGradesCount = TaskUtils.FindLowMarks(students);

            Console.WriteLine(lowGradesCount);
        }
    }
}


