using api.context;
using api.models;
using api.entities;
using Microsoft.EntityFrameworkCore;

namespace api.repositories;

public class PostRepository: IPostRepository
{

	DatabaseContext connection = new DatabaseContext();

	public async Task<List<PostModel>> GetAll()
	{
		List<PostEntity> posts = await connection.Posts.ToListAsync();
		List<PostModel> convertedPosts = new List<PostModel>();

		foreach(PostEntity post in posts)
		{
			PostModel postData = new PostModel(post.content);
			postData.SetId(post.id);
			convertedPosts.Add(postData);
		}
		return convertedPosts;
	}

	public async Task<PostModel> GetById(int id)
	{
		PostEntity post = await connection.Posts.FirstOrDefaultAsync(post => post.id == id);
		PostModel convertedPost = new PostModel(post.GetContent());
		convertedPost.SetId(post.id);
		return convertedPost;
	}

	public async Task<PostEntity> Create(PostModel post)
	{
		PostEntity newPost = new PostEntity(post.content);
		await connection.Posts.AddAsync(newPost);
		await connection.SaveChangesAsync();

		return newPost;
	}

	public async Task<PostEntity> Delete(int id)
	{
		PostEntity postToDelete = await connection.Posts.FirstOrDefaultAsync(post => post.id == id);

		if(postToDelete != null)
		{
			connection.Posts.Remove(postToDelete);
			await connection.SaveChangesAsync();
			return postToDelete;			
		}

		return null;

	}

	public async Task<PostEntity> Edit(int id, string newContent)
	{
		PostEntity postToEdit = await connection.Posts.FirstOrDefaultAsync(post => post.id == id);

		if(postToEdit != null)
		{
			postToEdit.SetContent(newContent);
			await connection.SaveChangesAsync();
			return postToEdit;
		}

		return null;

	}
}