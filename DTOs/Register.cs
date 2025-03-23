public class Register {
    public string? name { get; set; }
    public string? email { get; set; }
    public string? password { get; set;}

    public string? role {get; set;} //the admins will get their roles from the organization admin.
    public int level {get; set;} //organization id sent back
    public long orgid {get; set;} //each org has a unique id.

}