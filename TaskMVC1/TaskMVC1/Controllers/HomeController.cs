using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using System.Drawing;
using TaskMVC1.DAL.Services;
using TaskMVC1.Models;
using TaskMVC1.Models.Home;
using TaskMVC1.DAL.Entities;

namespace TaskMVC1.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork("DefaultConnection");
        }

        /// <summary>
        /// Show blog.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            HomeIndexVM indexVM = new HomeIndexVM();
            indexVM.Articles = _unitOfWork.Articles.Show().OrderByDescending(x => x.Date).ToList();
            return View(indexVM);
        }

        /// <summary>
        /// Show reviews.
        /// </summary>
        /// <returns></returns>
        public ActionResult Reviews()
        {
            HomeReviewsVM reviewsVM = new HomeReviewsVM();
            reviewsVM.Reviews = _unitOfWork.Reviews.Show().OrderByDescending(x=>x.Date).ToList();
            return View(reviewsVM);
        }

        /// <summary>
        /// Create review.
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Reviews(Review review)
        {
            review.Date = DateTime.Now;
            _unitOfWork.Reviews.Create(review);
            _unitOfWork.Save();
            return RedirectToAction("Reviews");
        }

        /// <summary>
        /// Show all user answers.
        /// </summary>
        /// <returns></returns>
        public ActionResult Answers()
        {
            List<HomeAnswersVM> answersVM = _unitOfWork.Questionaries.Show().Select(x => new HomeAnswersVM() { Name = x.Name, Date = x.Date,Id=x.Id }).ToList();
            answersVM.Reverse();
            return View(answersVM);
        }

        /// <summary>
        /// Show questions.
        /// </summary>
        /// <returns></returns>
        public ActionResult Questions()
        {
            return View(CreateVMForQuestions());
        }

        /// <summary>
        /// Create view model for questions method.
        /// </summary>
        /// <returns></returns>
        private HomeQuestionsVM CreateVMForQuestions()
        {
            HomeQuestionsVM questionsVM = new HomeQuestionsVM();
            questionsVM.Complectations = _unitOfWork.Complections.Show().Select(x => new { ID = x.Id, Text = x.Name })
                .ToDictionary(x => x.ID, x => x.Text);
            questionsVM.Tags = _unitOfWork.Tags.Show().Select(x => new { ID = x.Id, Text = x.Text })
                 .ToDictionary(x => x.ID, x => x.Text);
            questionsVM.Models = new SelectList(_unitOfWork.Articles.Show().ToList(), "Id", "Title", _unitOfWork.Articles.Show().First().Id);
            return questionsVM;
        }

        /// <summary>
        /// Save user answers.
        /// </summary>
        /// <param name="questionary"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Questions(QuestionaryVM questionary)
        {
            if (questionary.Name == null || questionary.Name.Length == 0)
                ModelState.AddModelError("","Не указано имя!");
            else
            if (questionary.Name.Any(x=>!Char.IsLetter(x)&&x!=' '))
                ModelState.AddModelError("", "Неверно указано имя!");
            if (questionary.Age == null || questionary.Age.Length== 0)
                ModelState.AddModelError("", "Не указан возраст!");
            else
            if (questionary.Age.Any(x => !Char.IsNumber(x))||int.Parse(questionary.Age) ==0)
                ModelState.AddModelError("", "Неверно указан возраст!");
            if (questionary.Model == null || questionary.Model == 0)
                ModelState.AddModelError("", "Не указана модель!");
            if (questionary.Complectation == null || questionary.Complectation == 0)
                ModelState.AddModelError("", "Не указана комплектация!");
            if (!ModelState.IsValid)
            {
                return View(CreateVMForQuestions());
            }
            Questionary questionaryNew = new Questionary() {
                Age = int.Parse(questionary.Age),
                Date = DateTime.Now,
                Name = questionary.Name,
                Article = _unitOfWork.Articles.Get((int)questionary.Model),
                Complectation = _unitOfWork.Complections.Get((int)questionary.Complectation),
                Tags = questionary?.Additional?.Select(x=>_unitOfWork.Tags.Get(x))?.ToList()
            };
            _unitOfWork.Questionaries.Create(questionaryNew);
            _unitOfWork.Save();
            return RedirectToAction("Answers");
        }

        /// <summary>
        /// Show one answer.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Show(int? id)
        {
            HomeShowVM showVM = new HomeShowVM();
            showVM.Questionary = _unitOfWork.Questionaries.Get((int)id);
            return View(showVM);
        }

        /// <summary>
        /// Show form for creating article.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Save new article.
        /// </summary>
        /// <param name="article"></param>
        /// <param name="uploadImage"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Article article, HttpPostedFileBase uploadImage)
        {
            article.Date = DateTime.Now;
            byte[] imageData = null;
            if(uploadImage==null)
            {
                ModelState.AddModelError("","Не загружено фото");
                return View();
            }
            using (var binaryReader = new BinaryReader(uploadImage.InputStream))
            {
                imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
            }
            article.Photo = imageData;
            _unitOfWork.Articles.Create(article);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}