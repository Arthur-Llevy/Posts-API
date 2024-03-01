using api.models;
using api.repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers;

[Route("[controller]")]
[ApiController]

public class PostController: ControllerBase
{
	PostRepository Posts = new PostRepository();

	[HttpGet]
	public async Task<ActionResult> GetAll()
	{
		try
		{
			var posts = await Posts.GetAll();
			return Ok(posts);
		} catch (Exception ex)
		{
			return StatusCode(500, "Falha ao buscar posts.");
		}
	}

	[HttpGet("{id}")]
	public async Task<ActionResult> GetById(int id)
	{
		try
		{
			var post = await Posts.GetById(id);

			if(post != null)
			{
				return Ok(post);
			}

			return NoContent();

		} catch (Exception ex)
		{
			return StatusCode(500, "Falha ao buscar posts.");
		}
	}
}