using AutoMapper;
using MediatR;
using SameApi.Db.Repository;
using SameApi.Dto;

namespace SameApi.Business.User.Command
{
    public class GetAllUserQuery : IRequest<IEnumerable<UserResponse>>
    {
    }
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<UserResponse>>
    {
        readonly IUserRepository _userRepository;
        readonly IMapper _mapper;

        public GetAllUserQueryHandler(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var data = await _userRepository.GetAllAsync();

            var result = _mapper.Map<IEnumerable<UserResponse>>(data);
            return result;
        }
    }
}