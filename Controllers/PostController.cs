using api.models;
using api.repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using api.entities;

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
			List<PostModel> posts = await Posts.GetAll();

			if(posts != null)
			{
				return Ok(posts);
			}

			return NoContent();

		} catch (Exception ex)
		{
			return StatusCode(500, new { message = "Falha ao buscar posts." });
		}
	}

	[HttpGet("{id}")]
	public async Task<ActionResult> GetById(int id)
	{
		try
		{
			PostModel post = await Posts.GetById(id);

			if(post != null)
			{
				return Ok(post);
			}

			return NoContent();

		} catch (Exception ex)
		{
			return StatusCode(500, new { message = "Falha ao buscar posts." });
		}
	}

	[HttpPost]
	public async Task<IActionResult> Create(PostModel newPost)
	{
		try
		{
			var post = await Posts.Create(newPost);

			return Ok(post);

		} catch (Exception ex)
		{
			return StatusCode(500, new { message = "Falha ao ciar um novo post." });
		}
	}

	[HttpPatch("{id}")]
	public async Task<IActionResult> Edit(int id, string newContent)
	{
		try
		{
			PostEntity editedPost = await Posts.Edit(id, newContent);

			if(editedPost != null)
			{
				return Ok(editedPost);
			}

			return NotFound(new { message = "Post não encontrado." });
		} catch (Exception ex)
		{
			return StatusCode(500, new { message = "Falha ao editar o post." });
		}

	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		try
		{
			PostEntity deletedPost = await Posts.Delete(id);

			if(deletedPost != null)
			{
				return Ok(deletedPost);
			}

			return NotFound(new { message = "Post não encontrado" });

		} catch (Exception ex)
		{
			return StatusCode(500, new { message = "Falha ao excluir novo post." });
		}
	}
}