using AutoMapper;
using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;

namespace SameApi.Business.Post.Query
{
    public class GetPostByIdQuery : IRequest<PostResponse>
    {
        public int Id { get; set; }
    }

    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostResponse?>
    {
        readonly IApiSameUnitOfWork _uow;
        readonly IMapper _mapper;

        public GetPostByIdQueryHandler(
            IApiSameUnitOfWork uow,
            IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<PostResponse?> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _uow.PostRepository.GetByIdAsync(request.Id);

            if (data == null)
                return null;

            var result = _mapper.Map<PostResponse>(data);
            return result;
        }
    }
}