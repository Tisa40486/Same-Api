using AutoMapper;
using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;

namespace SameApi.Business.Admin.Query
{
    public class GetAllSchoolQuery : IRequest<IEnumerable<SchoolResponse>>
    {
    }
    public class GetAllSchoolQueryHandler : IRequestHandler<GetAllSchoolQuery, IEnumerable<SchoolResponse>>
    {
        readonly IApiSameUnitOfWork _uow;
        readonly IMapper _mapper;

        public GetAllSchoolQueryHandler(
            IApiSameUnitOfWork ISameApiUnitOfWork, IMapper mapper)
        {
            _uow = ISameApiUnitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SchoolResponse>> Handle(GetAllSchoolQuery request, CancellationToken cancellationToken)
        {
            var data = await _uow.SchoolRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<SchoolResponse>>(data);
        }
    }
}