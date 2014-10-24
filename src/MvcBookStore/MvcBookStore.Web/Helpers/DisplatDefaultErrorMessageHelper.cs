using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MvcBookStore.Web.Helpers
{
    public class DisplatDefaultErrorMessageHelper
    {
        public static MvcHtmlString DisplatDefaultErrorMessage(ModelStateDictionary errors)
        {
            StringBuilder html = new StringBuilder();
            foreach (var error in errors.Where(x => x.Key == "DefaultErrorMessage"))
            {
                foreach (var item in error.Value.Errors)
                {
                    html.Append("<div class='alert alert-danger alert-dismissible' role='alert'>");
                    html.Append("    <button type='button' class='close' data-dismiss='alert'><span aria-hidden='true'>&times;</span><span class='sr-only'>Close</span></button>");
                    html.Append(String.Format("    <strong>Ops!</strong> {0}", item.ErrorMessage));
                    html.Append("</div>");
                }
            }

            return MvcHtmlString.Create(html.ToString());
        }
    }
}