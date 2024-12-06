using Microsoft.AspNetCore.Mvc;
using IRibeiroAPI.Infrastructure.Crosscutting.Exceptions;
using IRibeiroAPI.Infrastructure.Dto;
using IRibeiroAPI.Infrastructure.Crosscutting.Enums;

namespace IRibeiroAPI.Controllers;

public abstract class BaseController : ControllerBase
{
    protected async Task<APIResponse<T>> HandleOperationAsync<T>(
        Func<Task<T>> operation, 
        ILogger logger)
    {
        APIResponse<T> response = new();

        try
        {
            var data = await operation();
            response.setResponse(data, 200);
        }
        catch (EntityNotFoundException exc)
        {
            response.setResponse(exc.Message, 404);
        }
        catch (Exception exc)
        {
            logger.LogError(exc.Message);
            response.setResponse(ResponseError.Runtime, 500);
        }

        return response;
    }
}
