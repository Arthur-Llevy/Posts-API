using api.entities;
using api.models;

namespace api.repositories;

public interface IPostRepository
{
	Task<List<PostModel>> GetAll();
	Task<PostModel> GetById(int id);
	Task<PostEntity> Create(PostModel post);
	Task<PostEntity> Delete(int id);
	Task<PostEntity> Edit(int id, string newContent);
}