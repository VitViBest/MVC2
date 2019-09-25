using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskMVC1.Helpers
{
    public static class InputListHelper
    {
        /// <summary>
        /// Create radio list.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="values"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static MvcHtmlString CreateRadioList(this HtmlHelper html, Dictionary< int,string> values, string name)
        {
            var group = new TagBuilder("div");
            group.MergeAttribute("class", " btn-group btn-group-toggle");
            group.MergeAttribute("data-toggle", "buttons");
            foreach (var i in values)
            {
                var label = new TagBuilder("label");
                label.MergeAttribute("class","btn btn-light");
                var input = new TagBuilder("input");
                input.MergeAttribute("type","radio");
                input.MergeAttribute("name",name);
                input.MergeAttribute("autocomplete", "off");
                input.MergeAttribute("value",i.Key.ToString());
                label.InnerHtml += input.ToString();
                label.InnerHtml += i.Value;
                group.InnerHtml += label.ToString();
            }
            return new MvcHtmlString(group.ToString());
        }

        /// <summary>
        /// Create checkbox list
        /// </summary>
        /// <param name="html"></param>
        /// <param name="values"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static MvcHtmlString CreateCheckList(this HtmlHelper html, Dictionary<int, string> values, string name)
        {
            var result = new TagBuilder("div");
            int c = 0;
            foreach (var i in values)
            {
                var item = new TagBuilder("div");
                item.MergeAttribute("class", "custom-control custom-switch");
                var label = new TagBuilder("label");
                label.MergeAttribute("class", "custom-control-label");
                label.MergeAttribute("for", $"switch{c}");
                label.InnerHtml += i.Value;
                var input = new TagBuilder("input");
                input.MergeAttribute("type", "checkbox");
                input.MergeAttribute("name", name);
                input.MergeAttribute("class", "custom-control-input");
                input.MergeAttribute("id", $"switch{c++}");
                input.MergeAttribute("value", i.Key.ToString());
                item.InnerHtml += input.ToString();
                item.InnerHtml += label.ToString();
                result.InnerHtml += item.ToString();
            }
            return new MvcHtmlString(result.ToString());
        }
    }
}