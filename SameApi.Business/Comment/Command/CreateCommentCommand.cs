using AutoMapper;
using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;
using SameApi.Model;

namespace SameApi.Business.comment.Command
{
    public class CreateCommentCommand : CommentInput, IRequest
    {
    }
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IApiSameUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CreateCommentCommandHandler(
            IApiSameUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }
        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var dao = _mapper.Map<CommentDao>(request);
          
            var post = await  _uow.PostRepository.GetByIdAsync(request.PostId.Value);
            if (post != null)
            {
                post.Comments_count++;
                await _uow.PostRepository.UpdateAsync(post);
            }

            await _uow.CommentRepository.AddAndSaveAsync(dao);
        }
    }
}