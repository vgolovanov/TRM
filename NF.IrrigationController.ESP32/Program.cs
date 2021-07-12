using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;
using GC = nanoFramework.Runtime.Native.GC;
using NF.SSD1306.i2c;



namespace NF.IrrigationController.ESP32
{


    public class Program
    {
        // Set SD public to use in other librarys 
        public static nfStorage SD;

        public static  OLED oled;

        //public ZoneTimer zoneTimer;



        public static void Main()
        {
            Debug.WriteLine("Hello from ESP32!");

            Debug.WriteLine(">> free memory: " + GC.Run(true) + " bytes");
           
            // Create SD storage 
            // Changed SPI pins on board
            int CSPin = 15;
            int MOSIPin = 17;
            int MISOPin = 5;
            int CLKPin = 16;

            //Set constructor to false for internal storage 
            SD = new nfStorage(false, MOSIPin, MISOPin, CLKPin, CSPin);

            // Get configuration files

            // Local time adjustment
            if (SD.FileExists("TimeOffSet.txt"))
            {
                string rs = SD.ReadText("TimeOffSet.txt");

                ZoneTimer.TimeOffSet = Convert.ToDouble(rs);
            }

            // Password
            // Replace with your SSID and Password
            string Password = "3098280065";

            
            // Use only with SD card with Password.txt 
            //if (SD.FileExists("Password.txt"))
            // {
            //   Password = SD.ReadText("Password.txt");

            // }

           // SSID
           // Replace with SSID
            string SSID = "weaver";

            // Use only with SD card with SSID.txt 
            //  if (SD.FileExists("SSID.txt"))
            //  {
            //    SSID = SD.ReadText("SSID.txt");

            // }


            // Days on
            if (SD.FileExists("Days.txt"))
            {
                char Delimiter = ',';

                string rt = SD.ReadText("Days.txt");

                string[] days = rt.Split(Delimiter);

                if(days.Length > 0)
                {
                    
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
            oled = new(OLED.DisplayType.OLED128x64,18,19,true);
            
            oled.Write(0, 2, "Connecting to network");
          
            // Create the web server
            HttpWebServer webServer = new HttpWebServer(SSID, Password, ZoneTimer.TimeOffSet);

            // Ceate a method to used when a ServerRequest event is raised
            webServer.ServerRequest += ServerRequest;


            var zoneTimer = new ZoneTimer();

            
            
            
                
            while (true)
            {
 
                oled.Write(0, 6, DateTime.UtcNow.ToString("dd MMM HH:mm"));
                
                Thread.Sleep(60000);
            }
 

            void ServerRequest()
            {
                Debug.WriteLine(webServer.RequestString);
                       
                string response = GetURL.DecodeURL(webServer.RequestString);

                if (response == "favicon.ico")
                {
                    Debug.WriteLine("Requested favicon.ico");
                    //image/vnd.microsoft.icon

                    // Send the image
                    byte[] icon = WebPages.faviconpage();

                    string header = "HTTP/1.0 200 OK\r\nContent-Type: image/vnd.microsoft.icon\r\nContent-Length: " + icon.Length.ToString() + "\r\nConnection: close\r\n\r\n";
                   
                    Debug.WriteLine("Icon Length: >> " + icon.Length);

                    webServer.clientSocket.Send(Encoding.UTF8.GetBytes(header), header.Length, SocketFlags.None);

                    webServer.clientSocket.Send(icon, icon.Length, SocketFlags.None);
                    
                }
                else
                { 
                    //Compose a response for testing
                    //string response = "Hello World Utc central date and time is " + DateTime.UtcNow.AddHours(ZoneTimer.TimeOffSet);

                    string header = "HTTP/1.0 200 OK\r\nContent-Type: text; charset=utf-8\r\nContent-Length: " + response.Length.ToString() + "\r\nConnection: close\r\n\r\n";

                    webServer.clientSocket.Send(Encoding.UTF8.GetBytes(header), header.Length, SocketFlags.None);

                    webServer.clientSocket.Send(Encoding.UTF8.GetBytes(response), response.Length, SocketFlags.None);


                }

            }

           
        }



       
            // Browse our samples repository: https://github.com/nanoframework/samples
            // Check our documentation online: https://docs.nanoframework.net/
            // Join our lively Discord community: https://discord.gg/gCyBu8T
        }
    }

