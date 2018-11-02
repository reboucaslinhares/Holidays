namespace Holidays {
    public interface IMoveableHolidays {
        IMoveableHolidays CalculateForYear(int year);
        IMoveableHolidays UseLocalizationFor(string country);
        Holidays Holidays { get; }
    }
}