using AutoMapper;
using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;
using SameApi.Model.LKP;

namespace SameApi.Business.Admin.Command
{
    public class DeleteGenderCommand : GenderInput, IRequest<int>
    {

    }
    public class DeleteGenderCommandHandler : IRequestHandler<DeleteGenderCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApiSameUnitOfWork _uow;

        public DeleteGenderCommandHandler(IMapper mapper, IApiSameUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<int> Handle(DeleteGenderCommand command, CancellationToken cancellationToken)
        {
            var dao = _mapper.Map<LKP_GenderDao>(command);

            await _uow.GenderRepository.RemoveByIdAsync(dao.Id);

            return dao.Id;
        }
    }
}