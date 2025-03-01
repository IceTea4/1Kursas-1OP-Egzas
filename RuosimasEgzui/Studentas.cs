using System;

namespace RuosimasEgzui
{
	public class Studentas
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		private int[] Notes { get; set; }

		public Studentas(string name, string surname, int[] notes)
		{
			this.Name = name;
			this.Surname = surname;

			this.Notes = new int[5];

			for (int i = 0; i < 5; i++)
			{
				this.Notes[i] = notes[i];
			}
		}

		public int GetGrade(int index)
		{
			return this.Notes[index];
		}

        public override string ToString()
        {
			string line;

			line = String.Format($"| {"Vardas",-12} | {"Pavardė",-15} |");

			return line;
        }

        public override	bool Equals(object student)
        {
            return this.Name.Equals(((Studentas)student).Name);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        /*
		private string Name;
		private string Surname;
		private int[] Notes;

		public string GetName()
		{
			return this.Name;
		}
		public void SetName(string name)
		{
			this.Name = name;
		}

		public string GetSurname()
		{
			return this.Surname;
		}
        public void SetSurname(string surname)
        {
            this.Surname = surname;
        }

        public int[] GetNotes()
		{
			return this.Notes;
		}
        public void SetNotes(int[] notes)
        {
            this.Notes = notes;
        }
		*/
    }
}

