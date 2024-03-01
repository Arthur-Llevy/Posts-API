using api.entities;

namespace api.repositories;

public interface IPostRepository
{
	Task<List<PostEntity>> GetAll();
}