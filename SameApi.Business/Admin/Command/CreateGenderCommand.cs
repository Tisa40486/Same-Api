using AutoMapper;
using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;
using SameApi.Model.LKP;

namespace SameApi.Business.Admin.Command
{
    public class CreateGenderCommand : GenderInput, IRequest
    {

        public class CreateGenderCommandHandler : IRequestHandler<CreateGenderCommand>
        {
            private readonly IMapper _mapper;
            private readonly IApiSameUnitOfWork _uow;

            public CreateGenderCommandHandler(IMapper mapper, IApiSameUnitOfWork uow)
            {
                _mapper = mapper;
                _uow = uow;
            }

            public async Task Handle(CreateGenderCommand command, CancellationToken cancellationToken)
            {
                var dao = _mapper.Map<LKP_GenderDao>(command);

                await _uow.GenderRepository.AddAndSaveAsync(dao); 
            }
        }

    }
}