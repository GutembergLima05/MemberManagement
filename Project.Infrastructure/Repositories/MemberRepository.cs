
using Microsoft.EntityFrameworkCore;
using Project.Domain.Abstractions;
using Project.Domain.Entities;
using Project.Infrastructure.Context;

namespace Project.Infrastructure.Repositories;

public class MemberRepository : IMemberRepository
{
    protected readonly AppDbContext _db;

    public MemberRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Member> AddMember(Member member)
    {
        if (member is null)
            throw new ArgumentNullException(nameof(member));

        await _db.Members.AddAsync(member);
        return member;
    }

    public async Task<Member> DeleteMemberById(int memberId)
    {
        var member = await GetMemberById(memberId);

        if (member is null)
            throw new InvalidOperationException("Member not found");

        _db.Members.Remove(member);
        return member;
    }

    public async Task<IEnumerable<Member>> GetAllMembers()
    {
        var allMembers = await _db.Members.ToListAsync();

        return allMembers ?? Enumerable.Empty<Member>();
    }

    public async Task<Member> GetMemberById(int id)
    {
        var member = await _db.Members.FindAsync(id);

        if (member is null)
            throw new InvalidOperationException("Member not found");

        return member;
    }

    public async Task<Member> UpdateMember(Member member)
    {
        if (member is null)
            throw new ArgumentNullException(nameof(member));

        _db.Members.Update(member);
        return member;
    }
}
