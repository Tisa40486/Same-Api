using AutoMapper;
using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;

namespace SameApi.Business.Admin.Query
{
    public class GetAllGenderQuery : IRequest<IEnumerable<GenderResponse>>
    {
        public class GetAllGenderQueryHandler : IRequestHandler<GetAllGenderQuery, IEnumerable<GenderResponse>>
        {
            readonly IApiSameUnitOfWork _uow;
            readonly IMapper _mapper;

            public GetAllGenderQueryHandler(
                IApiSameUnitOfWork ISameApiUnitOfWork, IMapper mapper)
            {
                _uow = ISameApiUnitOfWork;
                _mapper = mapper;
            }
            public async Task<IEnumerable<GenderResponse>> Handle(GetAllGenderQuery request, CancellationToken cancellationToken)
            {
                var data = await _uow.GenderRepository.GetAllAsync();

                return _mapper.Map<IEnumerable<GenderResponse>>(data);               
            }
        }
    }
}