using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Tags.Commands;

public record DeleteTagCommand(long Id) : IRequest<long?>;

public class DeleteTagCommandHander : IRequestHandler<DeleteTagCommand, long?>
{
    private readonly IAppDbContext _dbContext;

    public DeleteTagCommandHander(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long?> Handle(DeleteTagCommand command, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Tags
            .FirstOrDefaultAsync(t => t.Id == command.Id, cancellationToken);
        if (entity is null) return null;
        _dbContext.Tags.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return command.Id;
    }
}