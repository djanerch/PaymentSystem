using App.Data;
using App.Data.Models;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            if (DateTime.Now.Year != context.GeneralDatas.First().Year)
            {
                context.GeneralDatas.First().Year = DateTime.Now.Year;
                var allUnPay = context.Peoples.Where(x => x.Sum == 0).ToList();

                foreach (var item in allUnPay)
                {
                    var summary = new Summary()
                    {
                        FullName = item.FullName,
                        Status = item.Status,
                        Year = context.GeneralDatas.First().Year - 1
                    };
                    context.Summaries.Add(summary);
                }

                foreach (var item in context.Peoples)
                {
                    item.Sum = 0;
                }

                context.SaveChanges();
            }
            var list = context.Peoples;

            return View(list);
        }
        public IActionResult Unpay()
        {
            var list = context.Peoples.Where(x => x.Sum <= 0);

            return View(list);
        }

        public IActionResult Edit(int Id)
        {
            var dbPeople = context.Peoples.Find(Id);

            PeopleEditModel people = new PeopleEditModel()
            {
                Id = dbPeople.Id,
                FullName = dbPeople.FullName,
                Status = dbPeople.Status
            };

            return View(people);
        }
        [HttpPost]
        public IActionResult Edit(PeopleEditModel editModel)
        {
            var people = context.Peoples.Find(editModel.Id);

            people.Sum = editModel.Sum;

            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int Id)
        {
            var people = context.Peoples.Find(Id);

            context.Peoples.Remove(people);

            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PeopleInputModel people)
        {
            var dbPeople = new People()
            {
                Id = people.Id,
                FullName = people.FullName,
                Status = people.Status
            };

            var list = context.Peoples.FirstOrDefault(x => x.FullName == dbPeople.FullName);

            if (list != null)
            {
                return View();
            }
            else
            {
                context.Peoples.Add(dbPeople);

                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public IActionResult Index(string searchQuery = "")
        {
            var list = context.Peoples.Where(x => x.FullName.Contains(searchQuery));

            return View(list);
        }

        public IActionResult Summary()
        {
            return View(context.Summaries.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
