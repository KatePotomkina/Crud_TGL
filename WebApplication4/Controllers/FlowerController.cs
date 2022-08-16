using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
	public class FlowerController : Controller
	{
		public IActionResult Flower()
		{
			List<FlowerModel> list = new List<FlowerModel>();
			FlowerDAO cartoonDAO = new FlowerDAO();
			list = cartoonDAO.FetchAll();
			return View("Flower", list);
					}
		public IActionResult Details(int Id  )
		{
			FlowerModel flower;
			FlowerDAO flowerDAO = new FlowerDAO();
			 flower = flowerDAO.FetchOne(Id);
			return View("Details", flower);
					}
		public IActionResult Create()
		{
			return View("FlowerForm");
		}
		
		 
		public IActionResult ProcessCreate( FlowerModel flowerModel)
		{
			FlowerDAO flowerDAO = new FlowerDAO();
			flowerDAO.CreateAndEdit(flowerModel);
			return View("FlowerForm", flowerModel);
					}

		

		public IActionResult Edit(int id)
		{

			FlowerDAO flowerDAO = new FlowerDAO();
			FlowerModel flowermodel = flowerDAO.FetchOne(id);
			return View("FlowerForm", flowermodel);
		}
		public IActionResult Delete(int id)
		{
			FlowerDAO flowerDAO = new FlowerDAO();
			flowerDAO.Delete(id);
			List<FlowerModel> flowerslist = flowerDAO.FetchAll();
			return View("Flower", flowerslist);
		}
			}
}
