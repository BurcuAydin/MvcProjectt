using DataAccessLayer.Concretes;
using System;
using System.Collections.Generic;

using System.Linq;

using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class StatisticController : Controller
    {
        Context _context = new Context();

        public ActionResult Index()
        {
            //Toplam kategori sayısı
            var totalCategories = _context.Categories.Count();
            ViewBag.totalCategories = totalCategories;

            //Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            var softwareCategory = _context.Headings.Count(x=> x.CategoryId == 7);
            ViewBag.softwareCategory = softwareCategory;

            // Yazar adında 'a' harfi geçen yazar sayısı
            var writerNameWithA = _context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.writerNameWithA = writerNameWithA;

            //En fazla başlığa sahip kategori adı
            var mostTitles = _context.Headings.Max(x => x.Category.CategoryName);
            ViewBag.mostTitles = mostTitles;

            //Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            var statusTrue = _context.Categories.Count(x => x.CategoryStatus == true);
            var statusFalse = _context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.difference = (statusTrue - statusFalse);

            return View();
            //string session = (string)Session["AdminMail"];
            //ViewBag.a = session;
            //return View();

        }
    }
}