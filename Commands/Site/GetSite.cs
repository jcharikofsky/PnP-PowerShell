﻿using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.Site
{
    [Cmdlet(VerbsCommon.Get, "SPOSite")]
    [CmdletHelp("Returns the current site collection from the context.",
        Category = CmdletHelpCategory.Sites,
        OutputType = typeof(Microsoft.SharePoint.Client.Site),
        OutputTypeLink = "https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.site.aspx")]
    public class GetSite : SPOCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var site = ClientContext.Site;
            ClientContext.Load(site, s => s.Url, s => s.CompatibilityLevel);
            ClientContext.ExecuteQueryRetry();
            WriteObject(site);
        }
    }

}
