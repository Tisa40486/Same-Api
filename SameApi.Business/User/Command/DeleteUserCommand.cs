using AutoMapper;
using MediatR;
using SameApi.Db.UnitOfWork;

namespace SameApi.Business.User.Command
{
    public class DeleteUserCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApiSameUnitOfWork _iuow;

        public DeleteUserCommandHandler(IMapper mapper, IApiSameUnitOfWork iuow)
        {
            _mapper = mapper;
            _iuow = iuow;
        }

        public async Task<int> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {

            await _iuow.UserRepository.RemoveByIdAsync(command.Id);

            return command.Id;
        }
    }
}