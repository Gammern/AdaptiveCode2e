using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInversion
{
    using Sensors;

    class Program
    {
        private delegate void CommandHandler(IEnumerable<string> parameters);
        private static Sensor CurrentSensor;

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
                    {"zoom", Zoom},
                    {"capture-image", CaptureImage },
                    {"measure-height", MeasureHeight},
                    {"pitch", Pictch},
                    {"roll", Roll},
                    {"raise", Raise},
                    {"lower", Lower},
                    {"get-pressure", GetPressure},
                    { "quit", _ => Environment.Exit(0) }
                };
                handlers.Add("?", _ => PrintCommands(handlers.Keys));

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
            var sensorFactory = new Dictionary<string, Func<Sensor>>()
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
            if (CurrentSensor != null)
            {
                if (parameters.Count() != 2)
                {
                    Console.WriteLine("Command move requires two parameters");
                }
                else
                {
                    try
                    {
                        float x, y;
                        x = float.Parse(parameters.First());
                        y = float.Parse(parameters.Skip(1).First());
                        CurrentSensor.Move(x, y);
                        Console.WriteLine($"Sensor {CurrentSensor} moved to x={x} y={y}");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Wrong floating-point format. Try move {1.5} {3.5}");
                    }

                }
            }
            else
            {
                Console.WriteLine("Please select a sensor to use the move function");
            }
        }

        private static void Zoom(IEnumerable<string> parameters)
        {
            var camera = CurrentSensor as Camera;
            if (camera != null)
            {
                if (parameters.Count() != 1)
                {
                    Console.WriteLine("command zoom requires one parameter");
                }
                else
                {
                    if (float.TryParse(parameters.FirstOrDefault(), out float level))
                    {
                        camera.Zoom(level);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid floating-point parameter. Try {1.5F}");
                    }
                }
            }
            else
            {
                Console.WriteLine("You must select camera to use zoom function");
            }
        }

        private static void CaptureImage(IEnumerable<string> parameters)
        {
            var camera = CurrentSensor as Camera;
            if (camera != null)
            {
                if (parameters.Any())
                {
                    Console.WriteLine("command capture-image shouldn't have parameters");
                }
                else
                {
                    camera.Capture();
                    Console.WriteLine($"Image captured from {camera}");
                }
            }
            else
            {
                Console.WriteLine("You must select camera to capture an image");
            }

        }

        private static void MeasureHeight(IEnumerable<string> parameters)
        {
            var lazer = CurrentSensor as Lazer;
            if (lazer != null)
            {
                if (parameters.Any())
                {
                    Console.WriteLine("command measure-height shouldn't have parameters");
                }
                else
                {
                    var value = lazer.Measure();
                    Console.WriteLine($"Laser measure returned: {value}");
                }
            }
            else
            {
                Console.WriteLine("You must select lazer to measure height");
            }
        }

        private static void Pictch(IEnumerable<string> parameters)
        {
            var touchProble = CurrentSensor as TouchProbe;
            if (touchProble != null)
            {
                if (parameters.Count() != 1)
                {
                    Console.WriteLine("command pitch requires one parameter");
                }
                else
                {
                    if (float.TryParse(parameters.First(), out float pitch))
                    {
                        touchProble.Pitch(pitch);
                        Console.WriteLine($"touchprobe pitched by {pitch}");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid float parameter {parameters.First()}. Try {1.9}");
                    }
                }
            }
            else
            {
                Console.WriteLine("You must select touchprobe to use pitch");
            }
        }

        private static void Roll(IEnumerable<string> parameters)
        {
            var touchProble = CurrentSensor as TouchProbe;
            if (touchProble != null)
            {
                if (parameters.Count() != 1)
                {
                    Console.WriteLine("command roll requires one parameter");
                }
                else
                {
                    if (float.TryParse(parameters.First(), out float roll))
                    {
                        touchProble.Roll(roll);
                        Console.WriteLine($"touchprobe rolled by {roll}");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid float parameter {parameters.First()}. Try {1.9}");
                    }
                }
            }
            else
            {
                Console.WriteLine("You must select touchprobe to use roll");
            }
        }

        private static void Raise(IEnumerable<string> parameters)
        {
            var touchProble = CurrentSensor as TouchProbe;
            if (touchProble != null)
            {
                if (parameters.Count() != 1)
                {
                    Console.WriteLine("command raise requires one parameter");
                }
                else
                {
                    if (float.TryParse(parameters.First(), out float height))
                    {
                        touchProble.Raise(height);
                        Console.WriteLine($"touchprobe raised by {height}");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid float parameter {parameters.First()}. Try {1.9}");
                    }
                }
            }
            else
            {
                Console.WriteLine("You must select touchprobe to use raise");
            }
        }

        private static void Lower(IEnumerable<string> parameters)
        {
            var touchProble = CurrentSensor as TouchProbe;
            if (touchProble != null)
            {
                if (parameters.Count() != 1)
                {
                    Console.WriteLine("command lower requires one parameter");
                }
                else
                {
                    if (float.TryParse(parameters.First(), out float height))
                    {
                        touchProble.Lower(height);
                        Console.WriteLine($"touchprobe lowered by {height}");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid float parameter {parameters.First()}. Try {1.9}");
                    }
                }
            }
            else
            {
                Console.WriteLine("You must select touchprobe to use lower");
            }
        }

        private static void GetPressure(IEnumerable<string> parameters)
        {
            var touchProble = CurrentSensor as TouchProbe;
            if (touchProble != null)
            {
                if (parameters.Any())
                {
                    Console.WriteLine("command get-pressure don't have parameters");
                }
                else
                {
                    var pressure = touchProble.GetPressure();
                    Console.WriteLine($"touchprobe pressure is: {pressure.Value}psi");
                }
            }
            else
            {
                Console.WriteLine("You must select touchprobe to measure pressure");
            }
        }

        private static void PrintCommands(IEnumerable<string> parameters)
        {
            Console.WriteLine("Available Commands:");
            Console.WriteLine(string.Join(",", parameters));
        }
    }
}
