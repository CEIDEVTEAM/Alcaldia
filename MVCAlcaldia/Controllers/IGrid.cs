using System.Web.Mvc;

namespace MVCAlcaldia.Controllers
{
    internal interface IGrid<T>
    {
        ViewContext ViewContext { get; set; }
        object Query { get; set; }
        object Columns { get; set; }
    }
}