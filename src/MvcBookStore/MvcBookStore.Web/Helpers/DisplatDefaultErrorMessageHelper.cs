using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace MvcBookStore.Web.Helpers
{
    public class DisplatDefaultErrorMessageHelper
    {
        public static MvcHtmlString DisplatDefaultErrorMessage(ICollection<ModelState> errors)
        {
            StringBuilder html = new StringBuilder();
            foreach (ModelState modelState in errors)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    html.Append("<div class='alert alert-danger alert-dismissible' role='alert'>");
                    html.Append("    <button type='button' class='close' data-dismiss='alert'><span aria-hidden='true'>&times;</span><span class='sr-only'>Close</span></button>");
                    html.Append(String.Format("    <strong>Ops!</strong> {0}", error.ErrorMessage));
                    html.Append("</div>");
                }
            }

            return MvcHtmlString.Create(html.ToString());
        }
    }
}