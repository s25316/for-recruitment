namespace Domain.ValueObjects
{
    public record Age
    {
        public int Years { get; private set; }
        public int Months { get; private set; }
        public int Days { get; private set; }

        public Age(DateTime birthdate, int minAge)
        {
            var today = DateTime.Today;
            if (birthdate > today)
            {
                throw new Exception("BirthDate Cannot be in future");
            }
            var dateOnlyToday = DateOnly.FromDateTime(today);
            var dateOnlyBirthDate = DateOnly.FromDateTime(birthdate);
            var age = new DateOnly().AddDays(dateOnlyToday.DayNumber - dateOnlyBirthDate.DayNumber)
                .AddDays(-1);

            Years = age.Year - 1;
            Months = age.Month - 1;
            Days = age.Day - 1;

            if (Years < minAge)
            {
                throw new Exception($"Less then Min Age {minAge}, actual age of this {age}");
            }
        }
    }
}
