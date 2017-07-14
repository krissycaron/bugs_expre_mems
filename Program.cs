using System;
using System.Collections.Generic;


namespace expression_members
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class Bug
        {
            /*
                You can declare a typed public property, make it read-only,
                and initialize it with a default value all on the same
                line of code in C#. Readonly properties can be set in the
                class' constructors, but not by external code.
            */
            public string Name { get; } = "";
            public string Species { get; } = "";
            public ICollection<string> Predators { get; } = new List<string>();
            public ICollection<string> Prey { get; } = new List<string>();

            // Convert this readonly property to an expression member
            public string FormalName => $"{this.Name} the {this.Species}";
            // above replaces the below code into more concise verbiage.
            
            // {
            //     get
            //     {
            //         return $"{this.Name} the {this.Species}";
            //     }
            // }

            // Class constructor
            public Bug(string name, string species, List<string> predators, List<string> prey)
            {
                this.Name = name;
                this.Species = species;
                this.Predators = predators;
                this.Prey = prey;
            }

            // Convert this method to an expression member
            public string PreyList() => string.Join(",", this.Prey);

            //simpler methods
            // {
            //     string commaDelimitedPrey = string.Join(",", this.Prey);
            //     return commaDelimitedPrey;
            // }

            // Convert this method to an expression member
            public string PredatorList() => string.Join(",", this.Predators);
            // {
            //     string commaDelimitedPredators = string.Join(",", this.Predators);
            //     return commaDelimitedPredators;
            // }

            // Convert this to expression method (hint: use a C# ternary)
            public string Eat(string food) => (this.Prey.Contains(food)) ? $"{this.Name} ate the {food}." : $"{this.Name} is still hungry.";
            // {
            //     if (this.Prey.Contains(food))
            //     {
            //         return $"{this.Name} ate the {food}.";
            //     } else {
            //         return $"{this.Name} is still hungry.";
            //     }
            // }
        }
}
