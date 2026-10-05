using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;

namespace SameApi.Business.Post.Command
{
    public class AddALikePostCommand : InteractionModel, IRequest<int>
    { 
    }
    public class AddALikePostCommandHandler : IRequestHandler<AddALikePostCommand, int>
    {
        public IApiSameUnitOfWork _uow { get; }
        public AddALikePostCommandHandler(
           IApiSameUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<int> Handle(AddALikePostCommand request, CancellationToken cancellationToken)
        {
            if (!request.TargetId.HasValue)
                throw new ArgumentNullException(nameof(request.TargetId));

            var post = await _uow.PostRepository.GetByIdAsync(request.TargetId.Value, false);

            if (post == null)
                throw new Exception("Cannot be null");

            post.Likes_count++;
            await _uow.SaveChangesAsync();

            return post.Likes_count.Value;
        }
    }
}
