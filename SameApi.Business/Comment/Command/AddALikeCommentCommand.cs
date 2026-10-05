using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;

namespace SameApi.Business.comment.Command
{
    public class AddALikeCommentCommand :InteractionModel, IRequest<int>
    { 
    }
    public class AddALikeCommentCommandHandler : IRequestHandler<AddALikeCommentCommand, int>
    {
        private IApiSameUnitOfWork _uow { get; }
        public AddALikeCommentCommandHandler(
           IApiSameUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<int> Handle(AddALikeCommentCommand request, CancellationToken cancellationToken)
        {
            if (!request.TargetId.HasValue)
                throw new ArgumentNullException(nameof(request.TargetId));

            var comment = await _uow.CommentRepository.GetByIdAsync(request.TargetId.Value, false);

            if (comment == null)
                throw new Exception("Cannot be null");

            comment.LikesCount++;
            await _uow.SaveChangesAsync();

            return comment.LikesCount.Value;
        }
    }
}