using AutoMapper;
using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;
using SameApi.Model;

namespace SameApi.Business.User.Command
{
    public class UpdateUserCommand : UserInput, IRequest<int?>
    {
        public int Id { get; set; }
    }
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int?>
    {
        readonly IApiSameUnitOfWork _apiSameUnitOfWork;
        readonly IMapper _mapper;

        public UpdateUserCommandHandler(
            IApiSameUnitOfWork apiSameUnitOfWork,
            IMapper mapper)
        {
            _apiSameUnitOfWork = apiSameUnitOfWork;
            _mapper = mapper;
        }

        public async Task<int?> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var data = await _apiSameUnitOfWork.UserRepository.GetByIdAsync(request.Id, false);

            if (data == null)
                return null;

            _mapper.Map<UserInput, UserDao>(request, data);

            await _apiSameUnitOfWork.UserRepository.UpdateAsync(data);

            return data.Id;
        }
    }
}