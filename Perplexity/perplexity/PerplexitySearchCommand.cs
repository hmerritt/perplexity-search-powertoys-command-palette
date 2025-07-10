// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Diagnostics;
using System.Web;
using Windows.Foundation;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Perplexity;

public class PerplexitySearchCommand : InvokableCommand
{
    public string Id => "PerplexitySearch";

    public string Name => "Perplexity Search";

    public string Title => "Search with Perplexity";

    public string Description => "Searches Perplexity AI for the given query.";

    public IIconInfo Icon => IconHelpers.FromRelativePath("Assets\\Perplexity.png");

    public string? Query { get; set; }

    public Action? CloseOverlay { get; set; }

    public event TypedEventHandler<object, IPropChangedEventArgs> PropChanged;

    public bool CanExecute()
    {
        return !string.IsNullOrWhiteSpace(Query);
    }

    public void Execute()
    {
        if (string.IsNullOrWhiteSpace(Query))
        {
            return;
        }

        string encodedQuery = HttpUtility.UrlEncode(Query);
        string url = $"https://www.perplexity.ai/search?q={encodedQuery}";

        try
        {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
        catch
        {
            // Log error or handle exception
        }

        CloseOverlay?.Invoke();
    }
}
