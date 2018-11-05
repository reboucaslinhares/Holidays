# Holidays

Library to provide a list of official holidays from an year.
Get holidays for **any year between 1901 and 2099**. Also you can add custom holidays and manage with those dates as you wish.

# Supported countries

Currently, the library has embedded support to the countries in table below, including moveable holidays.

|Country|Moveable holidays|
|-|-|
|Brazil|Christian holidays|
|Portugal|Christian holidays|

## Instalation

To install the Nuget package, run the following command in the [Package Manager Console](https://docs.nuget.org/docs/start-here/using-the-package-manager-console) on **Visual Studio**:

```
PM> Install-Package Holidays
```

Or download package directly from [Nuget.org](https://www.nuget.org/packages/Holidays/)

## Usage

Basically, you can create an instance of ```NationalHolidays``` class or use the static methods and after chain the year to the ```OfYear``` method, as you want:

```csharp
var year = System.DateTime.Today.Year;
var brazilianHolidaysOfYear = NationalHolidays.FromBrazil.OfYear(year);
// or
brazilianHolidaysOfYear = NationalHolidays.From("br").OfYear(year);

var protugueseHolidaysOfYear = NationalHolidays.FromPortugal.OfYear(year);
// or
protugueseHolidaysOfYear = NationalHolidays.From("pt").OfYear(year);
```

The result is a ```Dictionary<string, DateTime>``` that represents the holiday description and its repective date on those year.

**Warning** The library has embedded only the national holidays, but includes also those that move acording the Christian events, such as Carnival and Easter (using Gauss algorithm).

```csharp
var christianHolidays = new ChristianHolidays(DateTime.Today.Year);
var carnivalDateOnYear = christianHolidays.Carnival;
var easterDateOnYear = christianHolidays.Easter;
```

If you are interested only in the fixed holidays, you could get them as below:

```csharp
var brazilianFixedHolidays = NationalHolidays.FromBrazil.FixedHolidays;
```

Note that is not necessary inform the year. The return is a collection of ```Holiday``` objects, that contains the holiday description, the day, the month of the year and a holiday type (National, Observance, Optional, Local, Season, etc)

You can add your custom dates:

```csharp
var customHolidayDate = new System.DateTime(System.DateTime.Today.Year, 5, 15);
holidays.AddCustom("some holiday", customHolidayDate);
// or
var customHoliday = new Holiday{ Description = "some holiday", Day = 1, Month = 2, Type = HolidayType.Local };
holidays.Add(customHoliday);
// or
holidays.AddRange(
   new Holiday{ Description = "some holiday 1", Day = 1, Month = 2, Type = HolidayType.Local }, 
   new Holiday { Description = "some holiday 2", Day = 2, Month = 3, Type = HolidayType.Local });
```

