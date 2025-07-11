// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Diagnostics;
using System.Web;
using Windows.Foundation;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using Perplexity.Commands;

namespace Perplexity;

public class PerplexityTopLevelCommandItem : CommandItem
{
    public PerplexityTopLevelCommandItem()
        : base(new PerplexityPage())
    {
        SetDefaultTitle();
        Icon = IconHelpers.FromRelativePath("Assets\\Perplexity-rounded.png");
    }

    private void SetDefaultTitle() => Title = "Perplexity";

    public void UpdateQuery(string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            SetDefaultTitle();
            Command = new PerplexityPage();
        }
        else
        {
            Title = query;
            Command = new SearchPerplexityCommand(query);
        }
    }
}
