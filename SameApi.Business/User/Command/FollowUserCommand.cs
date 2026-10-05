using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;

namespace SameApi.Business.User.Command
{
    public class FollowUserCommand : InteractionModel, IRequest<int>
    {

    }
    public class FollowUserCommandHandler : IRequestHandler<FollowUserCommand, int>
    {
        private IApiSameUnitOfWork _uow { get; }
        public FollowUserCommandHandler(IApiSameUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Handle(FollowUserCommand command, CancellationToken cancellationToken)
        {

            if (!command.TargetId.HasValue)
                throw new ArgumentNullException(nameof(command.TargetId));

            var user = await _uow.UserRepository.GetByIdAsync(command.TargetId.Value, withNoTracking: false);

            if (user == null)
                throw new Exception("User is null");

            user.NumberFollowers++;

            await _uow.SaveChangesAsync();
            return user.NumberFollowers;
        }
    }
}
