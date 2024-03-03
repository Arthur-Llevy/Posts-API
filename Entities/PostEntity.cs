using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.entities;


[Table("posts")]
public class PostEntity
{
	[Key]
	public int id { get; set; }
	public string content { get; private set; }

	public PostEntity(string content)
	{
		this.SetContent(content);
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