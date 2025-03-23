public interface IUserService {
    Task<string> RegisterUserAsync(Register request);
    Task<GetLogin?> LoginUser(Login request);

}