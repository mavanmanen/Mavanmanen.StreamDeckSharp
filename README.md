# Work In Progress

# StreamDeckSharp

This framework will allow you to easily and quickly create plugins for the Elgato Stream Deck software.

All communication with the Stream Deck application is handled through the internal client so you can focus on implementing your actions.

In addition to easy creation of plugins this framework also includes dependency injection and allows you to generate a manifest by simply running the binary without any arguments.


## Usage

At minimum your plugin must follow these rules:

1. Your plugin must have exactly one class that inherits from `StreamDeckPlugin`.
    - This doesn't have to be the program class as is done in the example.
2. Your plugin class must have the attributes `StreamDeckPluginAttribute` and `StreamDeckMinimumOsVersionAttribute`.
3. You must have at least one action class that inherits from `StreamDeckAction`.
4. Your actions must have the `StreamDeckActionAttribute` attribute.

You can then override the needed events in your Plugin and Action classes to implement your code.

## Example
```csharp
using System.Diagnostics;
using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp;
using Mavanmanen.StreamDeckSharp.Attributes;

namespace Mavanmanen.StreamDeckPlugin
{
    [StreamDeckPlugin("pluginName", "Images/pluginIcon", "author", "description", "1.0")]
    [StreamDeckMinimumOsVersion("10", "10.11")]
    public class Program : StreamDeckPlugin
    {
        public static async Task Main(string[] args)
        {
            var client = new StreamDeckClient(args);
            await client.RunAsync();
        }

        public override async Task DeviceDidConnectAsync()
        {
            // Do stuff
        }
    }

    [StreamDeckAction("actionName", "Images/defaultImage")]
    public class Action : StreamDeckAction
    {
        public override async Task OnKeyDownAsync()
        {
            // Do stuff
        }
    }
}
```

## Advanced usage

### Profiles
To use premade profiles you can use the `StreamDeckProfileAttribute` attribute.<br/>
Simply place the attribute(s) on your plugin class to use it.

### Multiple states
To use multiple states, simply use 1 or 2 different `StreamDeckActionStateAttribute` attributes on an action.

### Application monitoring
To monitor other applications, use the `StreamDeckApplicationsToMonitorAttribute` attribute on your plugin class.
