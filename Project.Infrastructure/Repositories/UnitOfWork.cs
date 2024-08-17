using Project.Domain.Abstractions;
using Project.Infrastructure.Context;

namespace Project.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private IMemberRepository? _memberRepo;
    private readonly AppDbContext _db;

    public UnitOfWork(AppDbContext db)
    {
        _db = db;
    }

    public IMemberRepository MemberRepository
    {
        get
        {
            return _memberRepo = _memberRepo ?? 
                new MemberRepository(_db);
        }
    }

    public async Task CommitAsync()
    {
        await _db.SaveChangesAsync();
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}
