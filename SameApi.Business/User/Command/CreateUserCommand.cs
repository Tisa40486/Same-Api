using AutoMapper;
using Google.Cloud.Firestore;
using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;
using SameApi.Model;

namespace SameApi.Business.User.Command
{
    public class CreateUserCommand : UserInput, IRequest
    {
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IApiSameUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(
            IApiSameUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var now = Timestamp.GetCurrentTimestamp();

            if (await _uow.UserRepository.EmailExistsAsync(request.Email))
                Update(request, now);
            else
                Create(request, now);
        }

        #region Create and Update method
        private async void Create(UserInput input, Timestamp now)
        {

            UserDao user = _mapper.Map<UserDao>(input);

            user.CreatedAt = now;
            user.UpdatedAt = now;

            await _uow.UserRepository.CreateAsync(user);
        }

        private async void Update(UserInput input, Timestamp now)
        {
            UserDao user = _mapper.Map<UserDao>(input);

            user.UpdatedAt = now;

            await _uow.UserRepository.UpdateAsync(user);
        }
        #endregion
    }
}