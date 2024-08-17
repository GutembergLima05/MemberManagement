using Project.Domain.Entities;

namespace Project.Domain.Abstractions;

public interface IMemberRepository
{
    Task<IEnumerable<Member>> GetAllMembers();
    Task<Member> GetMemberById(int id);
    Task<Member> AddMember(Member member);
    Task<Member> UpdateMember(Member member);
    Task<Member> DeleteMemberById(int memberId);
}
