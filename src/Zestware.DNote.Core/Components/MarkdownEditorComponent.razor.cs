namespace Zestware.DNote.Components;

public partial class MarkdownEditorComponent
{
    private string? _markdownValue = "# Markdown Editor\nThis is a test";
    private string? _markdownHtml;

    private bool IsEditing { get; set; }

    protected override void OnInitialized()
    {
        _markdownHtml = Markdig.Markdown.ToHtml(_markdownValue ?? string.Empty);
        
        base.OnInitialized();
    }

    void OnPreviewClick()
    {
        IsEditing = true;
    }
    
    private Task OnMarkdownValueChanged(string value)
    {
        return Task.CompletedTask;
    }

    private Task OnMarkdownValueHTMLChanged(string value)
    {
        _markdownHtml = value;
        return Task.CompletedTask;
    }
}
