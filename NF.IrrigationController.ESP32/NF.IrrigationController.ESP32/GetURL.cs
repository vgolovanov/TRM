using System;
using System.Diagnostics;
using System.Text;

namespace NF.IrrigationController.ESP32
{
   public class GetURL
    {
        public static string DecodeURLString(string strURL )
        {
            if (InString(strURL, "favicon.ico"))
                return "HTTP/1.0 404\r\n";

            
            // Default page in URL
            if (InString(strURL, "default.html"))
            {
                // Get statement returned
                if (InString(strURL, "?"))
                {
                    // Get parameters array
                    Param[] mParm = Param.DecryptParam(strURL);

                    if (mParm[0].Name.Length > 1)
                    {
                       string Status = ProcessDefaultParam(mParm[0].Name);

                        if (Status == "Settings")
                        {
                            return WebPages.SettingsPage() ;

                        }
                        else
                        {
                            return WebPages.StatusPage(Status);
                        }
                    }
                }
                else
                {
                    return WebPages.DefaultPage();
                }

                if (InString(strURL, "settings.html"))
                {
                    if (InString(strURL, "?"))
                    {

                        //ToDo
                        Param[] mParm = Param.DecryptParam(strURL);

                        ProcessSettingsParam(mParm);

                        return WebPages.StatusPage("Under Construction");
                    }
                }
              
               

            }
            return WebPages.DefaultPage();
        }

        private static void ProcessSettingsParam(Param[] mParam)
        {

            if (mParam[0].Name == "Zone1MaxTime")
            {

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


            return "Error";
        }

            

        /// <summary>
        ///     ''' Displays string to console when Debugging is set to True
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

