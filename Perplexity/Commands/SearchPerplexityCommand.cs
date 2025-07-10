using System;
using System.Web;
using Windows.Foundation;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Perplexity.Commands;

internal sealed partial class SearchPerplexityCommand : InvokableCommand
{
    public string Query { get; internal set; } = string.Empty;
    public string Url { get; private set; }

    internal SearchPerplexityCommand(string query)
    {
        Query = query;
        Name = "Perplexity";
        Icon = IconHelpers.FromRelativePath("Assets\\Perplexity.png");
        Url = $"https://www.perplexity.ai/search?q={Uri.EscapeDataString(query)}";
    }

    public override CommandResult Invoke()
    {
        new OpenUrlCommand(Url);
        return CommandResult.Dismiss();
    }
}