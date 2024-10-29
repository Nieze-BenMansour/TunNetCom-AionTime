using IdentityService.Contracts.Constant;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace IdentityService.Application.Features.AttachUserToRole;

public class AttachUserToRoleCommandHandler(UserManager<IdentityUser> userManager) :
    IRequestHandler<AttachUserToRoleCommand, ApiResponse<UserToRoleResponse>>
{
    private readonly UserManager<IdentityUser> _userManager = userManager;

    public async Task<ApiResponse<UserToRoleResponse>> Handle(
        AttachUserToRoleCommand request,
        CancellationToken cancellationToken)
    {
        IdentityUser? user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return new ApiResponse<UserToRoleResponse>()
            {
                Error = new ProblemDetails()
                {
                    Status = 404,
                    Title = nameof(ErrorDetails.UserNotFound),
                    Detail = ErrorDetails.UserNotFound,
                },
            };
        }

        IdentityResult result = await _userManager.AddToRoleAsync(user, request.Role);
        if (!result.Succeeded)
        {
            return new ApiResponse<UserToRoleResponse>()
            {
                Succeeded = false,
                Error = new ProblemDetails()
                {
                    Status = 400,
                    Title = nameof(ErrorDetails.RoleAssignmentFailed),
                    Detail = string.Join(", ", result.Errors.Select(e => e.Description)),
                },
            };
        }

        return new ApiResponse<UserToRoleResponse>() { Succeeded = true, };
    }
}