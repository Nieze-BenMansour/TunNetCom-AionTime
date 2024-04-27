﻿namespace TunNetCom.AionTime.TimeLogService.Application;

public class DeleteOrganizationCommandHandler(IRepository<Organization> organizationRepository) : IRequestHandler<DeleteOrganizationCommand, int>
{
    private readonly IRepository<Organization> organizationRepository = organizationRepository;

    public async Task<int> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
    {
        await this.organizationRepository.DeleteAsync(request.id);
        return request.id;
    }
}