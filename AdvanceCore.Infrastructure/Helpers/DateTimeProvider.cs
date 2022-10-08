using AdvanceCore.Application.Common.Interface.Helpers;

namespace AdvanceCore.Infrastructure.Helpers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}