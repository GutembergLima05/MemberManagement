using Microsoft.AspNetCore.Mvc;
using Project.Domain.Abstractions;
using Project.Domain.Entities;

namespace Project.API.Controllers;

[Route("[controller]")]
[ApiController]
public class MembersController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public MembersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMember()
    {
        var members = await _unitOfWork.MemberRepository.GetAllMembers();

        return Ok(members);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMemberById(int id)
    {
        var member = await _unitOfWork.MemberRepository.GetMemberById(id);

        return member != null ? Ok(member) : NotFound("Member not found!");
    }

    [HttpPost]
    public async Task<IActionResult> AddMember(Member member)
    {
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMember(Member updatedMember)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMemberById(int id)
    {
        var member = await _unitOfWork.MemberRepository.DeleteMemberById(id);

        if (member is null)
            return NotFound("Member not found.");

        await _unitOfWork.CommitAsync();
        return Ok(member);
    }
}
