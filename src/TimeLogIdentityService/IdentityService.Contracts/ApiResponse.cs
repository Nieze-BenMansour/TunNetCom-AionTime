namespace IdentityService.Contracts;

public class ApiResponse<T>(T? data = default) : ApiResponse(data)
{
    public new T? Data { get; set; } = data;
}