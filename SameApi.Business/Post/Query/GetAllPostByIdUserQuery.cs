using AutoMapper;
using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;

namespace SameApi.Business.Post.Query
{
    public class GetAllCommentByIdPostQuery : IRequest<IEnumerable<PostResponse>>
    {
        public int UserId { get; set; }
    }

    public class GetAllPostByIdUserQueryHandler : IRequestHandler<GetAllCommentByIdPostQuery, IEnumerable<PostResponse>>
    {
        readonly IApiSameUnitOfWork _uow;
        readonly IMapper _mapper;

        public GetAllPostByIdUserQueryHandler(
            IApiSameUnitOfWork uow,
            IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PostResponse>> Handle(GetAllCommentByIdPostQuery request, CancellationToken cancellationToken)
        {

            var user = await _uow.UserRepository.GetByIdAsync(request.UserId);

            var data = await _uow.PostRepository.GetPostByUserIdAsync(request.UserId);

            var result = _mapper.Map<IEnumerable<PostResponse>>(data);

            return result;
        }
    }
}
