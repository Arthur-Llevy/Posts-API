using api.context;
using api.models;
using api.entities;
using Microsoft.EntityFrameworkCore;

namespace api.repositories;

public class PostRepository: IPostRepository
{

	DatabaseContext connection = new DatabaseContext();

	public async Task<List<PostEntity>> GetAll()
	{
		List<PostEntity> posts = await connection.Posts.ToListAsync();
		return posts;
	}

	public async Task<PostEntity> GetById(int id)
	{
		PostEntity post = await connection.Posts.FirstOrDefaultAsync(post => post.id == id);
		return post;
	}
}