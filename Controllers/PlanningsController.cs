using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task2AsepPlanning.Data;
using Task2AsepPlanning.Models;

namespace Task2AsepPlanning.Controllers
{
    public class PlanningsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlanningsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Plannings
        public async Task<IActionResult> Index()
        {
            var latestData = await _context.Plannings
                .OrderByDescending(p => p.CreatedAt)
                .FirstOrDefaultAsync();

            if (latestData == null)
                return View(null);
            return View(latestData);
        }


        // GET: Plannings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plannings == null)
            {
                return NotFound();
            }

            var planning = await _context.Plannings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planning == null)
            {
                return NotFound();
            }

            return View(planning);
        }

        // GET: Plannings/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Senin,Selasa,Rabu,Kamis,Jumat,Sabtu,Minggu")] Planning planning)
        {
            if (ModelState.IsValid)
            {
                var hariList = new List<string> { "Senin", "Selasa", "Rabu", "Kamis", "Jumat", "Sabtu", "Minggu" };

                var inputHari = hariList
                    .Select(hari => new
                    {
                        Hari = hari,
                        Value = (int)typeof(Planning).GetProperty(hari).GetValue(planning)
                    })
                    .Where(x => x.Value > 0)
                    .ToList();

                if (!inputHari.Any())
                {
                    ModelState.AddModelError("", "Minimal satu hari kerja harus diisi.");
                    return View(planning);
                }

                int total = inputHari.Sum(x => x.Value);
                int rata = total / inputHari.Count;
                int sisa = total % inputHari.Count;

                var urutHari = inputHari
                    .OrderByDescending(x => x.Value)
                    .Select(x => x.Hari)
                    .ToList();

                // Set result 0 dulu semua
                foreach (var hari in hariList)
                {
                    typeof(Planning).GetProperty(hari + "Result").SetValue(planning, 0);
                }

                // Set rata-rata
                foreach (var hari in urutHari)
                {
                    typeof(Planning).GetProperty(hari + "Result").SetValue(planning, rata);
                }

                // Tambah sisa ke hari dengan input terbanyak
                for (int i = 0; i < sisa; i++)
                {
                    string hari = urutHari[i];
                    var prop = typeof(Planning).GetProperty(hari + "Result");
                    int current = (int)prop.GetValue(planning);
                    prop.SetValue(planning, current + 1);
                }

                planning.CreatedAt = DateTime.Now;
                _context.Add(planning);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(planning);
        }

    }  
}
