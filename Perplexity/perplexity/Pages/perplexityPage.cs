// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Perplexity;

internal sealed partial class PerplexityPage : DynamicListPage
{
    private List<ListItem> allItems = []; 

    public PerplexityPage()
    {
        Icon = IconHelpers.FromRelativePath("Assets\\Perplexity.png");
        Title = "Perplexity";
        Name = "Open";
    }

     public override void UpdateSearchText(string oldSearch, string newSearch)
    {
        // Get the current query from the context (assume it's available via Query property or similar)
        string query = newSearch;
        string url = $"https://www.perplexity.ai/search?q={Uri.EscapeDataString(query)}";

        allItems = [
            new ListItem(new OpenUrlCommand(url))
            {
                Icon = IconHelpers.FromRelativePath("Assets\\Perplexity.png"),
                Title = $"Search Perplexity for '{query}'",
                Subtitle = url
            }
        ];
    }

     public override IListItem[] GetItems() => [.. allItems];
}
