namespace Dependencies;

public interface IDateTimeProvider
{
    public DateTime CurrentUtc();
    public bool IsMorning();
    public bool IsAfternoon();
    public bool IsEvening();
    public bool IsLateNightEarlyMorning();
}