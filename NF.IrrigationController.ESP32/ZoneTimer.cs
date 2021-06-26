using System;
using System.Diagnostics;
using System.Threading;
using Windows.Devices.Gpio;
namespace NF.IrrigationController.ESP32
{
    public class ZoneTimer
    {
        // Local time difference from UTC
        public static Double TimeOffSet = 0;

        // Zone Pins    
        public static GpioPin Zone1;
        public static GpioPin Zone2;
        public static GpioPin Zone3;
        public static GpioPin Zone4;

        // Switch Pins
        private static GpioPin Zone1SW;
        private static GpioPin Zone2SW;
        private static GpioPin Zone3SW;
        private static GpioPin Zone4SW;
        private static GpioPin ProgramSW;
        private static GpioPin APModeSW;

        // Default times
        public static int Zone1MaxTime = 15;
        public static int Zone2MaxTime = 15;
        public static int Zone3MaxTime = 15;
        public static int Zone4MaxTime = 15;


        // Starts or Stops Program
        public static bool ProgramActivated = false;

        // Shuts off Current Zone
        public static bool CurrentZoneOff = false;

        // Started in Initialize
        private static Thread ZoneThread = new Thread(PollZoneTime);
        private static Thread ProgramThread = new Thread(PollProgram);
        private static Thread DaysThread = new Thread(PollDays);
        private static Thread SwitchsThread = new Thread(PollSwitchs);

        // Polled in Poll Program
        private static bool ZoneActivated = false;

        // Set in RunTimer
        private static bool RanToday = false;
        private static DayOfWeek SameDay = DateTime.Today.DayOfWeek;

        // Set in StartTimer for thread handlers
        private static GpioPin Zone;
        private static double TimeOut;
        private static DateTime TimeNow;

        // Used in ZonesOff and PollProgram
        // Initialized in UpdateZonesArray
        // Called from Initialize
        private struct SZones
        {
            public GpioPin ZoneName;
            public GpioPin ZoneSwitchName;
            public double ZoneTime;
        }

        private static SZones[] Zones = new SZones[4];

        // Used in PollDays
        public struct SDays
        {
            public static bool Mon = false;
            public static bool Tue = false;
            public static bool Wed = false;
            public static bool Thu = false;
            public static bool Fri = false;
            public static bool Sat = false;
            public static bool Sun = false;
            public static int HourOn = 5;
        }

        /// <summary>
        /// Called from Initialize
        /// ToDo: Update if zone times change
        /// </summary>
        public static void UpdateZonesArray()
        {
            Zones[0].ZoneName = Zone1;
            Zones[0].ZoneSwitchName = Zone1SW;
            Zones[0].ZoneTime = Zone1MaxTime;
            Zones[1].ZoneName = Zone2;
            Zones[1].ZoneSwitchName = Zone2SW;
            Zones[1].ZoneTime = Zone2MaxTime;
            Zones[2].ZoneName = Zone3;
            Zones[2].ZoneSwitchName = Zone3SW;
            Zones[2].ZoneTime = Zone3MaxTime;
            Zones[3].ZoneName = Zone4;
            Zones[3].ZoneSwitchName = Zone4SW;
            Zones[3].ZoneTime = Zone4MaxTime;
        }

        /// <summary>
        ///     ''' Zones() array of SZones structure used to cycle zones in PollProgram
        ///     ''' Called from Initialize 
        ///     ''' </summary>
        private static void InitializeZones()
        {

            // Zone 1
            Zone1 = GpioController.GetDefault().OpenPin(13);
            Zone1.SetDriveMode(GpioPinDriveMode.Output);
            Zone1.Write(GpioPinValue.Low);

            // Zone 2
            Zone2 = GpioController.GetDefault().OpenPin(12);
            Zone2.SetDriveMode(GpioPinDriveMode.Output);
            Zone2.Write(GpioPinValue.Low);

            // Zone 3
            Zone3 = GpioController.GetDefault().OpenPin(14);
            Zone3.SetDriveMode(GpioPinDriveMode.Output);
            Zone3.Write(GpioPinValue.Low);

            // Zone 4
            Zone4 = GpioController.GetDefault().OpenPin(27);
            Zone4.SetDriveMode(GpioPinDriveMode.Output);
            Zone4.Write(GpioPinValue.Low);

            // Zone 1 Switch
            Zone1SW = GpioController.GetDefault().OpenPin(26);
            Zone1SW.SetDriveMode(GpioPinDriveMode.InputPullUp);
            //Zone1SW.Write(GpioPinValue.High);

            // Zone 2 Switch
            Zone2SW = GpioController.GetDefault().OpenPin(25);
            Zone2SW.SetDriveMode(GpioPinDriveMode.InputPullUp);
            //Zone2SW.Write(GpioPinValue.High);

            // Zone 3 Switch
            Zone3SW = GpioController.GetDefault().OpenPin(33);
            Zone3SW.SetDriveMode(GpioPinDriveMode.InputPullUp);
            //Zone3SW.Write(GpioPinValue.High);

            // Zone 4 Switch
            Zone4SW = GpioController.GetDefault().OpenPin(23);
            Zone4SW.SetDriveMode(GpioPinDriveMode.InputPullUp);
            //Zone4SW.Write(GpioPinValue.High);


            // Program Switch
            ProgramSW = GpioController.GetDefault().OpenPin(22);
            ProgramSW.SetDriveMode(GpioPinDriveMode.InputPullUp);
            //ProgramSW.Write(GpioPinValue.High);

            // AP Switch
            APModeSW = GpioController.GetDefault().OpenPin(21);
            APModeSW.SetDriveMode(GpioPinDriveMode.InputPullUp);
            //APModeSW.Write(GpioPinValue.High);


        }

        ///  <summary>
        ///  Call before using class object
        ///  </summary>
        ///  <remarks> Starts threads, intializes Zones structure </remarks>
        public static void Initialize()
        {
            InitializeZones();

            UpdateZonesArray();

            ZoneThread.Start();

            ProgramThread.Start();

            DaysThread.Start();

            SwitchsThread.Start();
        }

        /// <summary>
        // Turns on the current zone and turns zone off in TimeOutMinutes
        //  </summary>
        //  <param name="ZoneToActivate"></param>
        //  <param name="TimeOutMinutes"></param>
        //  <remarks>Turns off any zone that is activated</remarks>
        public static void StartTimer(GpioPin ZoneToActivate, double TimeOutMinutes)
        {
            ZonesOff();
            // Set local variable
            Zone = ZoneToActivate;


            // Activate the zone
            Zone.Write(GpioPinValue.High);

            // Set local variable
            TimeOut = TimeOutMinutes;

            // Set local variable
            TimeNow = DateTime.UtcNow;

            // Start polling time in PollZoneTime
            ZoneActivated = true;
        }

        /// <summary>
        /// Polls switchs and takes appropriate actions
        /// ToDo: AP Mode
        /// </summary>
        private static void PollSwitchs()
        {
            while (true)
            {

                for (var i = 0; i <= Zones.Length - 1; i++)
                {

                    if (Zones[i].ZoneSwitchName.Read() == GpioPinValue.Low)
                    {

                        if (Zone == Zones[i].ZoneName)
                        {
                            CurrentZoneOff = true;
                            Debug.WriteLine("Off");

                        }
                        else
                        {
                            StartTimer(Zones[i].ZoneName, Zones[i].ZoneTime);
                            Debug.WriteLine("On");
                        }

                        Thread.Sleep(200);

                    }


                }
                if (APModeSW.Read() == GpioPinValue.Low)
                {
                    Program.oled.ClearScreen();
                    
                    Program.oled.Write(2, 1, "AP MODE");

                    Program.oled.Write(0, 3, "IP: 192.168.1.4");
                }


                    // Debug.WriteLine("AP Mode ToDo");

            if (ProgramSW.Read() == GpioPinValue.Low)
                {

                    if (ProgramActivated == true)
                    {
                        ProgramActivated = false;
                        Debug.WriteLine("Program Cancelled");
                    }
                    else
                    {
                        ProgramActivated = true;
                        Debug.WriteLine("Pragram Activated");
                    }

                }

                Thread.Sleep(100);

            }

        }

        // <summary>
        // Polls for ZoneActivated and then waits for the local TimeOut varable to shut zone off
        // </summary>
        // <remarks>CurrentZoneOff will shut the zone off when set to true</remarks>
        private static void PollZoneTime()
        {
            while ((true))
            {
                if (ZoneActivated)
                {
                    if (TimeNow.AddMinutes(TimeOut) < DateTime.UtcNow)
                    {
                        Zone.Write(GpioPinValue.Low);

                        ZoneActivated = false;
                    }
                }

                // User cancelled
                if (CurrentZoneOff)
                {
                    Zone.Write(GpioPinValue.Low);

                    ZoneActivated = false;

                    CurrentZoneOff = false;
                }

                Thread.Sleep(1000);
            }
        }

        // ' '  <summary>
        // ' '  Turns off all zones called from StartTimer and PollProgram
        // ' '  </summary>
        // ' '  <remarks>Zones array initialized in sub Initialize</remarks>
        private static void ZonesOff()
        {
            for (var i = 0; i <= Zones.Length - 1; i++)
            {
                Zones[i].ZoneName.Write(GpioPinValue.Low);

                Thread.Sleep(20);
            }

        }

        // ' '  <summary>
        // ' '  Polls for ProgramActivated varable to be set to True 
        // ' '  </summary>
        // ' '  <remarks>Setting ProgramActivated to False will stop the program and call ZonesOff if program is running</remarks>
        private static void PollProgram()
        {
            int i;

            while ((true))
            {
                if (ProgramActivated)
                {
                    for (i = 0; i <= Zones.Length - 1; i++)
                    {
                        if (Zones[i].ZoneTime > 0)
                            StartTimer(Zones[i].ZoneName, Zones[i].ZoneTime);

                        while ((ZoneActivated))
                        {
                            if (ProgramActivated == false)
                            {
                                ZonesOff();

                                break;
                            }

                            Thread.Sleep(1000);
                        }
                    }

                    ProgramActivated = false;
                }

                // Check every 1 seconds
                Thread.Sleep(1000);
            }
        }

        // ' '  <summary>
        // ' '  Polls for days set to True then calls RunProgram
        // ' '  </summary>
        // ' '  <remarks></remarks>
        private static void PollDays()
        {
            while ((true))
            {

                // Set flag if new day
                if (SameDay != DateTime.Today.DayOfWeek)
                    RanToday = false;

                switch (DateTime.Today.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        {
                            if (SDays.Mon)
                            {
                                if (SDays.HourOn == DateTime.UtcNow.Hour)

                                    RunTimer();
                            }

                            break;
                        }

                    case DayOfWeek.Tuesday:
                        {
                            if (SDays.Tue)
                            {
                                if (ZoneTimer.SDays.HourOn == DateTime.UtcNow.Hour)
                                    RunTimer();
                            }

                            break;
                        }

                    case DayOfWeek.Wednesday:
                        {
                            if (SDays.Wed)
                            {
                                if (SDays.HourOn == DateTime.UtcNow.Hour)
                                    RunTimer();
                            }

                            break;
                        }

                    case DayOfWeek.Thursday:
                        {
                            if (SDays.Thu)
                            {
                                if (SDays.HourOn == DateTime.UtcNow.Hour)
                                    RunTimer();
                            }

                            break;
                        }

                    case DayOfWeek.Friday:
                        {
                            if (SDays.Fri)
                            {
                                if (SDays.HourOn == DateTime.UtcNow.Hour)
                                    RunTimer();
                            }

                            break;
                        }

                    case DayOfWeek.Saturday:
                        {
                            if (SDays.Sat)
                            {
                                if (SDays.HourOn == DateTime.UtcNow.Hour)
                                    RunTimer();
                            }

                            break;
                        }

                    case DayOfWeek.Sunday:
                        {
                            if (SDays.Sun)
                            {
                                if (SDays.HourOn == DateTime.UtcNow.Hour)
                                    RunTimer();
                            }

                            break;
                        }
                }

                // check every 5 mins
                Thread.Sleep(30000);
            }
        }

        // ' '  <summary>
        // ' '  Called from PollDays 
        // ' '  Runs Program if it hasn't run
        // ' '  </summary>
        // ' '  <remarks>Sets local variables SameDay and RanToday</remarks>
        private static void RunTimer()
        {
            if (RanToday == false)
            {
                RanToday = true;

                SameDay = DateTime.Today.DayOfWeek;

                ProgramActivated = true;
            }
        }
    }

}

