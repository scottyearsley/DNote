using System.Threading.Tasks;

namespace Zestware.DNote.Components;

public partial class MarkdownEditorComponent
{
    string markdownValue = "# Markdown Editor\nThis is a test";
    string markdownHtml;

    protected override void OnInitialized()
    {
        markdownHtml = Markdig.Markdown.ToHtml(markdownValue ?? string.Empty);
        
        base.OnInitialized();
    }

    Task OnMarkdownValueChanged(string value)
    {
        return Task.CompletedTask;
    }

    Task OnMarkdownValueHTMLChanged(string value)
    {
        markdownHtml = value;
        return Task.CompletedTask;
    }
}
