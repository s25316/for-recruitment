using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS03.Models
{
    internal abstract class Cream
    {
        public string Name { get; private set; } = null!;
        public BodyPart BodyPart { get; private set; } = null!;

        public Cream (string name, BodyPart bodyPart)
        {
            Name = name;
            BodyPart = bodyPart;
        }

        public abstract float GetProportion(float BodyWeight); 
    }

    class MedicalCream : Cream
    {
        public List <string> MedicalSubstantions { get; private set; }
        public float Proportion { get; private set; }
        public MedicalCream(string name, BodyPart bodyPart, List<string> medicalSubstantions, float proportion) : base(name, bodyPart)
        {
            MedicalSubstantions = medicalSubstantions;
            Proportion = proportion;
        }

        public override float GetProportion(float BodyWeight)
        {
            return BodyWeight * Proportion / MedicalSubstantions.Count();
        }
    }

    class TonalCream : Cream
    {
        public float Proportion { get; private set; }
        public int Scale { get; private set; }
        public TonalCream(string name, BodyPart bodyPart,float proportion, int scale) : base(name, bodyPart)
        {
            Proportion = proportion;
            Scale = scale;
        }

        public override float GetProportion(float BodyWeight)
        {
            return (BodyWeight * Proportion / Scale);
        }
    }
    class BodyPart 
    {
        
    }

    class Head : BodyPart
    {
        public string Where { get; private set; } = null!;
        public string Goal { get; private set; } = null!;

        public Head (string where, string goal)
        {
            Where = where;
            Goal = goal;
        }

        public string GetWere () => Where;
        public string GetGoal() => Goal;
    }

    class Body : BodyPart
    {
        public string Description { get; private set; } = null!;

        public Body (string description)
        {
            Description = description;
        }

        public string GetDescription () => Description;
    }

    class Legs : BodyPart 
    {
        public string Description { get; private set; } = null!;
        public Legs(string description)
        {
            Description = description;
        }

        public string GetDescription() => Description;
    }
} 

