// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Web;
using Windows.Foundation;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Perplexity;

internal sealed partial class PerplexityPage : DynamicListPage
{
    private List<ListItem> allItems = []; 

    public PerplexityPage()
    {
        Icon = IconHelpers.FromRelativePath("Assets\\Perplexity-rounded.png");
        Title = "Perplexity";
        Name = "Open";
    }

    public string? Query { get; set; }

    public override void UpdateSearchText(string oldSearch, string newSearch)
    {
        string url = $"https://www.perplexity.ai/search?q={Uri.EscapeDataString(newSearch)}";

        allItems = [
            new ListItem(new OpenUrlCommand(url))
            {
                Icon = IconHelpers.FromRelativePath("Assets\\Perplexity-rounded.png"),
                Title = $"Search Perplexity for '{newSearch}'",
                Subtitle = url
            }
        ];

        // Notify that the items have changed
        RaiseItemsChanged(0);
    }

     public override IListItem[] GetItems() => [.. allItems];
}
