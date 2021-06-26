using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using nanoFramework.Runtime.Native;
using System.Diagnostics;


namespace NF.IrrigationController.ESP32
{
    public class Program
    {
        // Set SD public to use in other librarys 
        public static nfStorage SD;

        public static OLED oled;

        public static void Main()
        {
            Debug.WriteLine("Hello world!");

           // UInt32 freememory = Debug.

           // Debug.WriteLine("Free Memory: " + freememory);

            // Create SD storage 
            // Changed SPI pins on board
            int CSPin = 15;
            int MOSIPin = 17;
            int MISOPin = 5;
            int CLKPin = 16;

            //Set constructor to SDCard
            SD = new nfStorage(true, MOSIPin, MISOPin, CLKPin, CSPin);

            // Get configuration files

            // Local time adjustment
            if (SD.FileExists("TimeOffSet.txt"))
            {
                string rs = SD.ReadText("TimeOffSet.txt");

                ZoneTimer.TimeOffSet = Convert.ToInt32(rs);
            }

            // Password
            // Replace with your SSID and Password
            string Password = "3098280065";

            if (SD.FileExists("Password.txt"))
            {
                Password = SD.ReadText("Password.txt");

            }

           // SSID
           // Replace with SSID
            string SSID = "weaver";

            if (SD.FileExists("SSID.txt"))
            {
                SSID = SD.ReadText("SSID.txt");

            }

            
            // Days on
            if (SD.FileExists("DaysOn.txt"))
            {
                char Delimiter = ',';

                string rt = SD.ReadText("DaysOn.txt");

                string[] days = rt.Split(Delimiter);

                if(days.Length > 0)
                {

                    // First part of the string is HourOn
                    ZoneTimer.SDays.HourOn = System.Convert.ToInt32(days[0]);


                    for (int i = 1; i < days.Length; i++)
                    {
                                              
                        switch(days[i])
                        { 
                            case "Sat":
                                ZoneTimer.SDays.Sat = true;
                                break;

                            case "Sun":
                                ZoneTimer.SDays.Sun = true;
                                break;

                            case "Mon":
                                ZoneTimer.SDays.Mon = true;
                                break;

                            case "Tue":
                                ZoneTimer.SDays.Tue = true;
                                break;

                            case "Wed":
                                ZoneTimer.SDays.Wed = true;
                                break;

                            case "Thu":
                                ZoneTimer.SDays.Thu = true;
                                break;

                            case "Fri":
                                ZoneTimer.SDays.Fri = true;
                                break;

                        }

                    }

                }


            }

            // Zone times
            if (SD.FileExists("ZoneTimes.txt"))
            {
                char Delimiter = ',';

                string rt = SD.ReadText("ZoneTimes.txt");

                string[] Zones = rt.Split(Delimiter);

                ZoneTimer.Zone1MaxTime = Convert.ToInt32(Zones[0]);

                ZoneTimer.Zone2MaxTime = Convert.ToInt32(Zones[1]);

                ZoneTimer.Zone3MaxTime = Convert.ToInt32(Zones[2]);

                ZoneTimer.Zone4MaxTime = Convert.ToInt32(Zones[3]);

            }

            else
            {
                string st = "15,15,15,15";

                SD.WriteText("ZoneTimes.txt", st, false);

            }


            // Create SSD1306 Oled
            oled = new OLED(OLED.DeviceConnectionSting.I2C1, 0x3C);

            oled.Initialize();

            oled.ClearScreen();

            oled.Write(0, 2, "Connecting to network");
              
            ZoneTimer.Initialize();
                      

            // Create the web server
            HttpWebServer webServer = new HttpWebServer(SSID, Password);

            // Ceate a method to used when a ServerRequest event is raised
            webServer.ServerRequest += ServerRequest;

           
            while (true)
            {

                // OLED.Write(0, 0, Date.Now.ToString("dd MMM HH:mm"), True)
                oled.Write(0, 6, DateTime.UtcNow.ToString("dd MMM HH:mm"));

                
                //Program.oled.Write(0, 6, DateTime.UtcNow.ToString());

                Thread.Sleep(60000);
            } 

            void ServerRequest()
            {
                Debug.WriteLine(webServer.RequestString);

                string response = GetURL.DecodeURLString(webServer.RequestString);         
               

                //Compose a response
                //string response = "Hello World Utc central date and time is " + DateTime.UtcNow.AddHours(ZoneTimer.TimeOffSet);

                string header = "HTTP/1.0 200 OK\r\nContent-Type: text; charset=utf-8\r\nContent-Length: " + response.Length.ToString() + "\r\nConnection: close\r\n\r\n";

                webServer.clientSocket.Send(Encoding.UTF8.GetBytes(header), header.Length, SocketFlags.None);

                webServer.clientSocket.Send(Encoding.UTF8.GetBytes(response), response.Length, SocketFlags.None);
                
            
            }

           
        }
      
            // Browse our samples repository: https://github.com/nanoframework/samples
            // Check our documentation online: https://docs.nanoframework.net/
            // Join our lively Discord community: https://discord.gg/gCyBu8T
        }
    }

