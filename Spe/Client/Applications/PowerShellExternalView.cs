﻿using System;
using Sitecore.Text;
using Sitecore.Web;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Sheer;
using Spe.Core.Settings;

namespace Spe.Client.Applications
{
    public class PowerShellExternalView : BaseForm
    {
        public Literal Result;
        public Literal DialogHeader;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var settings = ApplicationSettings.GetInstance(ApplicationNames.Context, false);
            var title = WebUtil.GetQueryString("spe_t");
            if (!string.IsNullOrEmpty(title))
            {
                DialogHeader.Text = title;
            }
            var url = WebUtil.GetQueryString("spe_url");
            if(string.IsNullOrEmpty(url)) 
            {
                url = "http://blog.najmanowicz.com/sitecore-powershell-console/";
            }

            var urlStr = new UrlString(url);
            var urlParams = WebUtil.ParseQueryString(WebUtil.GetRawUrl());
            foreach (var key in urlParams.Keys)
            {
                if (!key.StartsWith("spe_", StringComparison.OrdinalIgnoreCase) &&
                    !key.Equals("xmlcontrol", StringComparison.OrdinalIgnoreCase))
                {
                    urlStr.Parameters.Add(key, urlParams[key]);
                }
            }
            Result.Text = $"<iframe class='externalViewer' src='{urlStr}'></iframe>";
        }

    }
}
