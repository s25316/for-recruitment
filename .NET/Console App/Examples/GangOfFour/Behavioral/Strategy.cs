namespace GangOfFour.Behavioral
{
    public interface IStrategy<in TInput, out TOutput>
    {
        TOutput Execute(TInput input);
    }

    public record Pet(string name, DateOnly BirthDate, DateOnly? DiedDate);
    public abstract class PetAgeStrategy : IStrategy<Pet, decimal>
    {
        public abstract decimal Execute(Pet input);


        public sealed class FullYears : PetAgeStrategy
        {
            public override decimal Execute(Pet input)
            {
                var dateTimeStart = input.BirthDate.ToDateTime(TimeOnly.MinValue);
                var dateTimeEnd = input.DiedDate?.ToDateTime(TimeOnly.MinValue)
                    ?? DateTime.Now;

                var duration = dateTimeEnd - dateTimeStart;
                double totalYears = duration.TotalDays / 365.25;
                return (decimal)Math.Floor(totalYears);
            }
        }

        public sealed class TotalYears : PetAgeStrategy
        {
            public override decimal Execute(Pet input)
            {
                var dateTimeStart = input.BirthDate.ToDateTime(TimeOnly.MinValue);
                var dateTimeEnd = input.DiedDate?.ToDateTime(TimeOnly.MinValue)
                    ?? DateTime.Now;

                var duration = dateTimeEnd - dateTimeStart;
                double totalYears = duration.TotalDays / 365.25;
                return (decimal)totalYears;
            }
        }
    }
}
