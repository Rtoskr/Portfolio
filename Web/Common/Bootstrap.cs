using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Web.Common
{
    public static class Bootstrap
    {
        public static string MakeAlert(BootstrapAlert alertType, string Message)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("<div style='padding-top:4px;padding-bottom:4px;' class=\"alert alert-{0} alert-dismissable fade in\">\n", alertType.ToString());
            sb.AppendLine("\t<a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>");
            sb.AppendLine("\t" + Message);
            sb.AppendLine("</div>");

            return sb.ToString();
        }
        public static string MakeProgressBar(int percentage,bool utilizationColor = true,bool striped = true, bool active = true)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<div class=\"progress\">");
            sb.AppendFormat("\t<div class='progress-bar {0} {2} {3}'  role='progressbar' aria-valuenow='{1}' aria-valuemin='0' aria-valuemax='100' style='width:{1}%'>\n",
                utilizationColor == true ? GetProgressType(percentage) : "progress-bar-info",
                percentage,
                striped == true ? "progress-bar-striped" : string.Empty,
                active == true ? "active" : string.Empty
                );
            sb.AppendFormat("\t\t{0}%", percentage);
            sb.AppendLine("\t</div>");
            sb.AppendLine("</div>");

            return sb.ToString();
        }

        private static string GetProgressType(int percentage)
        {
            if (percentage >= 0 && percentage <= 50)
            {
                return "progress-bar-success";
            }
            else if (percentage > 50 && percentage <= 80)
            {
                return "progress-bar-warning";
            }
            else if (percentage > 80 && percentage <= 100)
            {
                return "progress-bar-danger";
            }
            else
            {
                return "progress-bar-info";
            }
        }
    }
    
    public enum BootstrapAlert
    {
        success,
        info,
        warning,
        danger
    }
}