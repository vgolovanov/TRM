using System;
using System.Text;
using System.Diagnostics;
using nanoFramework.Runtime.Native;



namespace NF.IrrigationController.ESP32
{
   /// <summary>
   /// Decode the URL
   /// </summary>
    public class GetURL
    {
        /// <summary>
        /// Using the first line of the server request find the parameters
        /// </summary>
        /// <param name="strURL"></param>
        /// <returns>Requested web page</returns>
       public static string DecodeURL(string strURL)
        {
            // Just get the first line of the server request string
            string[] fl = strURL.Split('\n');

            strURL = fl[0];

            Debug.WriteLine("Request string first line is: " + strURL);

            if (InString(strURL, "favicon.ico"))
                return "favicon.ico";
            
            //It's a parameter
            if (InString(strURL, "?"))
            {
                //From settings.html
                if (InString(strURL, "settings.html"))
                {
                    Param[]  mParm = Param.DecryptParam(strURL);

                    if (mParm[0].Name.Length > 1)
                    {
                        ProcessSettingsParam(mParm);

                    }

                }


                //From default.html
                if (InString(strURL, "default.html"))
                {
                    Param[] mParm = Param.DecryptParam(strURL);

                    if (mParm[0].Name.Length > 1)
                    {
                        string Status = ProcessDefaultParam(mParm[0].Name);

                        if (Status == "Settings")
                        {
                            return WebPages.SettingsPage();

                        }
                        else
                        {
                            return WebPages.StatusPage(Status);
                        }
                    }
                    
                    
                }

            }

            return WebPages.DefaultPage();
        }
        
        /// <summary>
        /// Save the parameters from the setting web page
        /// </summary>
        /// <param name="mParam"></param>
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
                    string mStr = mParam[0].Value;
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

        /// <summary>
        /// Execute parameters from default.html
        /// </summary>
        /// <param name="ParamName"></param>
        /// <returns>status of the parameter or settings page</returns>
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

