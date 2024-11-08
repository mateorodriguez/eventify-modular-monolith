using FluentResults;

namespace Eventify.Modules.Events.Domain.Abstractions;

public class DomainError : Error
{
    public const string MetadataKeyForCodeProperty = "Code";
    internal DomainError(string code, string message) : base(message)
    {
        Metadata.Add(MetadataKeyForCodeProperty, code);
    }
}