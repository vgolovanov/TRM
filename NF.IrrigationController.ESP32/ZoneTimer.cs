using System;
using System.Threading;
//using Windows.Devices.Gpio;
using System.Device.Gpio;
using System.Diagnostics;


namespace NF.IrrigationController.ESP32
{
    public class ZoneTimer
    {
        // Local time difference from UTC
        public static Double TimeOffSet = -5;
             
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
        private static Thread ZoneThread = new(PollZoneTime);
        private static Thread ProgramThread = new(PollProgram);
        private static Thread DaysThread = new(PollDays);
       

        // Polled in Poll Program
        private static bool ZoneActivated = false;

        // Set in Run Timer
        public static int MinutesAdjusted = -3;

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

       public ZoneTimer()
        {
            Initialize();
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
        private void InitializeZones()
        {
            var gpioController = new GpioController();

            // Zone 1 
            Zone1 = gpioController.OpenPin(13);
            Zone1.SetPinMode(PinMode.Output);

            // Zone 2 
            Zone2 = gpioController.OpenPin(12);
            Zone2.SetPinMode(PinMode.Output);

            // Zone 3 
            Zone3 = gpioController.OpenPin(14);
            Zone3.SetPinMode(PinMode.Output);

            // Zone 4 
            Zone4 = gpioController.OpenPin(27);
            Zone4.SetPinMode(PinMode.Output);
            

            // Zone 1 switch
            Zone1SW = gpioController.OpenPin(26);
            Zone1SW.SetPinMode(PinMode.InputPullUp);
            Zone1SW.ValueChanged += Zone1SW_ValueChanged;

            // Zone 2 switch
            Zone2SW = gpioController.OpenPin(25);
            Zone2SW.SetPinMode(PinMode.InputPullUp);
            Zone2SW.ValueChanged += Zone2SW_ValueChanged;

            // Zone 3 switch
            Zone3SW = gpioController.OpenPin(33);
            Zone3SW.SetPinMode(PinMode.InputPullUp);
            Zone3SW.ValueChanged += Zone3SW_ValueChanged;

            // Zone 4 switch
            Zone4SW = gpioController.OpenPin(23);
            Zone4SW.SetPinMode(PinMode.InputPullUp);
            Zone4SW.ValueChanged += Zone4SW_ValueChanged;

            //ProgramSW switch
            ProgramSW = gpioController.OpenPin(22);
            ProgramSW.SetPinMode(PinMode.InputPullUp);
            ProgramSW.ValueChanged += ProgramSW_ValueChanged;

            //APModeSW switch
            APModeSW = gpioController.OpenPin(21);
            APModeSW.SetPinMode(PinMode.InputPullUp);
            APModeSW.ValueChanged += APModeSW_ValueChanged;

        }

        private void UpdateSwitch(string ParamName)
        {

            switch (ParamName)
            {
                case "Zone1On":
                    {
                        if (ZoneActivated)
                        {
                            CurrentZoneOff = true;
                            Debug.WriteLine("Zone 1 timer is off");
                           
                        }
                         else
                        {
                            StartTimer(ZoneTimer.Zone1, ZoneTimer.Zone1MaxTime);
                            Debug.WriteLine("Started Zone 1 timer");
                        }
                            break;
                    }

                case "Zone2On":
                    {
                        if (ZoneActivated)
                        {
                            CurrentZoneOff = true;
                            Debug.WriteLine("Zone 2 timer is off");

                        }
                        else
                        {
                            StartTimer(ZoneTimer.Zone2, ZoneTimer.Zone2MaxTime);
                            Debug.WriteLine("Started Zone 2 timer");
                        }
                        break;
                    }


                case "Zone3On":
                    {
                        if (ZoneActivated)
                        {
                            CurrentZoneOff = true;
                            Debug.WriteLine("Zone 3 timer is off");

                        }
                        else
                        {
                            StartTimer(ZoneTimer.Zone3, ZoneTimer.Zone3MaxTime);
                            Debug.WriteLine("Started Zone 3 timer");
                        }
                       
                        break;
                    }


                case "Zone4On":
                    {
                        if (ZoneActivated)
                        {
                            CurrentZoneOff = true;
                            Debug.WriteLine("Zone 4 timer is off");

                        }
                        else
                        {
                            StartTimer(ZoneTimer.Zone4, ZoneTimer.Zone4MaxTime);
                            Debug.WriteLine("Started Zone 4 timer");
                        }
                        
                        break;
                    }


                case "ProgramOn":
                    {
                        if(ZoneTimer.ProgramActivated == true)
                        {
                            ZoneTimer.ProgramActivated = false;
                            Debug.WriteLine("Program stoped");

                        }
                        else
                        {
                            ZoneTimer.ProgramActivated = true;
                            Debug.WriteLine("Program started");
                        }
                        
                        break;
                        
                    }

                
            }




        }
        private void Zone1SW_ValueChanged(object sender, PinValueChangedEventArgs e)
        {
            
            if (e.ChangeType == PinEventTypes.Rising)
            {
                
                Debug.WriteLine("Zone 1 on");
                
                UpdateSwitch("Zone1On");

            }

        }
           
        private void Zone2SW_ValueChanged(object sender, PinValueChangedEventArgs e)
        {
            if (e.ChangeType == PinEventTypes.Rising)
            {

                Debug.WriteLine("Zone 2 on");

                UpdateSwitch("Zone2On");

            }
        }

        private void Zone3SW_ValueChanged(object sender, PinValueChangedEventArgs e)
        {
            if (e.ChangeType == PinEventTypes.Rising)
            {

                Debug.WriteLine("Zone 3 on");

                UpdateSwitch("Zone3On");

            }
        }

        private void Zone4SW_ValueChanged(object sender, PinValueChangedEventArgs e)
        {
            if (e.ChangeType == PinEventTypes.Rising)
            {

                Debug.WriteLine("Zone 4 on");

                UpdateSwitch("Zone4On");

            }
        }

        private void ProgramSW_ValueChanged(object sender, PinValueChangedEventArgs e)
        {
           
            if (e.ChangeType == PinEventTypes.Rising)
            {

                Debug.WriteLine("Program on");

                UpdateSwitch("ProgramOn");

            }
        }

        private static void APModeSW_ValueChanged(object sender, PinValueChangedEventArgs e)
        {
            
            
            // read Gpio pin value from event
            Debug.WriteLine("USER BUTTON (event) : " + e.ChangeType.ToString());

            // direct read Gpio pin value
            Debug.WriteLine("USER BUTTON (direct): " + APModeSW.Read());

            if (e.ChangeType == PinEventTypes.Rising)
            {
                //_greenLED.Write(PinValue.High);
                Debug.WriteLine("btnPrev Rising");

            }
            else
            {
                //greenLED.Write(PinValue.Low);
                Debug.WriteLine("btnPrev not Rising");
            }
        }


        ///  <summary>
        ///  Call before using class object
        ///  </summary>
        ///  <remarks> Starts threads, intializes Zones structure </remarks>
        private void Initialize()
        {
            InitializeZones();

            UpdateZonesArray();

            ZoneThread.Start();

            ProgramThread.Start();

            DaysThread.Start();

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
            Zone.Write(PinValue.High);

            // Set local variable
            TimeOut = TimeOutMinutes;

            // Set local variable
            TimeNow = DateTime.UtcNow;

            // Start polling time in PollZoneTime
            ZoneActivated = true;
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
                        Zone.Write(PinValue.Low);

                        ZoneActivated = false;
                    }
                }

                // User cancelled
                if (CurrentZoneOff)
                {
                    Zone.Write(PinValue.Low);

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
                Zones[i].ZoneName.Write(PinValue.Low);

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
