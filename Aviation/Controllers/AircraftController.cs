using Aviation.Models;
using Aviation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aviation.Controllers
{
    public class AircraftController : Controller
    {
        // GET: Aircraft/GetAllAircraftDetails    
        public ActionResult GetAllAircraftDetails()
        {

            SpoterRepository AirRepo = new SpoterRepository();
            ModelState.Clear();
            return View(AirRepo.GetAllAircraftDetails());
        }
        // GET: Aircraft/Create    
        public ActionResult Create()
        {
            return View();
        }
        //the first parameter is the option that we choose and the second parameter will use the textbox value  
        public ActionResult SearchAircraft(string option, string search)
        {
            SpoterRepository AirRepo = new SpoterRepository();
            ModelState.Clear();
           
            return View("GetAllAircraftDetails", AirRepo.SearchAircraftDetails(option,search));
            //if a user choose the radio button option as Subject  
            //if (option == "Subjects")
            //{
            //    //Index action method will return a view with a student records based on what a user specify the value in textbox  
            //    return View(db.Students.Where(x = > x.Subjects == search || search == null).ToList());
            //}
            //else if (option == "Gender")
            //{
            //    return View(db.Students.Where(x = > x.Gender == search || search == null).ToList());
            //}
            //else
            //{
            //    return View(db.Students.Where(x = > x.Name.StartsWith(search) || search == null).ToList());
            //}
        }
        public ActionResult Index()
        {
            SpoterRepository AirRepo = new SpoterRepository();
            ModelState.Clear();
            return View("GetAllAircraftDetails", AirRepo.GetAllAircraftDetails());
        }

        // POST: Aircraft/Create    
        [HttpPost]
        public ActionResult Create(AircraftModel Air)
        {
            try
            {
                SpoterRepository AirRepo = new SpoterRepository();
                if (ModelState.IsValid)
                {
                   

                    if (AirRepo.AddAircraft(Air))
                    {
                        ViewBag.Message = "Aircraft details added successfully";
                    }
                }
                return RedirectToAction("GetAllAircraftDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aircraft/EditAircraftDetails/5    
        public ActionResult EditAircraftDetails(int ID)
        {
            SpoterRepository AirRepo = new SpoterRepository();



            return View(AirRepo.GetAllAircraftDetails().Find(Air => Air.ID == ID));

        }

        public ActionResult DisplayAircraftDetails(int ID)
        {
            SpoterRepository AirRepo = new SpoterRepository();



            return View("Details",AirRepo.GetAllAircraftDetails().Find(Air => Air.ID == ID));

        }
        
        // POST: Aircraft/EditAircraftDetails/5    
        [HttpPost]

        public ActionResult EditAircraftDetails(int ID, AircraftModel obj)
        {
            try
            {
                SpoterRepository AirRepo = new SpoterRepository();

                AirRepo.UpdateAircraft(obj);
                return RedirectToAction("GetAllAircraftDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aircraft/DeleteAircraft/1    
        public ActionResult DeleteAircraft(int ID)
        {
            try
            {
                SpoterRepository AirRepo = new SpoterRepository();
                if (AirRepo.DeleteAircraft(ID))
                {
                    ViewBag.AlertMsg = "Aircraft details deleted successfully";

                }
                return RedirectToAction("GetAllAircraftDetails");

            }
            catch
            {
                return View();
            }
        }
    }
}