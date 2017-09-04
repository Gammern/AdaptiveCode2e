using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInversion
{
    using Sensors;

    class Program
    {
        private delegate void CommandHandler(IEnumerable<string> parameters);
        private static ISensor CurrentSensor;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("command > ");
                var input = Console.ReadLine() ?? string.Empty;
                var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (!tokens.Any())
                {
                    Console.WriteLine("Please supply a command or use ? for help");
                    continue;
                }

                var command = tokens.First();
                var parameters = tokens.Skip(1);

                var handlers = new Dictionary<string, CommandHandler>
                {
                    {"select", SelectTool },
                    {"move", Move },
                    {"measure", Measure},
                    {"rotate", Rotate},
                    {"adjust-height", AdjustHeight},
                    {"quit", _ => Environment.Exit(0) }
                };
                handlers.Add("?", _ => PrintCommands(handlers.Keys));
                handlers.Add("ah", AdjustHeight);

                if (!handlers.Keys.Contains(command))
                {
                    Console.WriteLine($"Unrecognized command: {command}");
                }
                else
                {
                    handlers[command].Invoke(parameters);
                }
            }
        }

        private static void SelectTool(IEnumerable<string> parameters)
        {
            var sensorFactory = new Dictionary<string, Func<ISensor>>()
            {
                { "camera", () => new Camera() },
                { "lazer", () => new Lazer() },
                { "touchprobe", () => new TouchProbe() }
            };

            if (parameters.Count() == 1)
            {
                var sensor = parameters.First();
                try
                {
                    CurrentSensor = sensorFactory[sensor].Invoke();
                    Console.WriteLine($"{sensor} selected as current sensor");
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine($"{sensor} is not a valid sensor. Use one of {string.Join(',', sensorFactory.Keys)}");
                }
            }
            else
            {
                Console.WriteLine($"You must supply a single parameter to select function ({string.Join(',', sensorFactory.Keys)})");
            }
        }

        private static void Move(IEnumerable<string> parameters)
        {
            var movableSensor = CurrentSensor as IMovable;
            if (movableSensor != null)
            {
                if (parameters.Count() == 2)
                {
                    try
                    {
                        float x, y;
                        x = float.Parse(parameters.First());
                        y = float.Parse(parameters.Skip(1).First());
                        movableSensor.Move(x, y);
                        Console.WriteLine($"Sensor {CurrentSensor.GetName()} moved to x={x} y={y}");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Wrong floating-point format according to current culture. Try move {9.99F} {9.99F}");
                    }
                }
                else
                {
                    Console.WriteLine($"Command move requires two parameters.\n\tSyntax: move {9.99F} {9.99F}");
                }
            }
            else
            {
                Console.WriteLine("Please select a IMovable sensor to use the move function");
            }
        }

        private static void Measure(IEnumerable<string> parameters)
        {
            var measurableSensor = CurrentSensor as IMeasurable;
            if (measurableSensor != null)
            {
                if (parameters.Any())
                {
                    Console.WriteLine("Command measure don't have parameters");
                }
                else
                {
                    var measure = measurableSensor.Measure();
                    Console.WriteLine($"{CurrentSensor.GetName()} measure is: {measure}");
                }
            }
            else
            {
                Console.WriteLine("You must select a IMeasurable to measure");
            }
        }

        private static void Rotate(IEnumerable<string> parameters)
        {
            var rotatableSensor = CurrentSensor as IRotatable;
            if (rotatableSensor != null)
            {
                if (parameters.Count() == 2)
                {
                    var rotationDirection = parameters.First();
                    var rotationValue = parameters.Skip(1).First();
                    try
                    {
                        switch (rotationDirection)
                        {
                            case "pitch":
                                rotatableSensor.Pitch(float.Parse(rotationValue));
                                Console.WriteLine($"{CurrentSensor.GetName()} pitched.");
                                break;
                            case "roll":
                                rotatableSensor.Roll(float.Parse(rotationValue));
                                Console.WriteLine($"{CurrentSensor.GetName()} rolled.");
                                break;
                            default:
                                Console.WriteLine($"First parameter to rotate must be 'pitch' or 'roll'.\n\tSyntax: rotate [pitch|roll] {9.99F}");
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Second parameter {rotationValue} is not a valid float according to current culture. Try {9.99F}");
                    }
                }
                else
                {
                    Console.WriteLine($"Command rotate requires two parameter.\n\tSyntax: rotate [pitch|roll] {9.99F}");
                }
            }
            else
            {
                Console.WriteLine("You must select a IRotatable to use rotate");
            }
        }

        private static void AdjustHeight(IEnumerable<string> parameters)
        {
            var heightAdjustableSensor = CurrentSensor as IHeightAdjustable;
            if (heightAdjustableSensor == null)
            {
                Console.WriteLine($"Current sensor {CurrentSensor?.GetName() ?? "null"} is not height adjustable");
                return;
            }

            if (parameters.Count() == 2)
            {
                var direction = parameters.First();
                var height = parameters.Skip(1).First();
                try
                {
                    switch (direction)
                    {
                        case "raise":
                            heightAdjustableSensor.Raise(float.Parse(height));
                            Console.WriteLine($"{CurrentSensor.GetName()} raised.");
                            break;
                        case "lower":
                            heightAdjustableSensor.Lower(float.Parse(height));
                            Console.WriteLine($"{CurrentSensor.GetName()} lowered.");
                            break;
                        default:
                            Console.WriteLine("First parameter to height adjustment must be 'raise' or 'lower'");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Second parameter {height} is not a valid float according to current culture. Try {9.99F}");
                }
            }
            else
            {
                Console.WriteLine($"Parameter mismatch.\n\tSyntax: adjustheight [raise|lower] {9.99F}");
            }
        }

        private static void PrintCommands(IEnumerable<string> parameters)
        {
            Console.WriteLine("Available Commands:");
            Console.WriteLine(string.Join(",", parameters));
        }
    }
}
