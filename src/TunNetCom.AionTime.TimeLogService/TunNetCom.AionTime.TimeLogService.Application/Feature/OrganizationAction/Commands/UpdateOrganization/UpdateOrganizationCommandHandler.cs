﻿namespace TunNetCom.AionTime.TimeLogService.Application;

public class UpdateOrganizationCommandHandler(IRepository<Organization> organizationRepository, IMapper mapper)
    : IRequestHandler<UpdateOrganizationCommand, int>
{
    private readonly IRepository<Organization> _organizationRepository = organizationRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<int> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
    {
        var organization = _mapper.Map<Organization>(request.Organization);
        await _organizationRepository.UpdateAsync(organization);
        return organization.Id;
    }
}
