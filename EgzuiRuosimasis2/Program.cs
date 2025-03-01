using System;

namespace EgzuiRuosimasis2
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        private int[] Grades { get; set; }

        public Student(string name, string surname, int[] grades)
        {
            this.Name = name;
            this.Surname = surname;

            this.Grades = new int[grades.Length];

            for (int i = 0; i < grades.Length; i++)
            {
                this.Grades[i] = grades[i];
            }
        }

        public override string ToString()
        {
            string line;

            line = String.Format($"| {Name,-12} | {Surname,-15}");

            return line;
        }

        public override bool Equals(object student)
        {
            return this.Name.Equals(((Student)student).Name);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public bool OnlyGoodGrades()
        {
            for (int i = 0; i < Grades.Length; i++)
            {
                if (Grades[i] < 9)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class Group
    {
        private Student[] students;
        public int Count { get; set; }
        private int Capacity;

        public Group(int capacity = 16)
        {
            this.Capacity = capacity;
            this.students = new Student[capacity];
        }

        public void EnsureCapacity(int minimum)
        {
            if (minimum > this.Capacity)
            {
                Student[] temp = new Student[minimum];

                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.students[i];
                }

                this.Capacity = minimum;
                this.students = temp;
            }
        }

        public void Add(Student student)
        {
            if (this.Contains(student))
            {
                return;
            }

            if (this.Count == this.Capacity)
            {
                this.EnsureCapacity(this.Capacity * 2);
            }

            this.students[Count++] = student;
        }

        public Student Get(int index)
        {
            return this.students[index];
        }

        public bool Contains(Student student)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.students[i].Equals(student))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(Student student)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.students[i].Equals(student))
                {
                    return i;
                }
            }

            return -1;
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index <= this.Capacity)
            {
                for (int i = index + 1; i < this.Count; i++)
                {
                    this.students[i - 1] = this.students[i];
                }

                this.Count--;
            }
        }

        public void Remove(Student student)
        {
            this.RemoveAt(this.IndexOf(student));
        }
    }

    public static class TaskUtils
    {
        public static int GoodStudents(Group A)
        {
            int count = 0;

            for (int i = 0; i < A.Count; i++)
            {
                if (A.Get(i).OnlyGoodGrades())
                {
                    count++;
                }
            }

            return count;
        }
    }
}
