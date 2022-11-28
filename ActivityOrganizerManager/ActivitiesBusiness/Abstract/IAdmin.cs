using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework.XamlTypes;
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
        public IActionResult Create(Category category);


    }
}
