# Brazilian Holidays

Library to provide a list of Brazilian official holidays from an year.
Get holidays for **any year between 1901 and 2099**. Also you can add custom holidays and manage with those dates as you wish.

## Instalation

To install the Nuget package, run the following command in the [Package Manager Console](https://docs.nuget.org/docs/start-here/using-the-package-manager-console) on **Visual Studio**:

```
PM> Install-Package BrazilianHolidays
```

Or download package directly from [Nuget.org](https://www.nuget.org/packages/BrazilianHolidays/)

## Usage

Basically, you just create an instance of ```Hollidays``` class passing the year you want:

```csharp
var year = System.DateTime.Today.Year;
var holidaysOfYear = new BrazilianHolidays.Holidays(year);
```

The instance has a set of DateTime properties for some of the major holidays, including those that move, such as Carnival and Easter (using Gauss algorithm).

```csharp
var carnivalDateOnYear = holidays.Carnival;
var easterDateOnYear = holidays.Easter;
```

You can add your custom dates:

```csharp
var customHoliday = new System.DateTime(2017, 5, 15);
holidays.AddCustom(customHoliday);
```

You can get the the list of dates (computed + custom):

```csharp
var holidayList = holidays.List;
```
