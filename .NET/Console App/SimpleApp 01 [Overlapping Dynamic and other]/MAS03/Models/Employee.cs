using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS03.Models
{
    internal abstract class Employee
    {
        public string? Name { get; private set; }
        public string? Surname { get; private set; }

        public Employee(string? name, string? surname) 
        {
            Name = name;
            Surname = surname;
        }
        public abstract float GetSalary();
    }
    interface ICallCenterEmployee 
    {
        public float GetWorkingHours();
        float GetSalary();
        public float GetHourlyRate();
    }
    class CallCenterEmployee : Employee, ICallCenterEmployee
    {
        public float WorkingHours { get; set; }
        public float HourlyRate { get; set; }
        public CallCenterEmployee(string? name, string? surname, float workingHours, float hourlyRate) : base(name, surname)
        {
            this.WorkingHours = workingHours;
            this.HourlyRate = hourlyRate;
        }
        public float GetHourlyRate() => HourlyRate; 
        public float GetWorkingHours () => WorkingHours;
        public override float GetSalary()
        {
            return  WorkingHours * HourlyRate;
        }
    }

    class Seller : Employee
    {
        public float WorkingHours { get; set; }
        public float PercentRate { get; set; }
        public float SumSellProduct { get; set; }

        public Seller(string? name, string? surname, float workingHours, float percentRate, float sumSellProduct) : base(name, surname)
        {
            this.WorkingHours = workingHours;
            this.PercentRate = percentRate;
            this.SumSellProduct = sumSellProduct;
        }
        public float GetWorkingHours() => WorkingHours;
        public override float GetSalary()
        {
            return PercentRate * SumSellProduct /100;
        }
    }
    class CallCenterSellerEmployee : Seller, ICallCenterEmployee 
    {
        private CallCenterEmployee _ccEmployee;

        public CallCenterSellerEmployee(string name, string surname, 
            float workingHoursAsSeller, float percentRateAsSeller, float sumSellProductAsSeller,
            float workingHoursAsccEmployee, float hourlyRateAsccEmployee) 
            : base(name, surname, workingHoursAsSeller, percentRateAsSeller, sumSellProductAsSeller)
        {
            _ccEmployee = new CallCenterEmployee(null, null, workingHoursAsccEmployee, hourlyRateAsccEmployee);
        }

        public float GetHourlyRate()
        {
            return _ccEmployee.HourlyRate;
        }

        public float GetSalaryAsSeller() => base.GetSalary();
        public float GetSalaryAsCC() => _ccEmployee.GetSalary();
        public override float GetSalary()
        {
            return base.GetSalary() + _ccEmployee.GetSalary();
        }
    }

}
