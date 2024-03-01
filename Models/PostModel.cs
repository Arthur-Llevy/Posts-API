namespace api.models;

public class PostsModel
{
	private string? content;

	public PostsModel(string content)
	{
		this.SetContent(content);
	}

	public void SetContent(string content)
	{
		this.content = content;
	}

	public string? GetContent()
	{
		return this.content;
	}
}