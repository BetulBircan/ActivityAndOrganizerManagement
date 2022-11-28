using ActivitiesDataBase.Models;
using ActivitiesDataBase.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiesBusiness.Abstract
{
    public interface IAdmin
    {
        public IActionResult Create(CategoryViewModel newCategory);

        public IActionResult Create(CityViewModel newCity);

        public IActionResult UpdatePartial(byte categoryId, CategoryViewModel category);
        public IActionResult Delete(int categoryID);

       

        public IActionResult UpdatePartial(int cityId, CityViewModel ity);
    }

}

