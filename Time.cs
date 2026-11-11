using System;

public class Time
{
    private readonly byte _hours;
    private readonly byte _minutes;

    public Time()
    {
        _hours = 0;
        _minutes = 0;
    }

    public Time(byte hours, byte minutes)
    {
        if (hours > 23)
            throw new ArgumentOutOfRangeException(nameof(hours), "Часы должны быть от 0 до 23");
        if (minutes > 59)
            throw new ArgumentOutOfRangeException(nameof(minutes), "Минуты должны быть от 0 до 59");

        _hours = hours;
        _minutes = minutes;
    }

    public Time(string timeString)
    {
        if (string.IsNullOrWhiteSpace(timeString))
            throw new ArgumentException("Строка времени не может быть пустой", nameof(timeString));
        var parts = timeString.Split(':');
        if (parts.Length != 2 || !byte.TryParse(parts[0], out _hours) || !byte.TryParse(parts[1], out _minutes))
            throw new FormatException("Неверный формат времени. Ожидается 'HH:mm'");
        if (_hours > 23)
            throw new ArgumentOutOfRangeException(nameof(_hours), "Часы должны быть от 0 до 23");
        if (_minutes > 59)
            throw new ArgumentOutOfRangeException(nameof(_minutes), "Минуты должны быть от 0 до 59");
    }

    public byte Hours
    {
        get
        {
            return _hours;
        }
    }

    public byte Minutes
    {
        get
        {
            return _minutes;
        }
    }

    public override string ToString()
    {
        return $"{_hours:D2}:{_minutes:D2}";
    }

    public Time Subtract(Time other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other), "Вычитаемое время не может быть null.");

        int currentTotalMinutes = _hours * 60 + _minutes;
        int otherTotalMinutes = other._hours * 60 + other._minutes;

        int diffMinutes = currentTotalMinutes - otherTotalMinutes;


        if (diffMinutes < 0)
        {
            diffMinutes += 24 * 60; 
        }

        byte resultHours = (byte)(diffMinutes / 60);
        byte resultMinutes = (byte)(diffMinutes % 60);

        return new Time(resultHours, resultMinutes);
    }

    public static Time operator -(Time t1, Time t2)
    {
        if (t1 == null)
            throw new ArgumentNullException(nameof(t1));
        return t1.Subtract(t2);
    }

}
