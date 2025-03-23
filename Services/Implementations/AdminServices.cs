using TEZ.Repositories.Interfaces;
public class AdminServices {
    // Admin-specific services go here.
    private readonly IUserRepository _userRepository;
    public AdminServices(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    public 

}