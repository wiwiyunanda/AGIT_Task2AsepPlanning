using System;
using System.ComponentModel.DataAnnotations;

namespace Task2AsepPlanning.Models
{
	public class Planning
	{
		public int Id { get; set; }

		// Input 7 hari
		public int Senin { get; set; }
		public int Selasa { get; set; }
		public int Rabu { get; set; }
		public int Kamis { get; set; }
		public int Jumat { get; set; }
		public int Sabtu { get; set; }
		public int Minggu { get; set; }

		// Output 7 hari
		public int SeninResult { get; set; }
		public int SelasaResult { get; set; }
		public int RabuResult { get; set; }
		public int KamisResult { get; set; }
		public int JumatResult { get; set; }
		public int SabtuResult { get; set; }
		public int MingguResult { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.Now;
	}
}
