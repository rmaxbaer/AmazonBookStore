using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amazon.Models;

namespace Amazon.Components
{
    //The naming here is very important; coding by convention requires that the name of this ends with VewComponent
    //This is called by the vc tag in _Layout.cshtml
    public class NavigationMenuViewComponent : ViewComponent
    {
        //In order for us to bring in the categories, we have to bring in the data so we can query it
        private IAmazonRepository repository;
        
        public NavigationMenuViewComponent (IAmazonRepository r)
        {
            repository = r;
        }
        public IViewComponentResult Invoke()
        {
            //This says go out and find what is selected, it helps us bold the buttons
            //This has to match what is in endpoints/url
            //This is passed to default.html
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            //Just like in the Home Controller, we make a partial view and return it
            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                //Order by whatever is normal for that data
                .OrderBy(x => x));
        }
    }
}
