﻿using TunNetCom.AionTime.TimeLogService.Domain.Interfaces.Repositories;
using TunNetCom.AionTime.TimeLogService.Domain.Models.Dbo;

namespace TunNetCom.AionTime.TimeLogService.Application.Feature.OrganizationAction.Commands.AddOrganization;

public class AddOrganizationCommandHandler(IRepository<Organization> organizationRepository, IMapper mapper)
    : IRequestHandler<AddOrganizationCommand, int>
{
    private readonly IRepository<Organization> _organizationRepository = organizationRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<int> Handle(AddOrganizationCommand request, CancellationToken cancellationToken)
    {
        Organization organization = _mapper.Map<Organization>(request.Organization);
        await _organizationRepository.AddAsync(organization);
        return organization.Id;
    }
}