namespace api.models;

public class PostModel
{
	public int id { get; private set; }
	public string content { get; set; }


	public PostModel(string Content)
	{
		this.content = Content;
	}

	public void SetId(int Id)
	{
		this.id = Id;
	}

	public int GetId()
	{
		return this.id;
	}

	public void SetContent(string Content)
	{
		this.content = Content;
	}

	public string GetContent()
	{
		return this.content;
	}
	
}