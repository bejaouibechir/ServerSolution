using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class PersonneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(PersonneDTO personneDTO)
        {
            Personne personne = new Personne
            {
                Id = personneDTO.Id,
                Name = personneDTO.Name,
            };
            //Appel au code qui persiste les données dans la base 

            



            return View(personneDTO);
        }
    }
}
