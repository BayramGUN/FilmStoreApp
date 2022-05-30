using FilmsApi.DBO;
using AutoMapper;
using FilmsApi.Entities;

namespace FilmsApi.Application.UserOperations.Commands.CreateUser;

public class CreateUserCommand
{
    public CreateUserModel Model { get; set; }
    private readonly IFilmsDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateUserCommand(IFilmsDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var user = _dbContext.Users.SingleOrDefault(ctx => ctx.Email == Model.Email);
        if(user is not null)
            throw new InvalidOperationException("Bu E-Mail ile daha önce kullanıcı hesabı açılmış!");
        user = _mapper.Map<User>(Model);

        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }
}
public class CreateUserModel
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}