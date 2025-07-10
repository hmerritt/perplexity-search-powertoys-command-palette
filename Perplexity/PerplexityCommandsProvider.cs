// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Perplexity;

public partial class PerplexityCommandsProvider : CommandProvider
{
    public PerplexityCommandsProvider()
    {
        DisplayName = "Perplexity";
        Icon = IconHelpers.FromRelativePath("Assets\\Perplexity.png");
    }

    public override ICommandItem[] TopLevelCommands()
    {
        return [new PerplexityTopLevelCommandItem()];
    }
}
