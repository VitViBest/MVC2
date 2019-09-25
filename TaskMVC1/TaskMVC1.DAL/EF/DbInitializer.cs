using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TaskMVC1.DAL.Entities;
using System.IO;
using System.Drawing;

namespace TaskMVC1.DAL.EF
{
    /// <summary>
    /// Database initializer.
    /// </summary>
    class DbInitializer:DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected virtual List<Article> CreateArticles()
        {
            List<Article> articles = new List<Article>();
            articles.Add(new Article
            {
                Date = new DateTime(2019, 09, 09),
                Text = "Ford Mustang GT Fastback 2019 года выпуска для рынка Южной Африки.",
                Title = "GT Fastback 2019",
                Photo = _fileToBytes(@"C:\Users\User\source\repos\TaskMVC1\TaskMVC1.DAL\Images\First.jpg")
            });
            articles.Add(new Article
            {
                Date = new DateTime(2019, 08, 12),
                Text = "Ford Mustang GT by Designo Motoring on Vossen Wheels (HF-2) 2019 года выпуска.",
                Title = "GT by Designo Motoring",
                Photo = _fileToBytes(@"C:\Users\User\source\repos\TaskMVC1\TaskMVC1.DAL\Images\Second.jpg")
            });
            articles.Add(new Article
            {
                Date = new DateTime(2019, 07, 11),
                Text = "Ford Mustang GT on Vossen Wheels (HF-2) 2019 года выпуска.",
                Title = "GT on Vossen Wheels",
                Photo = _fileToBytes(@"C:\Users\User\source\repos\TaskMVC1\TaskMVC1.DAL\Images\Thirt.jpg")
            });
            articles.Add(new Article
            {
                Date = new DateTime(2018, 12, 12),
                Text = "Ford Mustang GT Performance Pack 2 2018 года выпуска для рынка США и Канады.",
                Title = "GT Performance Pack 2",
                Photo = _fileToBytes(@"C:\Users\User\source\repos\TaskMVC1\TaskMVC1.DAL\Images\Fourth.jpg")
            });
            articles.Add(new Article
            {
                Date = new DateTime(2018, 11, 4),
                Text = "Ford Mustang GT Performance Pack 2 2018 года выпуска для рынка США и Канады.",
                Title = "EcoBoost TJIN",
                Photo = _fileToBytes(@"C:\Users\User\source\repos\TaskMVC1\TaskMVC1.DAL\Images\Fiveth.jpg")
            });
            articles.Add(new Article
            {
                Date = new DateTime(2018, 05, 22),
                Text = "Ford Mustang Raptor by X-Tomi Design 2018 года выпуска.",
                Title = "Raptor",
                Photo = _fileToBytes(@"C:\Users\User\source\repos\TaskMVC1\TaskMVC1.DAL\Images\Sixth.jpg")
            });
            articles.Add(new Article
            {
                Date = new DateTime(2018, 03, 15),
                Text = "Ford Eagle Squadron Mustang GT 2018 года выпуска.",
                Title = "Eagle Squadron",
                Photo = _fileToBytes(@"C:\Users\User\source\repos\TaskMVC1\TaskMVC1.DAL\Images\Seventh.jpg")
            });
            articles.Add(new Article
            {
                Date = new DateTime(2018, 01, 01),
                Text = "Ford Mustang by CWDesign on Forgiato Wheels (Fratello-ECL) 2018 года выпуска.",
                Title = " Mustang by CWDesign",
                Photo = _fileToBytes(@"C:\Users\User\source\repos\TaskMVC1\TaskMVC1.DAL\Images\Eighth.jpg")
            });
            return articles;
        }

        protected virtual List<Review> CreateReviews() {
            List<Review> reviews = new List<Review>();
            reviews.Add(new Review()
            {
                Date = new DateTime(2019, 06, 12),
                Name = "Кулешов Арнольд",
                Text = "Все очень интересно и понятно."
            });
            reviews.Add(new Review()
            {
                Date = new DateTime(2019, 01, 06),
                Name = "Иванов Евгений",
                Text = "Купил свой первый мустанг, очень рад."
            });
            reviews.Add(new Review()
            {
                Date = new DateTime(2018, 12, 12),
                Name = "Демченко Роман",
                Text = "Считаю, что это лучшая марка авто."
            });
            reviews.Add(new Review()
            {
                Date = new DateTime(2018, 11, 11),
                Name = "Солодовников Василий",
                Text = "Скоро накоплю на последнюю модель."
            });
            reviews.Add(new Review()
            {
                Date = new DateTime(2018, 09, 12),
                Name = "Марченко Эдуард",
                Text = "Считаю, что мощность важнее внешнего вида."
            });
            return reviews;
        }

        protected virtual List<Tag> CreateTags()
        {
            List<Tag> tags = new List<Tag>();
            tags.Add(new Tag() { Text = "Полный привод" });
            tags.Add(new Tag() { Text = "Бронированные стекла" });
            tags.Add(new Tag() { Text = "Парамагнитная покраска" });
            tags.Add(new Tag() { Text = "Повышенный комфорт" });
            tags.Add(new Tag() { Text = "Гоночный тюнинг" });
            return tags;
        }

        protected virtual List<Complectation> CreteComplectation()
        {
            List<Complectation> complectations = new List<Complectation>();
            complectations.Add(new Complectation() { Name = "Эконом" });
            complectations.Add(new Complectation() { Name = "Стандарт" });
            complectations.Add(new Complectation() { Name = "Максимум" });
            return complectations;
        }

        /// <summary>
        /// Create database with test data.
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(BlogContext context)
        {
            var articles = CreateArticles();
            context.Articles.AddRange(articles);
            var reviews = CreateReviews();
            context.Reviews.AddRange(reviews);
            var tags = CreateTags();
            context.Tags.AddRange(tags);
            var complectations = CreteComplectation();
            context.Complectations.AddRange(complectations);
            base.Seed(context);
        }

        private byte[] _fileToBytes(string path)
        {
            Image image = Image.FromFile(path);
            MemoryStream memory = new MemoryStream();
            image.Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] i = memory.ToArray();
            return i;
        }
    }
}
