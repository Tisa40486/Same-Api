using AutoMapper;
using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;
using SameApi.Model;

namespace SameApi.Business.comment.Command
{
    public class UpdateCommentCommand : CommentInput, IRequest<int?>
    {
        public int id { get; set; }
    }
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, int?>
    {
        readonly IApiSameUnitOfWork _apiSameUnitOfWork;
        readonly IMapper _mapper;

        public UpdateCommentCommandHandler(
            IApiSameUnitOfWork apiSameUnitOfWork,
            IMapper mapper)
        {
            _apiSameUnitOfWork = apiSameUnitOfWork;
            _mapper = mapper;
        }

        public async Task<int?> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var data = await _apiSameUnitOfWork.CommentRepository.GetByIdAsync(request.id, false);

            if (data == null)
                return null;

            _mapper.Map<CommentInput, CommentDao>(request, data);

            await _apiSameUnitOfWork.CommentRepository.UpdateAsync(data);

            return data.Id;
        }
    }
}