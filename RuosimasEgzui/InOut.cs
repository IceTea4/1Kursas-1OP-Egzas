using System;
using System.Text;
using System.IO;

namespace RuosimasEgzui
{
	public class InOut
	{
		public static Grupe ReadStudents(string fileName)
		{
			Grupe students = new Grupe();

			string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);

			for (int i = 0; i < lines.Count(); i++)
			{
				string[] values = lines[i].Split(';');
				string name = values[0];
				string surname = values[1];
                int[] notes = new int[5];

                for (int j = 0; j < 5; j++)
				{
					notes[j] = int.Parse(values[j + 2]);
				}

				Studentas student = new Studentas(name, surname, notes);

				students.Set(student);
			}

			return students;
		}
	}
}

