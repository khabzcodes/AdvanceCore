namespace AdvanceCore.Application.Common.Interface.Helpers;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}