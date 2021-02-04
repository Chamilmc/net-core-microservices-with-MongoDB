using System;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Events;
using Actio.Common.Exceptions;
using Actio.Services.Activities.Services;
using Microsoft.Extensions.Logging;
using RawRabbit;

namespace Actio.Services.Activities.Handles
{
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {
        private ILogger _logger { get; }
     
        private readonly IBusClient _busClient;

        private readonly IActivityService _activityService;
        
        public CreateActivityHandler(IBusClient busClient,
            IActivityService activityService,
            ILogger<CreateActivityHandler> logger)
        {
            _logger = logger;
            _busClient = busClient;
            _activityService = activityService;
        }

        public async Task HandleAsync(CreateActivity command)
        {
            _logger.LogInformation($"Creating activity: '{command.Id}' for user: '{command.UserId}'.");
            try
            {
                await _activityService.AddAsync(command.Id, command.UserId,
                    command.Category, command.Name, command.Description, command.CreatedAt);

                await _busClient.PublishAsync(new ActivityCreated(command.Id, command.UserId,
                    command.Category, command.Name,command.Description,command.CreatedAt));
                _logger.LogInformation($"Activity: '{command.Id}' was created for user: '{command.UserId}'.");
                return;
            }
            catch (ActioException ex)
            {
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id,
                    ex.Code, ex.Message));
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id,
                    "error", ex.Message));
                _logger.LogError(ex.Message);
            }
        }
    }
}
