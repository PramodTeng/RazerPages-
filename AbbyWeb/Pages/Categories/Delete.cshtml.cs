using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;

        }
        public void OnGet(int id)
        {
            Category = _db.Categories.Find(id);
            //Category = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category = _db.Categories.SingleOrDefault(u => u.Id == id);
            //Category = _db.Categories.Where(u => u.Id == id).FirstOrDefault();





        }

        public async Task<IActionResult> OnPost()
        {

            var categoryFromDb = _db.Categories.Find(Category.Id);
            if (categoryFromDb != null)
            {

                _db.Categories.Remove(categoryFromDb);
                await _db.SaveChangesAsync();
                TempData["Success"] = "Category Deleted Successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}


