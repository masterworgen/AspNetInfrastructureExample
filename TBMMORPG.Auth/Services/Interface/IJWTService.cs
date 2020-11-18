namespace TBMMORPG.Auth.Services.Interface
{
    public interface IJWTService
    {
        string GenerateJSONWebToken(string userName);
    }
}