using MediatR;
using SameApi.Db.UnitOfWork;

namespace SameApi.Business.Post.Command
{
    public class DeletePostCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, int>
    {
        private readonly IApiSameUnitOfWork _iuow;

        public DeletePostCommandHandler( IApiSameUnitOfWork iuow)
        {
            _iuow = iuow;
        }

        public async Task<int> Handle(DeletePostCommand command, CancellationToken cancellationToken)
        {

            await _iuow.PostRepository.RemoveByIdAsync(command.Id);

            return command.Id;
        }
    }
}
