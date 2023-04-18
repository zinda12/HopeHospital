using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Core.Model.ValueObjects;

[Owned]
public class Pin : ValueObject
{
    public string Value { get; private set; }

    public Pin(string value)
    {
        Value = value;
        Validate();
    }

    public int CalculateAge()
    {
        string year = CalculateYear();
        DateTime birthDate = DateTime.Parse(year + "-" + Value.Substring(2, 2) + "-" + Value.Substring(0, 2));
        return new DateTime(DateTime.Now.Subtract(birthDate).Ticks).Year - 1;
    }

    private void Validate()
    {
        int day = Int32.Parse(Value.Substring(0, 2));
        int month = Int32.Parse(Value.Substring(2, 2));
        int year = Int32.Parse(CalculateYear());

        if (day < 0 || month < 0 || month > 12 || year < 0 || year > DateTime.Now.Year)
        {
            throw new ArgumentException("Invalid PIN.");
        }

    }

    private string CalculateYear()
    {
        string yearString;
        if (Int32.Parse(Value.Substring(4, 3)) > Int32.Parse(DateTime.Now.Year.ToString().Substring(1, 3)))
        {
            yearString = "1" + Value.Substring(4, 3);
        }
        else
        {
            yearString = "2" + Value.Substring(4, 3);
        }
        return yearString;
    }

    public override bool Equals(object? obj)
    {
        var valueObject = obj as Pin;

        return Value == valueObject.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}