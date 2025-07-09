// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Windows.Foundation;

namespace perplexity;

public partial class perplexityCommandsProvider : CommandProvider
{
    public perplexityCommandsProvider()
    {
        DisplayName = "Perplexity";
        Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png");
    }

    public override ICommandItem[] TopLevelCommands()
    {
        return Array.Empty<ICommandItem>();
    }

    public IEnumerable<ICommandItem> Commands(string query)
    {
        if (!string.IsNullOrWhiteSpace(query))
        {
            yield return new CommandItem
            {
                Title = $"Search Perplexity for \"{query}\"",
                Icon = Icon,
                Command = new PerplexityCommand($"https://www.perplexity.ai/search?q={Uri.EscapeDataString(query)}"),
            };
        }
    }
}

public class PerplexityCommand : IInvokableCommand, ICommand, INotifyPropChanged
{
    private readonly string _url;

    public string Id { get; }
    public string Name { get; }
    public IIconInfo Icon { get; }

    public event TypedEventHandler<object, IPropChangedEventArgs>? PropChanged;

    public PerplexityCommand(string url)
    {
        _url = url;
        Id = Guid.NewGuid().ToString(); // Generate a unique ID
        Name = "Perplexity Search"; // A descriptive name
        Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png"); // Use the same icon as the provider
    }

    public ICommandResult Invoke(object? sender)
    {
        using var process = new Process();
        process.StartInfo.FileName = _url;
        process.StartInfo.UseShellExecute = true;
        process.Start();

        return new CommandResult();
    }
}
