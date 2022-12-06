using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;
using System.Threading;
namespace TaskManager
{
    static class TaskInfo
    {
        static int SelectedIndex = 0;

        private static List<Task> GetTasks(Process[] processes)
        {
            Console.Title = "TASK MANAGER OHIO EDITION 2 FREE REPACK BY xatab 2023";
            List<Task> result = new List<Task>();

            for (int i = 0; i < processes.Length; i++)
            {
                result.Add(new Task(processes[i].ProcessName, processes[i].Id , processes[i].PagedMemorySize64));
            }

            return result;
        }

        static public void DisplayTasks()
        {
            Console.CursorVisible = false;
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("TASK MANAGER OHIO EDITION 2 FREE REPACK BY xatab 2023");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Name                                                                  ID        Memory                                   ");
            Console.ResetColor();

            Process[] processes = Process.GetProcesses();
            List<Task> tasks = GetTasks(processes);

            string[] options = new string[tasks.Count];
            for (int i = 0; i < options.Length; i++)
            {
  
                options[i] = tasks[i].Name;

                Console.SetCursorPosition(0, 2 + i);
                Console.WriteLine(tasks[i].Name);
                Console.SetCursorPosition(70, 2 + i);
                Console.WriteLine(tasks[i].Id);
                Console.SetCursorPosition(80, 2 + i);
                Console.WriteLine(tasks[i].Memory);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(90, 2 + i);
                Console.Write(" Bytes");
                Console.ResetColor();
            }

            Console.SetCursorPosition(0, 0);
            while (true)
            {
                Console.SetCursorPosition(0, SelectedIndex + 15);
                Options.DisplayOption(SelectedIndex, options, 2);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (SelectedIndex + 1 < tasks.Count)
                        {
                            SelectedIndex++;
                            if (SelectedIndex == tasks.Count)
                            {
                                SelectedIndex = 0;
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (SelectedIndex > 0)
                        {
                            SelectedIndex--;
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.SetCursorPosition(0, SelectedIndex + 3);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        try
                        {
                            Console.WriteLine("-------------------------------------                ");

                            Console.WriteLine($"  Physical memory usage     : {processes[SelectedIndex].WorkingSet64}");
                            Console.WriteLine($"  Base priority             : {processes[SelectedIndex].BasePriority}");
                            Console.WriteLine($"  Priority class            : {processes[SelectedIndex].PriorityClass}");
                            Console.WriteLine($"  User processor time       : {processes[SelectedIndex].UserProcessorTime}");
                            Console.WriteLine($"  Privileged processor time : {processes[SelectedIndex].PrivilegedProcessorTime}");
                            Console.WriteLine($"  Total processor time      : {processes[SelectedIndex].TotalProcessorTime}");
                            Console.WriteLine($"  Paged system memory size  : {processes[SelectedIndex].PagedSystemMemorySize64} Bytes");
                            Console.WriteLine($"  Paged memory size         : {processes[SelectedIndex].PagedMemorySize64} Bytes");

                            if (processes[SelectedIndex].Responding)
                            {
                                Console.WriteLine("  Status = Running");
                            }
                            else
                            {
                                Console.WriteLine("  Status = Not Responding");
                            }

                            Console.WriteLine("-------------------------------------                ");
                        }
                        catch (Exception)
                        {
                                                        Console.WriteLine("-------------------------------------                ");

                            Console.WriteLine($"  Physical memory usage     : {processes[SelectedIndex].WorkingSet64}");
                            Console.WriteLine($"  Base priority             : Access Denied");
                            Console.WriteLine($"  Priority class            : Access Denied");
                            Console.WriteLine($"  User processor time       : Access Denied");
                            Console.WriteLine($"  Privileged processor time : Access Denied");
                            Console.WriteLine($"  Total processor time      : Access Denied");
                            Console.WriteLine($"  Paged system memory size  : {processes[SelectedIndex].PagedSystemMemorySize64} Bytes");
                            Console.WriteLine($"  Paged memory size         : {processes[SelectedIndex].PagedMemorySize64} Bytes");

                            if (processes[SelectedIndex].Responding)
                            {
                                Console.WriteLine("  Status = Running");
                            }
                            else
                            {
                                Console.WriteLine("  Status = Not Responding");
                            }

                            Console.WriteLine("-------------------------------------                ");
                        }
                        finally
                        {
                            Console.ReadKey(true);
                            Console.Clear();
                            DisplayTasks();
                        }
                        break;
                    case ConsoleKey.Delete:
                        try
                        {
                            processes[SelectedIndex].Kill(false);

                            Console.SetCursorPosition(0, SelectedIndex + 2);
                            Console.WriteLine(options[SelectedIndex] + " Stoping....");
                            Thread.Sleep(200);

                            Console.Clear();
                            DisplayTasks();
                        }
                        catch(Exception)
                        {
                            int errorindex = new Random().Next(1, 6);
                            Errors error = (Errors)errorindex;
                            SoundPlayer soundPlayer = new SoundPlayer("Assets/"+ error + ".wav");
                            soundPlayer.Play();

                            Console.SetCursorPosition(0, SelectedIndex + 2);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine(options[SelectedIndex]);
                            Thread.Sleep(150);
                        }
                        break;
                    case ConsoleKey.D:
                        try
                        {
                            processes[SelectedIndex].Kill(true);

                            Console.SetCursorPosition(0, SelectedIndex + 2);
                            Console.WriteLine(options[SelectedIndex] + " Stoping....");
                            Thread.Sleep(200);

                            Console.Clear();
                            DisplayTasks();
                        }
                        catch (Exception)
                        {
                            int errorindex = new Random().Next(1, 6);
                            Errors error = (Errors)errorindex;
                            SoundPlayer soundPlayer = new SoundPlayer("Assets/" + error + ".wav");
                            soundPlayer.Play();

                            Console.SetCursorPosition(0, SelectedIndex + 2);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine(options[SelectedIndex]);
                            Thread.Sleep(150);
                        }
                        break;
                }
            }
        }
    }
    internal enum Errors
    {
        error1 = 1,
        error2 = 2,
        error3 = 3,
        error4 = 4,
        error5 = 5,
        error6 = 6
    }
}
