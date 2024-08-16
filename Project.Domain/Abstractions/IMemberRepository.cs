using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Abstractions;

public interface IMemberRepository
{
    Task<IEnumerable<Member>> GetAllMembers();
    Task<Member> GetMemberById(int id);
    Task<Member> AddMember(Member member);
    Task<Member> UpdateMember(Member member);
    Task DeleteMemberById(int memberId);
}
