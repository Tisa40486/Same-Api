using AutoMapper;
using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;
using SameApi.Model.LKP;

namespace SameApi.Business.Admin.Command
{
    public class CreateProfessionCommand : ProfessionInput, IRequest
    {
    }
    public class CreateProfessionCommandHandler : IRequestHandler<CreateProfessionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IApiSameUnitOfWork _uow;

        public CreateProfessionCommandHandler(IMapper mapper, IApiSameUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task Handle(CreateProfessionCommand command, CancellationToken cancellationToken)
        {
            var dao = _mapper.Map<LKP_ProfessionDao>(command);

            await _uow.ProfessionRepository.AddAndSaveAsync(dao);
        }
    }
}