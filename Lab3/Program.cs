using System;
using Task2;

namespace Task2
{
    class Country
    {
        protected string name;
        protected string ruller;
        protected string description;
        public Country(string name, string ruller, string description)
        {
            this.name = name;
            this.ruller = ruller;
            this.description = description;
        }
        public virtual void Show()
        {
            Console.WriteLine("Name = " + name + "\nRuller = " + ruller + "\nDescription = " + description);
        }
    }
    class Republic : Country
    {
        private bool democratic_core = true;
        private bool power_inheritance = false;
        public Republic(string name, string ruller, string description, bool power_inheritance) : base(name, ruller, description)
        {
            this.power_inheritance = power_inheritance;
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("This country is a Republic!");
            if (democratic_core == true && power_inheritance == false)
            {
                Console.Write(" Because it is based on democratic core and has no power inheritance");
            }
            else
            {
                Console.Write(" The Republic with inheritance of Power? Nice try! :^)");
            }
        }
    }
    class Kingdom : Country
    {
        private bool power_inheritance = true;
        public Kingdom(string name, string ruller, string description, bool power_inheritance) : base(name, ruller, description)
        {
            this.power_inheritance = power_inheritance;
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("This country is a Kingdom!");
            if (power_inheritance != true)
            {
                Console.Write("...Without a King or a Queen? Strange indeed!");
            }
        }
    }
    class Monarchy : Kingdom
    {
        private int type;
        public Monarchy(string name, string ruller, string description, int type) : base(name, ruller, description, true)
        {
            this.type = type;
        }

        public override void Show()
        {
            Console.WriteLine("Name = " + name + "\nRuller = " + ruller + "\nDescription = " + description);
            Console.WriteLine("Your country automatically become a Kingdom, because You are a Monarch!");
            if (type == 1)
            {
                Console.WriteLine("And Monarchy is constitutional :^c");
            }
            else
            {
                Console.WriteLine("And Monarchy is absolute! >:^)");
            }
        }
    }
}

namespace Lab3
{
    class Rectangle
    {
        private int side_a;
        private int side_b;
        private int color;

        public Rectangle(int side_a, int side_b, int color)
        {
            this.side_a = side_a;
            this.side_b = side_b;
            this.color = color;
            Console.WriteLine("A rectangle has been created");
        }

        public void GetSideLength()
        {
            Console.WriteLine("Side a = " + side_a + "\nSide b = " + side_b);
        }
        public void SetSideLength(int side_a, int side_b)
        {
            this.side_a = side_a;
            this.side_b = side_b;
            Console.WriteLine("Applying changes...");
        }
        public string GetColor()
        {
            switch (color)
            {
                case 1: return "White";
                case 2: return "Red";
                case 3: return "Black";
                case 4: return "Grey";
                case 5: return "Yellow";
                case 6: return "Blue";
                default: return "Undefined";
            }
        }
        public int CalculatingSquare()
        {
            return side_b * side_a;
        }
        public int CalculatingPerimeter()
        {
            return 2 * side_a + 2 * side_b;
        }
        public bool IsSquare()
        {
            if (side_a == side_b)
            { return true; }
            else
            { return false; }
        }
        public void GetAllInfo()
        {
            Console.WriteLine("All the information about the rectangle:\nSide a = " + side_a + "\nSide b = " + side_b + "\nColor = " + GetColor() + "\nIs a Square = " + IsSquare() +
                "\nPerimeter = " + CalculatingPerimeter() + "\nSquare = " + CalculatingSquare());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\tLab 2\nThere are tasks with numbers 1.3, 2.13\nChoose the one you want to start:");
                String task_number = Console.ReadLine();
                switch (task_number)
                {
                    case "1.3":
                        Console.WriteLine("Creating a Rectangle. Input its color, side a and b (all int):");
                        int color = int.Parse(Console.ReadLine()), a = int.Parse(Console.ReadLine()), b = int.Parse(Console.ReadLine());
                        Rectangle r = new Rectangle(a, b, color); r.GetAllInfo();
                        string input;
                        do
                        {
                            Console.WriteLine("Do you want to change sides of your rectangle to see a different result? (Y/N)");
                            input = Console.ReadLine();
                            if (input == "Y" || input == "Yes" || input == "y" || input == "yes")
                            {
                                Console.WriteLine("Input side a and b (all int):");
                                a = int.Parse(Console.ReadLine()); b = int.Parse(Console.ReadLine());
                                r.SetSideLength(a, b);
                                r.GetSideLength(); r.GetAllInfo();
                            }
                        } while (input == "Y" || input == "Yes" || input == "y" || input == "yes");
                        break;
                    case "2.13":
                        Console.WriteLine("Input the name of your country, its ruller and the descriprion!");
                        string name = Console.ReadLine(), ruller = Console.ReadLine(), description = Console.ReadLine();
                        Console.WriteLine("What country you want to create? a Republic = Key '1', a Kingdom = Key '2', a Monarchy = Key '3'\nKey'4' = Stop asking me! Just a country!");
                        input = Console.ReadLine();
                        if (input == "1")
                        {
                            Console.WriteLine("A Republic cannot have an inheritance of Power, yes ._.?   (Y/N) ");
                            string choice = Console.ReadLine();
                            if (choice == "Y" || choice == "Yes" || choice == "y" || choice == "yes")
                            {
                                Task2.Republic republic = new Republic(name, ruller, description, false); republic.Show();
                            }
                            else { Task2.Republic republic = new Republic(name, ruller, description, true); republic.Show(); }
                        }
                        else if (input == "2")
                        {
                            Console.WriteLine("Your Kingdom have an inheritance of Power, yes? (Y/N) ");
                            string choice = Console.ReadLine();
                            if (choice == "Y" || choice == "Yes" || choice == "y" || choice == "yes")
                            {
                                Task2.Kingdom kingdom = new Kingdom(name, ruller, description, true); kingdom.Show();
                            }
                            else { Task2.Kingdom kingdom = new Kingdom(name, ruller, description, false); kingdom.Show(); }

                        }
                        else if (input == "3")
                        {
                            Console.WriteLine("Input the type of your monarchy. Constitutional = Key '1', for Absolute Monarchy... it's your choice, You're the ruller!");
                            string choice = Console.ReadLine();
                            if (choice == "1")
                            {
                                Task2.Monarchy monarchy = new Monarchy(name, ruller, description, 1); monarchy.Show();
                            }
                            else { Task2.Monarchy monarchy = new Monarchy(name, ruller, description, 0); monarchy.Show(); }

                        }
                        else if (input == "4")
                        {
                            Task2.Country country = new Country(name, ruller, description); country.Show();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect input");
                        }
                        break;
                    default: Console.WriteLine("You've chosen a wrong number. There is no such a task"); Console.ReadLine(); break;

                }
                Console.ReadLine();
            }
        }
    }
}
