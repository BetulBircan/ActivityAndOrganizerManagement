using ActivitiesDataBase.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiesBusiness.Abstract
{
    public interface IOrganizer
    {
        public IActionResult GetCategoryID(byte categoryId);
        public IActionResult GetCityID(int cityId);
        public IActionResult GetCities();
        public IActionResult GetCategories();
        public IActionResult Create(ActivityViewModel activity);
        public IActionResult UpdatePartial(int id, ActivityViewModel activity);
        public IActionResult Delete(int id);
    }
}
