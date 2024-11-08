using Eventify.Modules.Events.Domain.Abstractions;
using FluentResults;
using Microsoft.AspNetCore.Http;

namespace Eventify.Modules.Events.Presentation.ApiResults;

public static class ApiResults
{
    //TODO: Improve mapping between result and Problems
    public static IResult Problem(Result result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException("The result is successful.");
        }

        return Results.Problem(
            title: result.Errors.First().Metadata[DomainError.MetadataKeyForCodeProperty].ToString(),
            detail: result.Errors.First().Message,
            type: "",
            statusCode: StatusCodes.Status500InternalServerError);
    }
}