using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using Cosmos.Core.IOGroup;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;
using Cosmos.HAL.BlockDevice.Registers;
using IL2CPU.API.Attribs;
using Cosmos.Core.Memory;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using Cosmos;
using System.IO;
using System.Transactions;
using System.Linq;
using System.ComponentModel.Design;


// CODE WRITED BY GUMAR ARUTUNYAN, 15.02.24, 19:05-??:??


namespace CLI
{
    class notepad_file
    {
        public void create_file(string name_of_file, string directory)
        {

        }
        public void delete_file(string name_of_file, string directory)
        {

        }
        public void edit_file(string name_of_file, string directory)
        {

        }
        public void save_file(string name_of_file, string directory)
        {

        }
    }
    class MouseHit
    {
        public void register_mouse_hit(Action sender)
        {

        }
    }

    public class Kernel : Sys.Kernel
    {

        string[] processes;
       
        bool terminalIsOpen = false;
        Canvas canvas;
        Pen btnpen = new Pen(Color.White);
        Pen pen4 = new Pen(Color.DarkGray);
        Pen pen5 = new Pen(Color.Red);
        Pen pen6 = new Pen(Color.Purple);
        Pen pen7 = new Pen(Color.Green);
        Pen pen8 = new Pen(Color.Blue);
        Pen pen9 = new Pen(Color.Orange);
        int value = 0;
        void changeplus()
        {
            value++;
        }
        
        public void notepad_window()
        {

        }


        public void createIcon(Bitmap image,  string text, Action sender, int x1, int y1)
        {
            int width = 70;
            int height = 70;
            int x = (int)Sys.MouseManager.X;
            int y = (int)Sys.MouseManager.Y;
            if (Sys.MouseManager.MouseState == Sys.MouseState.Left)
            {
                if (x >= x1 && x <= x1 + width)
                {
                    if (y >= y1 && y <= y1 + height)
                        sender();
                }

            }
            canvas.DrawImage(image, x1, y1);
            canvas.DrawString(text, Sys.Graphics.Fonts.PCScreenFont.Default, btnpen, x1 + 3, y1+75);

        }



        public void crbutton(Action sender, int width, int height, int x1, int y1, string text, int x, int y)
        {
            
            canvas.DrawRectangle(btnpen, x1, y1, width, height);
            canvas.DrawString(text, Sys.Graphics.Fonts.PCScreenFont.Default, btnpen, x1 + 3, y1);
            if (Sys.MouseManager.MouseState == Sys.MouseState.Left)
            {
                if (x >= x1 && x <= x1+width)
                {
                    if (y >= y1 && y <= y1+height)
                        sender();
                }

            }

        }
        public void settingsisOpened()
        {
            settingsIsClosed = false;
            settingsIsOpened = true;
        }
        public void settingsisclosed()
        {
            settingsIsClosed = true;
            settingsIsOpened = false;

        }

        int color = 1;
        public void selectColor1()
        {

            color = 1;
        }
        public void selectColor2()
        {

            color = 2;
        }
        public void selectColor3()
        {

            color = 3;
        }
        public void selectColor4()
        {

            color = 4;
        }
        bool movable_settings = false;
        void settings()
        {
            if (settingsIsOpened)
            {
                int x = (int)Sys.MouseManager.X;
                int y = (int)Sys.MouseManager.Y;

                int x_start = 70+90;
                int y_start = 70;

                

                canvas.DrawFilledRectangle(pen4, x_start, y_start, 660, 20);
                canvas.DrawString("Settings", Sys.Graphics.Fonts.PCScreenFont.Default, btnpen, x_start+5, y_start+2);
                crbutton(settingsisclosed, 20, 20, x_start+660-20, y_start, "X", x, y);
                canvas.DrawFilledRectangle(btnpen, x_start, y_start+20, 660, 500);
                //btn1
                crbutton(selectColor1, 100, 40, x_start+120-70, y_start+120-70, "", x, y);
                canvas.DrawFilledRectangle(pen6, x_start+120-70, y_start+120-70, 100, 40);
                canvas.DrawString(" - set default background color (Purple).", Sys.Graphics.Fonts.PCScreenFont.Default, pen6, x_start+225-70, y_start+140-70);
                //btn2
                crbutton(selectColor3, 100, 40, x_start+120-70, y_start+200-70, "", x, y);

                canvas.DrawFilledRectangle(pen7, x_start+120-70, y_start+200-70, 100, 40);
                canvas.DrawString(" - set green background color.", Sys.Graphics.Fonts.PCScreenFont.Default, pen7, x_start+225-70, y_start+220-70);
                //btn2
                crbutton(selectColor2, 100, 40, x_start+120-70, y_start+280-70, "", x, y);

                canvas.DrawFilledRectangle(pen8, x_start+120-70, y_start+280-70, 100, 40);
                canvas.DrawString(" - set blue background color.", Sys.Graphics.Fonts.PCScreenFont.Default, pen8, x_start+225-70, y_start+300-70);
                //btn3
                crbutton(selectColor4, 100, 40, x_start + 120-70, y_start+280+80-70, "", x, y);

                canvas.DrawFilledRectangle(pen9, x_start+120-70, y_start+280+80-70, 100, 40);
                canvas.DrawString(" - set orange background color.", Sys.Graphics.Fonts.PCScreenFont.Default, pen9, x_start+225-70, y_start+300+80-70);

                //движение окна
                if (x >= x_start && x <= x_start+660-20)
                {
                    if (y >= y_start && y <= y_start+20)
                    {
                        if (x_start+660 == 1920 || y_start+500-70 == 1080)
                        {
                            
                        }
                        else
                        {
                            movable_settings = true;
                        }
                    }
                }

                if (movable_settings)
                {
                    x_start = x; y_start = y;
                }
            }
        }
        
        bool settingsIsOpened = false;
        bool settingsIsClosed = true;
        public void terminalIsOpenon()
        {
            terminalIsOpen = true; 
        }

        protected override void BeforeRun()
        {
            canvas = FullScreenCanvas.GetFullScreenCanvas();

            canvas.Mode = new Mode(1920, 1080, ColorDepth.ColorDepth32);
            Sys.MouseManager.ScreenWidth = (uint)canvas.Mode.Columns;
            Sys.MouseManager.ScreenHeight = (uint)canvas.Mode.Rows;
            Sys.MouseManager.MouseSensitivity = 1f;
            Sys.FileSystem.CosmosVFS File;
            string current_directory = "0:\\";
            Sys.FileSystem.CosmosVFS fs = new Cosmos.System.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            
        }



        protected override void Run()
        {

            int x = (int)Sys.MouseManager.X;
            int y = (int)Sys.MouseManager.Y;
            
            Pen pen = new Pen(Color.White);
            Pen pen2 = new Pen(Color.Black);
            Pen pen3 = new Pen(Color.Red);

            pen.Color = Color.Red;

            canvas.DrawFilledRectangle(pen2, 0, 0, 1920, 30);
            canvas.DrawString(DateTime.Now.ToString("h:mm:ss tt"), Sys.Graphics.Fonts.PCScreenFont.Default, btnpen, 1800, 10);

            settings();
            crbutton(Cosmos.System.Power.Shutdown, 70, 20, 5, 5, "shutdown", x, y);
            crbutton(terminalIsOpenon, 70, 20, 230, 5, "terminal", x, y) ;

            crbutton(Cosmos.System.Power.Reboot, 70, 20, 80, 5, "reboot", x, y);
            crbutton(settingsisOpened, 70, 20, 155, 5, "Settings", x, y);
            canvas.DrawFilledRectangle(pen3, x, y, 10, 10);
          

            if (terminalIsOpen == true) 
            {
                canvas.Disable();
                
                while (terminalIsOpen)
                {
                E:
                    Console.WriteLine("Enter your password, default password is 'Guest'");
                    string nameofuser = "Guest";
                    string password = "Guest";
                    string input = Console.ReadLine();
                    string current_directory = "0:\\";

                    if (input == password)
                    {
                        Console.Clear();
                        System.Console.WriteLine("______________________help__________________\n" +
                           "exit - return to gui\n" +
                           "mkdir <dir>- create dir\n" +
                           "mkfile <name>.<format> - create file\n" +
                           "dlfile <name>.<format> - delete file\n" +
                           "dldir <dir> - deleting dir with files\n" +
                           "osinfo - get information about OS\n" +
                           "devinfo - get information about developer\n" +
                           "cd - move to dir\n" +
                           "ls - list of files in current dir\n" +
                           "rd - read file\n");
                           
                        
                        while (true)
                        {

                            
                            
                            System.Console.Write(nameofuser + "@GumarOS:" + current_directory + "~: # ");
                            string command = System.Console.ReadLine();
                            string[] cmd = command.Split(' ');
                            if (cmd[0] == "exit")
                            {
                                canvas = FullScreenCanvas.GetFullScreenCanvas();

                                canvas.Mode = new Mode(1920, 1080, ColorDepth.ColorDepth32);
                                terminalIsOpen = false;
                                canvas.Display();
                            }
                            else if (cmd[0] == "mkdir")
                            {
                                try
                                {
                                    Directory.CreateDirectory(current_directory + cmd[1]);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.ToString());
                                }

                            }
                            else if (cmd[0] == "mkfile")
                            {
                                try
                                {
                                    var file_stream = File.Create(current_directory + cmd[1]);
                                }
                                catch (Exception e) { Console.WriteLine(e.ToString()); }

                            }
                            else if (cmd[0] == "dlfile")
                            {
                                try
                                {
                                    File.Delete(current_directory + cmd[1]);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.ToString());
                                }


                            }
                            else if (cmd[0] == "dldir")
                            {
                                try
                                {
                                    Directory.Delete(current_directory + cmd[1]);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.ToString());

                                }
                            }
                            else if (cmd[0] == "osinfo")
                            {

                            }
                            else if (cmd[0] == "devinfo")
                            {
                                Console.WriteLine("01.02.2024 version 0.0.1\nMain programmer - Gumar Arutunyan\nLanguage - C#\nLibrary - Cosmos C#");
                            }
                            else if (cmd[0] == "cd")
                            {
                                if (cmd[1] == "..")
                                {
                                    if (current_directory != "0://")
                                    {
                                        string[] splited_directory = current_directory.Split('/');
                                        for (int i = 0; i < splited_directory.Length; i++)
                                        {
                                            Console.WriteLine(splited_directory);


                                        }

                                    }
                                }
                                else
                                {

                                    var dirs = Directory.GetDirectories(current_directory);
                                    if (dirs.Contains(cmd[1]) == false)
                                    {
                                        Console.WriteLine("Error!");
                                    }
                                    else
                                    {
                                        current_directory = current_directory + cmd[1] + '/';
                                    }
                                }
                            }

                            else if (cmd[0] == "ls")
                            {
                                try
                                {
                                    if (cmd.Length > 1)
                                    {
                                        Console.WriteLine("\nfiles >");
                                        var files_list = Directory.GetFiles(current_directory + cmd[1]);
                                        var directory_list = Directory.GetDirectories(current_directory + cmd[1]);
                                        foreach (var file in files_list)
                                        {
                                            Console.WriteLine(file);
                                        }
                                        Console.WriteLine("\npages >");
                                        foreach (var directory in directory_list)
                                        {
                                            Console.WriteLine(directory);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("files >");
                                        var files_list = Directory.GetFiles(current_directory);
                                        var directory_list = Directory.GetDirectories(current_directory);
                                        foreach (var file in files_list)
                                        {
                                            Console.WriteLine(file);
                                        }
                                        Console.WriteLine("\npages >");
                                        foreach (var directory in directory_list)
                                        {
                                            Console.WriteLine(directory);
                                        }
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.ToString());
                                }


                            }
                            else if (cmd[0] == "rd")
                            {
                                try
                                {
                                    Console.WriteLine(File.ReadAllText(current_directory + cmd[1]));
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.ToString());
                                }

                            }
                            else if (cmd.Length == 0)
                            {

                            }
                            else if (cmd[0] == "write")
                            {
                                string[] lines;
                                string line = "";
                                while (true)
                                {
                                    line = Console.ReadLine();
                                    try
                                    {
                                        if (line == "EXIT")
                                        {
                                            break;
                                        }
                                        else
                                        {

                                            if (cmd[1].StartsWith("0:\\"))
                                            {
                                                File.WriteAllText(cmd[1], "\n" + line);

                                            }
                                            else
                                            {
                                                File.WriteAllText(current_directory + cmd[1], "\n" + line);
                                            }
                                        } 
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.ToString());
                                    }

                                }
                            }
                            else if (cmd[0] == "clr")
                            {
                                Console.Clear();
                            }
                            else if (cmd[0] == "help")
                            {
                                System.Console.WriteLine("______________________help__________________\n" +
                                                           "exit - return to gui\n" +
                                                           "mkdir <dir>- create dir\n" +
                                                           "mkfile <name>.<format> - create file\n" +
                                                           "dlfile <name>.<format> - delete file\n" +
                                                           "dldir <dir> - deleting dir with files\n" +
                                                           "osinfo - get information about OS\n" +
                                                           "devinfo - get information about developer\n" +
                                                           "cd - move to dir\n" +
                                                           "ls - list of files in current dir\n" +
                                                           "rd - read file\n");
                            }
                            else
                            {
                                Console.WriteLine("Error, invalid command!");
                            }
                            

                        }
                    }

                    else
                    {
                        Console.WriteLine("WRONG PASSWORD. TRY AGAIN!");
                        goto E;
                    }
                }
            }
            else
            {
                canvas.Display();
            }


            
            if (color == 1) { canvas.Clear(Color.Purple); }
            if (color == 2) { canvas.Clear(Color.Blue); }
            if (color == 3) { canvas.Clear(Color.Green); }
            if (color == 4) { canvas.Clear(Color.Orange); }
            Heap.Collect();
        }
    }
}