using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
       
        private readonly ApplicationDbContext _db;
       
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
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
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Order Display Cannot be same as the Name");
            }
            if (ModelState.IsValid)
            {
                 _db.Categories.Update(Category);
                await _db.SaveChangesAsync();
                TempData["Success"] = "Category Edited Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
