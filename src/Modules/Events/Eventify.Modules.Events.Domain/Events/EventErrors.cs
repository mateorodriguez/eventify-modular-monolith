using Eventify.Modules.Events.Domain.Abstractions;
using FluentResults;

namespace Eventify.Modules.Events.Domain.Events;

//todo: Here there are two approaches to model application errors
//Im leaving both and use them to have more info and 
//decide later which one is better

public sealed class StartDateIsAfterEndDateError(DateTime startDate, DateTime endDate) 
    : DomainError(
        "Events.StartDateIsAfterEndDateError", 
        $"The start date {startDate} is after the end date {endDate}");

public static class EventErrors
{
    public static readonly IError StartDateIsAfterEndDateError = new DomainError(
        "Events.StartDateIsAfterEndDateError", 
        "The start date is after the end date");
    
    public static readonly IError StartDateIsInThePast = new DomainError(
        "Events.StartDateIsInThePast",
        "The start date is in the past");
}