using MediatR;
using SameApi.Db.UnitOfWork;

namespace SameApi.Business.comment.Command
{
    public class DeleteCommentCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, int>
    {
        private readonly IApiSameUnitOfWork _iuow;

        public DeleteCommentCommandHandler( IApiSameUnitOfWork iuow)
        {
            _iuow = iuow;
        }

        public async Task<int> Handle(DeleteCommentCommand command, CancellationToken cancellationToken)
        {

            await _iuow.CommentRepository.RemoveByIdAsync(command.Id);

            return command.Id;
        }
    }
}
