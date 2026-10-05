using AutoMapper;
using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;
using SameApi.Model;

namespace SameApi.Business.User.Command
{
    public class CreatePostCommand : PostInput, IRequest
    {

    }
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand>
    {
        private readonly IApiSameUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CreatePostCommandHandler(
            IApiSameUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }
        public async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var dao = _mapper.Map<PostDao>(request);
            dao.Created_at = DateTime.UtcNow;
                
            await _uow.PostRepository.AddAndSaveAsync(dao);
        }
    }
}