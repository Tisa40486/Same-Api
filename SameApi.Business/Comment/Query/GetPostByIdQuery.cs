using AutoMapper;
using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;

namespace SameApi.Business.comment.Query
{
    public class GetCommentByIdQuery : IRequest<PostResponse>
    {
        public int Id { get; set; }
    }

    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, PostResponse?>
    {
        readonly IApiSameUnitOfWork _uow;
        readonly IMapper _mapper;

        public GetCommentByIdQueryHandler(
            IApiSameUnitOfWork uow,
            IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<PostResponse?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _uow.PostRepository.GetByIdAsync(request.Id);

            if (data == null)
                return null;

            var result = _mapper.Map<PostResponse>(data);
            return result;
        }
    }
}