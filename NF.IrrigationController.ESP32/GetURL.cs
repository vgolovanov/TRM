using nanoFramework.Runtime.Native;
using System;
using System.Text;
using Windows.Storage.Devices;
using System.Diagnostics;

namespace NF.IrrigationController.ESP32
{
   public class GetURL
    {
         public static string DecodeURLString(string strURL)
         {

            // ****** Parse Request here

            string Status = string.Empty;

            if (InString(strURL, "favicon.ico"))
                return "HTTP/1.0 404 \r\n\r\n";

            if (InString(strURL, "settings.html"))
            {
                if (InString(strURL, "?"))
                {
                    Param[] mParm = Param.DecryptParam(strURL);

                    ProcessSettingsParam(mParm);
                  
                    return WebPages.DefaultPage();

                }

                else
                {
                    return WebPages.SettingsPage();
                }
            }

            if (InString(strURL, "default.html"))
            {
                if (InString(strURL, "?"))
                {
                    Param[] mParm = Param.DecryptParam(strURL);
                    
                    if (mParm[0].Name.Length > 1)
                    {
                        Status = ProcessDefaultParam(mParm[0].Name);

                        if (Status == "Settings")
                            return WebPages.SettingsPage();
                        else
                            return WebPages.StatusPage(Status);
                    }
                }
            }

           

            return WebPages.DefaultPage();
        }


        private static void ProcessSettingsParam(Param[] mParam)
        {

            try
            {

                string ZoneTimes = string.Empty;
                
                // Changing Zone Times
                if (mParam[0].Name == "Zone1MaxTime")
                {
                    ZoneTimer.Zone1MaxTime = System.Convert.ToInt32(mParam[0].Value);
                  
                    ZoneTimer.Zone2MaxTime = System.Convert.ToInt32(mParam[1].Value);
                   
                    ZoneTimer.Zone3MaxTime = System.Convert.ToInt32(mParam[2].Value);
                    
                    ZoneTimer.Zone4MaxTime = System.Convert.ToInt32(mParam[3].Value);

                    ZoneTimes = mParam[0].Value + "," + mParam[1].Value + "," + mParam[2].Value + "," + mParam[3].Value;

                    //"ZoneTimes.txt"
                    Program.SD.WriteText("ZoneTimes.txt", ZoneTimes, false);

                    // Zones() array of SZones structure used to cycle zones in PollProgram
                    ZoneTimer.UpdateZonesArray();

                }

                if (mParam[0].Name == "HourOn")
                {

                    // Reset Days
                    ZoneTimer.SDays.Fri = false;
                    ZoneTimer.SDays.Sat = false;
                    ZoneTimer.SDays.Sun = false;
                    ZoneTimer.SDays.Mon = false;
                    ZoneTimer.SDays.Tue = false;
                    ZoneTimer.SDays.Wed = false;
                    ZoneTimer.SDays.Thu = false;
                   
                    // First param is hour on
                   string  mStr = mParam[0].Value;
                    if (mStr == "0")
                        mStr = "1";

                    ZoneTimer.SDays.HourOn = System.Convert.ToInt32(mParam[0].Value);

                    // The last param is the select button
                    for (var i = 1; i <= mParam.Length - 1; i++)
                    {
                        switch (mParam[i].Name)
                        {
                            case "Sat":
                                {
                                    mStr += ",Sat";
                                    ZoneTimer.SDays.Sat = true;
                                    break;
                                }

                            case "Sun":
                                {
                                    mStr += ",Sun";
                                    ZoneTimer.SDays.Sun = true;
                                    break;
                                }

                            case "Mon":
                                {
                                    mStr += ",Mon";
                                    ZoneTimer.SDays.Mon = true;
                                    break;
                                }

                            case "Tue":
                                {
                                    mStr += ",Tue";
                                    ZoneTimer.SDays.Tue = true;
                                    break;
                                }

                            case "Wed":
                                {
                                    mStr += ",Wed";
                                    ZoneTimer.SDays.Wed = true;
                                    break;
                                }

                            case "Thu":
                                {
                                    mStr += ",Thu";
                                    ZoneTimer.SDays.Thu = true;
                                    break;
                                }

                            case "Fri":
                                {
                                    mStr += ",Fri";
                                    ZoneTimer.SDays.Fri = true;
                                    break;
                                }
                        }
                    }

                    Debug.WriteLine("Days " + mStr);                   
                    Program.SD.WriteText("DaysOn.txt", mStr, false);

                }

                if (mParam[0].Name == "Hours")
                {
                    ZoneTimer.TimeOffSet = System.Convert.ToDouble(mParam[0].Value);

                    //ESP8266.LocalTimeOffSet = ESP8266.LocalTimeOffSet + System.Convert.ToInt32(mParam[0].Value);

                    //EEprom24LC256.Write(EEprom24LC256.Address.LocalTimeOffSet, ESP8266.LocalTimeOffSet.ToString);

                    Program.SD.WriteText("TimeOffSet.txt", mParam[0].Value, false);

                    DateTime NewTime = DateTime.UtcNow.AddHours(ZoneTimer.TimeOffSet);

                    Rtc.SetSystemTime(NewTime);

                    Debug.WriteLine("Time Offset: " + mParam[0].Value);

                    Debug.WriteLine("Time " + DateTime.UtcNow);

                                        
                }

               
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error processing Parameters: " + ex.ToString());
            }


        }

        private static string ProcessDefaultParam(string ParamName)
        {
            if (InString(ParamName, "Off") == true)
            {
                ZoneTimer.CurrentZoneOff = true;

                if (ZoneTimer.ProgramActivated)
                {
                    ZoneTimer.ProgramActivated = false;

                    return "Program Off";
                }

                return "Zone Off";
            }

            switch (ParamName)
            {
                case "Zone1On":
                    {
                        ZoneTimer.StartTimer(ZoneTimer.Zone1, ZoneTimer.Zone1MaxTime);

                        return "Zone 1 On";
                    }

                case "Zone2On":
                    {
                        ZoneTimer.StartTimer(ZoneTimer.Zone2, ZoneTimer.Zone2MaxTime);

                        return "Zone 2 On";
                    }

                case "Zone3On":
                    {
                        ZoneTimer.StartTimer(ZoneTimer.Zone3, ZoneTimer.Zone3MaxTime);

                        return "Zone 3 On";
                    }

                case "Zone4On":
                    {
                        ZoneTimer.StartTimer(ZoneTimer.Zone4, ZoneTimer.Zone4MaxTime);

                        return "Zone 4 On";
                    }
                         

                case "ProgramOn":
                    {
                        ZoneTimer.ProgramActivated = true;

                        return "Program Started";
                    }

                case "Settings":
                    {
                        return "Settings";
                    }
            }

            Debug.WriteLine("Error " + ParamName);
            return "Error";
        }

            

        /// <summary>
        ///     ''' Displays string to Debug when Debugging is set to True
        ///     ''' </summary>
        private static void PrintData(string Str)
        {
            Debug.WriteLine(Str);
        }

        /// <summary>
        ///     ''' Returns True if a string is part of another
        ///     ''' </summary>
        private static bool InString(string String1, string StringToFind)
        {
            try
            {
                if (String1 == string.Empty)
                    return false;

                if (StringToFind == string.Empty)
                    return false;

                String1 = String1.ToUpper();

                StringToFind = StringToFind.ToUpper();

                if (String1.IndexOf(StringToFind) == -1)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }


    
    }

