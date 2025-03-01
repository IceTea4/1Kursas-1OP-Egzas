using System;

namespace RuosimasEgzui
{
	public static class TaskUtils
	{
        public static int FindLowMarks(Grupe students)
        {
            int rez = 0;

            for (int i = 0; i < students.Count; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (students.Get(i).GetGrade(j) < 5)
                    {
                        rez++;
                        break;
                    }
                }
            }

            return rez;
        }
	}
}

