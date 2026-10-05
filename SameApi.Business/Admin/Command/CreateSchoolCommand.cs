using AutoMapper;
using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;
using SameApi.Model.LKP;

namespace SameApi.Business.Admin.Command
{
    public class CreateSchoolCommand : Schoolnput, IRequest
    {
    }
    public class CreateSchoolCommandHandler : IRequestHandler<CreateSchoolCommand>
    {
        private readonly IMapper _mapper;
        private readonly IApiSameUnitOfWork _uow;
        public CreateSchoolCommandHandler(IMapper mapper, IApiSameUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }
        public async Task Handle(CreateSchoolCommand command, CancellationToken cancellationToken)
        {
            var newSchool = new LKP_SchoolDao
            {
                Name = command.Name,
                Professions = new List<LKP_ProfessionDao>()
            };

            if (command.ProfessionIds != null && command.ProfessionIds.Any())
            {
                foreach (var professionId in command.ProfessionIds)
                {
                    var professionEntity = await _uow.ProfessionRepository.GetByIdAsync(professionId, withNoTracking: false);

                    if (professionEntity != null)
                    {
                        newSchool.Professions.Add(professionEntity);
                    }
                }
            }
            await _uow.SchoolRepository.AddAndSaveAsync(newSchool);
        }
    }
}