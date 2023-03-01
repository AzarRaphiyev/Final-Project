using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobBoard.Areas.manage.Controllers
{
	[Area("manage")]
	public class QuestionsAndAnswerController : Controller
	{
		private readonly JobBoardContext jobBoardContext;

		public QuestionsAndAnswerController(JobBoardContext jobBoardContext)
		{
			this.jobBoardContext = jobBoardContext;
		}
        #region Index
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Index(int page=1)
		{
			
			var query = jobBoardContext.questionsAndAnswers.AsQueryable();

			var paginatedlist = PaginationList<QuestionsAndAnswer>.Create(query, 3, page);
			return View(paginatedlist);
		}
        #endregion

        #region Create
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Create() 
		{
			return View();
		}
		[HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Create(QuestionsAndAnswer questionsAndAnswer) 
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			if (questionsAndAnswer==null)
			{
				return View("error");
			}
			jobBoardContext.questionsAndAnswers.Add(questionsAndAnswer);
			jobBoardContext.SaveChanges();
			return RedirectToAction("Index");
		}


        #endregion

        #region Update

        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Update(int id)
		{
			QuestionsAndAnswer questionsAndAnswer=jobBoardContext.questionsAndAnswers.FirstOrDefault(x=>x.Id==id);
			if (questionsAndAnswer==null)
			{
				return View("error");
			}
			return View(questionsAndAnswer);
		}
		[HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Update(QuestionsAndAnswer questionsAnsver)
		{
			if (questionsAnsver == null)
			{
				return View("error");
			}
			QuestionsAndAnswer ExtquestionsAndAnswer=jobBoardContext.questionsAndAnswers.FirstOrDefault(x=>x.Id== questionsAnsver.Id);
			if (ExtquestionsAndAnswer==null)
			{
				return View("error");
			}
            if (!ModelState.IsValid)
            {
                return View();
            }
            ExtquestionsAndAnswer.Question= questionsAnsver.Question;
			ExtquestionsAndAnswer.Answer= questionsAnsver.Answer;
			jobBoardContext.SaveChanges();
			return RedirectToAction("Index");
		}
        #endregion

        #region Delete

        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Delete(int id)
		{
			QuestionsAndAnswer answer=jobBoardContext.questionsAndAnswers.FirstOrDefault(x=>x.Id==id);
			if (answer==null)
			{
				return View("error");
			}
			jobBoardContext.questionsAndAnswers.Remove(answer);
			jobBoardContext.SaveChanges();
			return Ok();
		}
        #endregion
	}
}
