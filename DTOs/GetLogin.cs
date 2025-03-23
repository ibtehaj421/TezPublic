using TEZ.Models;

public class GetLogin {
    public long id { get; set; }
    public string name { get; set; } = String.Empty;
    public string email { get; set; } = String.Empty;
    public string password { get; set; } = String.Empty;
    public string token { get; set; } = String.Empty;
    public Role role { get; set; }
    public long orgid { get; set; }
    public int level { get; set; }
    public string? userid { get; set; }

    //get and set methods for the users go here.

}