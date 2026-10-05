using AutoMapper;
using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;
using SameApi.Model;

namespace SameApi.Business.Post.Command
{
    public class UpdatePostCommand : PostInput, IRequest<int?>
    {
        public int Id { get; set; }
    }
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, int?>
    {
        readonly IApiSameUnitOfWork _apiSameUnitOfWork;
        readonly IMapper _mapper;

        public UpdatePostCommandHandler(
            IApiSameUnitOfWork apiSameUnitOfWork,
            IMapper mapper)
        {
            _apiSameUnitOfWork = apiSameUnitOfWork;
            _mapper = mapper;
        }

        public async Task<int?> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var data = await _apiSameUnitOfWork.PostRepository.GetByIdAsync(request.Id, false);

            if (data == null)
                return null;

            _mapper.Map<PostInput, PostDao>(request, data);

            data.Updated_at = DateTime.UtcNow;

            await _apiSameUnitOfWork.PostRepository.UpdateAsync(data);

            return data.Id;
        }
    }
}