using System;

namespace RuosimasEgzui
{
	public class Grupe
	{
		private Studentas[] students;
		public int Count { get; set; }
		private int Capacity;

		public Grupe(int capacity = 16)
		{
			this.students = new Studentas[capacity];
			this.Capacity = capacity;
		}

		public void EnsureCapacity(int minimum)
		{
			if (minimum > this.Capacity)
			{
				Studentas[] temp = new Studentas[minimum];

				for (int i = 0; i < this.Count; i++)
				{
					temp[i] = this.students[i];
				}

				this.Capacity = minimum;
				this.students = temp;
			}
		}

		public Studentas Get(int index)
		{
			return students[index];
		}

		public void Set(Studentas student)
		{
			if (this.Contains(student))
			{
				return;
			}

			if (this.Count == this.Capacity)
			{
				this.EnsureCapacity(Capacity * 2);
			}

			this.students[Count++] = student;
		}

		public bool Contains(Studentas student)
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

		public int IndexOf(Studentas student)
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

		public void Remove(Studentas student)
		{
			int index = this.IndexOf(student);

			this.RemoveAt(index);
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
	}
}

