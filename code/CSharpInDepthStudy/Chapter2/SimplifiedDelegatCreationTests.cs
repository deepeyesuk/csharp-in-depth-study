using Shouldly;

namespace CSharpInDepthStudy.Chapter2;

public class SimplifiedDelegatCreationTests
{
    private void HandleButtonClick(object sender, EventArgs e)
    {
        Console.WriteLine(e.ToString());
    }

    [Fact]
    public void Should_create_event_handler()
    {
        var handler = new EventHandler(HandleButtonClick);

        handler.ShouldNotBeNull();
    }
}