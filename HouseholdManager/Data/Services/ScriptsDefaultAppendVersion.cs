using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace HouseholdManager.Data.Services
{
    /// <summary>
    /// Cache-busting for sitewide scripts
    /// </summary>
    public class ScriptsDefaultAppendVersion : ITagHelperInitializer<ScriptTagHelper>
    {
        private const bool DefaultAppendVersion = true;

        public void Initialize(ScriptTagHelper scriptTagHelper, ViewContext context) 
        {
            scriptTagHelper.AppendVersion = DefaultAppendVersion;
        }
    }
}
