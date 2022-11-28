using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiesBusiness.Abstract
{
    public interface ISubscriber
    {
        public IActionResult GetActivities();
        public IActionResult GetActivitiesByCategory(byte categoryId);
        public IActionResult GetActivitiesByCity(int cityId);

    }
}
