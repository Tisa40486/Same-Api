using AutoMapper;
using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;

namespace SameApi.Business.Admin.Query
{
    public class GetAllProfessionQuery : IRequest<IEnumerable<ProfessionResponse>>
    {
    }
    public class GetAllProfessionQueryHandler : IRequestHandler<GetAllProfessionQuery, IEnumerable<ProfessionResponse>>
    {
        readonly IApiSameUnitOfWork _uow;
        readonly IMapper _mapper;

        public GetAllProfessionQueryHandler(
            IApiSameUnitOfWork ISameApiUnitOfWork, IMapper mapper)
        {
            _uow = ISameApiUnitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProfessionResponse>> Handle(GetAllProfessionQuery request, CancellationToken cancellationToken)
        {
            var data = await _uow.ProfessionRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ProfessionResponse>>(data);
        }
    }
}