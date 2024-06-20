using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            // Implement the Index method here
            return View(userlist);

        }
 
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Implement the details method here
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
 
        // GET: User/Create
        public ActionResult Create()
        {
            //Implement the Create method here
            return View();
        }
 
        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Implement the Create method (POST) here
            if (ModelState.IsValid)
            {
                // Assuming your User model has an Id property that uniquely identifies each user
                // and that it's an auto-incrementing value managed by the database or manually before insertion.
                // Here, we manually set it for simplicity, assuming no database is involved.
                if (!userlist.Any())
                {
                    user.Id = 1; // Start with ID 1 if the list is empty
                }
                else
                {
                    user.Id = userlist.Max(u => u.Id) + 1; // Increment the ID based on the highest ID present
                }

                userlist.Add(user); // Add the new user to the list
                return RedirectToAction("Index"); // Redirect to the Index action to show the list of users
            }

            // If the model state is not valid, return the same view to show validation errors
            return View(user);
        }
 
        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.
            var userToEdit = userlist.FirstOrDefault(u => u.Id == id);
            if (userToEdit == null)
            {
                return HttpNotFound();
            }

            return View(userToEdit);
        }
 
        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.
            if (ModelState.IsValid)
            {
                var userToUpdate = userlist.FirstOrDefault(u => u.Id == id);
                if (userToUpdate == null)
                {
                    return HttpNotFound();
                }

                // Update the user details
                userToUpdate.Name = user.Name;
                userToUpdate.Email = user.Email;
                // Update other fields as necessary

                return RedirectToAction("Index");
            }

            // If the model state is not valid, return the user to the Edit view to correct the input
            return View(user);

        }
 
        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here
            var userToDelete = userlist.FirstOrDefault(u => u.Id == id);
            if (userToDelete == null)
            {
                return HttpNotFound();
            }

            userlist.Remove(userToDelete); // Remove the user from the list
            return RedirectToAction("Index"); // Redirect to the Index action to show the updated list of users

        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Implement the Delete method (POST) here
            var userToDelete = userlist.FirstOrDefault(u => u.Id == id);
            if (userToDelete == null)
            {
                return HttpNotFound();
            }

            userlist.Remove(userToDelete); // Remove the user from the list
            return RedirectToAction("Index"); // Redirect to the Index action to show the updated list of users
        }
    }
}
