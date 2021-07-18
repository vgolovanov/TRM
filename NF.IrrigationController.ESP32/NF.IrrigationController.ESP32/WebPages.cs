using System;
using System.Diagnostics;

namespace NF.IrrigationController.ESP32
{
    public class WebPages
    {
        public static string RouterSettingsPage()
        {
            string t = string.Empty;

            t += "\r\n" + "<head><title>";
            t += "\r\n" + "	Router Settings";
            t += "\r\n" + "</title></head>";
            t += "\r\n" + "<meta name=\"viewport\" content=\"width=device-width; initial-scale=1.0; maximum-scale=1.0;\"></head>";
            t += "\r\n" + "<body bgcolor=\"whitesmoke\">";
            t += "\r\n" + "    <form name=\"form1\" method=\"get\" action=\"RouterSettings.html\" id=\"form1\">";
            t += "\r\n" + "    <div>";
            t += "\r\n" + "        <span style=\"color:Gray;background-color:Transparent;border-color:White;font-family:Arial;font-size:Medium; left: 16px; position: absolute; top: 8px\">";
            t += "\r\n" + "</span>";
            // Title
            t += "\r\n" + "        <span style=\"display:inline-block;font-family:Arial;font-size:Large;width:200px;";
            t += "\r\n" + "            left: 30px; position: absolute; top: 16px\">Router Settings</span>";
            // SSID
            t += "\r\n" + "        <span  style=\"font-family:Arial;z-index: 100; left: 16px;";
            t += "\r\n" + "            position: absolute; top: 56px\">SSID:</span>";
            t += "\r\n" + "        <input name=\"SSID\" type=\"text\" value=\"\"  style=\"width:120px;z-index: 101; left: 120px; position: absolute;";
            t += "\r\n" + "            top: 56px\" />";

            // Password
            t += "\r\n" + "        <span  style=\"display:inline-block;font-family:Arial;width:168px;z-index: 103; left: 16px;";
            t += "\r\n" + "            position: absolute; top: 96px\">Password:</span>";
            t += "\r\n" + "        <input name=\"Password\" type=\"text\" value=\"\"  style=\"width:120px;z-index: 104; left: 120px; position: absolute;";
            t += "\r\n" + "            top: 96px\" />";

            // Save SSID
            t += "\r\n" + "        <input type=\"submit\" name=\"Save\" value=\"Save\"  style=\"width:104px;z-index: 102; left: 120px; position: absolute;";
            t += "\r\n" + "            top: 146px\" />";
            t += "\r\n" + "    ";
            t += "\r\n" + "    </div>";
            t += "\r\n" + "    </form>";
            t += "\r\n" + "</body>";
            t += "\r\n" + "</html>";
            t += "\r\n" + "\r\n";

            return t;
        }

        public static string DefaultPage()
        {
            string t = string.Empty;

            t += "\r\n" + "<html>";
            t += "\r\n" + "<head>";
            t += "\r\n" + "<meta http-equiv=\"Content-Language\" content=\"en-us\">";
            t += "\r\n" + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1252\">";
            t += "\r\n" + "<meta name=\"msapplication-TileColor\" content=\"#ffffff\">";
            t += "\r\n" + "<meta name=\"msapplication-TileImage\" content=\"ms-icon-144x144.png\">";
            t += "\r\n" + "<meta name=\"theme-color\" content=\"#ffffff\">";
            t += "\r\n" + "<title>Tiny Rain Maker</title>";
            t += "\r\n" + "<meta name=\"viewport\" content=\"width=device-width; initial-scale=1.1; maximum-scale=2.0;\">";
            t += "\r\n" + "</head>";
            t += "\r\n" + "<body bgcolor=\"whitesmoke\">";
            t += "\r\n" + "    <form name=\"form1\" method=\"get\" action=\"default.html\" id=\"form1\">";
            t += "\r\n" + "        <span style=\"display:inline-block;font-family:Arial;font-size:Large;width:200px;";
            t += "\r\n" + "            left: 48px; position: absolute; top: 16px\">Tiny Rain Maker</span>";
            t += "\r\n" + "        <span style=\"font-family:Arial; left: 24px; position: absolute; top: 64px\">Zone 1:</span>";
            t += "\r\n" + "        <input type=\"submit\" name=\"Zone1On\" value=\"On\"  style=\" left: 104px; position: absolute; top: 64px\" />";
            t += "\r\n" + "        <input type=\"submit\" name=\"Zone1Off\" value=\"Off\"  style=\" left: 152px; position: absolute;top: 64px\" />";
            t += "\r\n" + "            ";
            t += "\r\n" + "        <span style=\"font-family:Arial; left: 24px; position: absolute; top: 104px\">Zone 2:</span>";
            t += "\r\n" + "        <input type=\"submit\" name=\"Zone2On\" value=\"On\" style=\" left: 104px; position: absolute; top: 104px\" />";
            t += "\r\n" + "        <input type=\"submit\" name=\"Zone2Off\" value=\"Off\"  style=\" left: 152px; position: absolute;  top: 104px\" />";
            t += "\r\n" + "            ";
            t += "\r\n" + "        <span style=\"font-family:Arial; left: 24px; position: absolute; top: 144px\">Zone 3:</span>";
            t += "\r\n" + "        <input type=\"submit\" name=\"Zone3On\" value=\"On\" style=\" left: 104px; position: absolute; top: 144px\" />";
            t += "\r\n" + "        <input type=\"submit\" name=\"Zone3Off\" value=\"Off\" style=\" left: 152px; position: absolute;top: 144px\" />          ";
            t += "\r\n" + "            ";
            t += "\r\n" + "        <span  style=\"font-family:Arial; left: 24px; position: absolute; top: 184px\">Zone 4:</span>";
            t += "\r\n" + "        <input type=\"submit\" name=\"Zone4On\" value=\"On\" style=\" left: 104px; position: absolute; top: 184px\" />";
            t += "\r\n" + "        <input type=\"submit\" name=\"Zone4OFF\" value=\"Off\"  style=\" left: 152px; position: absolute; top: 184px\" />    ";
            t += "\r\n" + "               ";
            t += "\r\n" + "        <span style=\"font-family:Arial;z-index: 110; left: 8px; position: absolute; top: 224px\">Program:</span>";
            t += "\r\n" + "        <input type=\"submit\" name=\"ProgramOn\" value=\"On\"  style=\" left: 104px; position: absolute; top: 224px\" />";
            t += "\r\n" + "        <input type=\"submit\" name=\"ProgramOff\" value=\"Off\"  style=\" left: 152px; position: absolute; top: 224px\" />";
            t += "\r\n" + "                    ";
            t += "\r\n" + "        <input type=\"submit\" name=\"Settings\" value=\"Settings\" id=\"Settings\" style=\"width:88px;z-index: 111; left: 104px; position: absolute; top: 264px\" />";
            t += "\r\n" + "                    ";
            t += "\r\n" + "            ";
            t += "\r\n" + "          ";
            t += "\r\n" + "        </form></body></html>";
            t += "\r\n\r\n";

            return t;
        }

        public static string StatusPage(string Status)
        {
            string t = string.Empty;

            t = t + "<html>";
            t = t + "<head>";
            t = t + "<meta http-equiv=\"Content-Language\" content=\"en-us\">";
            t = t + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1252\">";
            t = t + "<title>Tiny Rain Maker</title>";
            t = t + "<meta name=\"viewport\" content=\"width=device-width; initial-scale=1.0; maximum-scale=1.0;\">";
            t = t + "</head>";
            t = t + "<body>";
            t = t + "<h1>" + Status + "</h1>";
            t = t + "</body>";
            t = t + "</html>";
            t += "\r\n\r\n";

            return t;
        }

        public static string SettingsPage()
        {
            string t = string.Empty;


            t += "\r\n" + "<html>";
            t += "\r\n" + "<head>";
            t += "\r\n" + "<meta http-equiv=\"Content-Language\" content=\"en-us\">";
            t += "\r\n" + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1252\">";
            t += "\r\n" + "<title>Settings</title>";
            t += "\r\n" + "<meta name=\"viewport\" content=\"width=device-width; initial-scale=1.0; maximum-scale=1.0;\">";
            t += "\r\n" + "</head>";
            t += "\r\n" + "<body>";
            t += "\r\n" + "<form method=\"Get\" action=\"settings.html\">";
            t += "\r\n" + "		";
            t += "\r\n" + "	<h1>Set Zone Times</h1>";
            t += "\r\n" + "	<p>Zone 1 maximum time <select size=\"1\" name=\"Zone1MaxTime\">";
            if (ZoneTimer.Zone1MaxTime < 10)
                t += "\r\n" + "	<option selected>0" + ZoneTimer.Zone1MaxTime.ToString() + "</option>";
            else
                t += "\r\n" + "	<option selected>" + ZoneTimer.Zone1MaxTime.ToString() + "</option>";
            t += "\r\n" + "	<option>00</option>";
            t += "\r\n" + "	<option>05</option>";
            t += "\r\n" + "	<option>10</option>";
            t += "\r\n" + "	<option>15</option>";
            t += "\r\n" + "	<option>20</option>";
            t += "\r\n" + "	<option>25</option>";
            t += "\r\n" + "	<option>30</option>";
            t += "\r\n" + "	<option>35</option>";
            t += "\r\n" + "	<option>40</option>";
            t += "\r\n" + "	<option>45</option>";
            t += "\r\n" + "	<option>50</option>";
            t += "\r\n" + "	<option>55</option>";
            t += "\r\n" + "	<option>60</option>";
            t += "\r\n" + "	</select> minutes</p>";
            t += "\r\n" + "	<p>Zone 2 maximum time <select size=\"1\" name=\"Zone2MaxTime\">";
            if (ZoneTimer.Zone2MaxTime < 10)
                t += "\r\n" + "	<option selected>0" + ZoneTimer.Zone2MaxTime.ToString() + "</option>";
            else
                t += "\r\n" + "	<option selected>" + ZoneTimer.Zone2MaxTime.ToString() + "</option>";
            t += "\r\n" + "	<option>00</option>";
            t += "\r\n" + "	<option>05</option>";
            t += "\r\n" + "	<option>10</option>";
            t += "\r\n" + "	<option>15</option>";
            t += "\r\n" + "	<option>20</option>";
            t += "\r\n" + "	<option>25</option>";
            t += "\r\n" + "	<option>30</option>";
            t += "\r\n" + "	<option>35</option>";
            t += "\r\n" + "	<option>40</option>";
            t += "\r\n" + "	<option>45</option>";
            t += "\r\n" + "	<option>50</option>";
            t += "\r\n" + "	<option>55</option>";
            t += "\r\n" + "	<option>60</option>";
            t += "\r\n" + "	</select> minutes</p>";
            t += "\r\n" + "	<p>Zone 3 maximum time <select size=\"1\" name=\"Zone3MaxTime\">";
            if (ZoneTimer.Zone3MaxTime < 10)
                t += "\r\n" + "	<option selected>0" + ZoneTimer.Zone3MaxTime.ToString() + "</option>";
            else
                t += "\r\n" + "	<option selected>" + ZoneTimer.Zone3MaxTime.ToString() + "</option>";
            t += "\r\n" + "	<option>00</option>";
            t += "\r\n" + "	<option>05</option>";
            t += "\r\n" + "	<option>10</option>";
            t += "\r\n" + "	<option>15</option>";
            t += "\r\n" + "	<option>20</option>";
            t += "\r\n" + "	<option>25</option>";
            t += "\r\n" + "	<option>30</option>";
            t += "\r\n" + "	<option>35</option>";
            t += "\r\n" + "	<option>40</option>";
            t += "\r\n" + "	<option>45</option>";
            t += "\r\n" + "	<option>50</option>";
            t += "\r\n" + "	<option>55</option>";
            t += "\r\n" + "	<option>60</option>";
            t += "\r\n" + "	</select> minutes</p>";
            t += "\r\n" + "	<p>Zone 4 maximum time <select size=\"1\" name=\"Zone4MaxTime\">";
            if (ZoneTimer.Zone4MaxTime < 10)
                t += "\r\n" + "	<option selected>0" + ZoneTimer.Zone4MaxTime.ToString() + "</option>";
            else
                t += "\r\n" + "	<option selected>" + ZoneTimer.Zone4MaxTime.ToString() + "</option>";
            t += "\r\n" + "	<option>00</option>";
            t += "\r\n" + "	<option>05</option>";
            t += "\r\n" + "	<option>10</option>";
            t += "\r\n" + "	<option>15</option>";
            t += "\r\n" + "	<option>20</option>";
            t += "\r\n" + "	<option>25</option>";
            t += "\r\n" + "	<option>30</option>";
            t += "\r\n" + "	<option>35</option>";
            t += "\r\n" + "	<option>40</option>";
            t += "\r\n" + "	<option>45</option>";
            t += "\r\n" + "	<option>50</option>";
            t += "\r\n" + "	<option>55</option>";
            t += "\r\n" + "	<option>60</option>";
            t += "\r\n" + "	</select> minutes</p>";

            t += "\r\n" + "	<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            t += "\r\n" + "	<input type=\"submit\" value=\"Save\" name=\"ZoneTime\"></p><hr>";
            t += "\r\n" + "</form>";
            t += "\r\n" + "<form method=\"Get\" action=\"settings.html\">";
            t += "\r\n" + "	<h1>Set Program Timer</h1>";
            t += "\r\n" + "	<p>Hour for program to start <select size=\"1\" name=\"HourOn\">";
            t += "\r\n" + "	<option selected>" + ZoneTimer.SDays.HourOn.ToString() + "</option>";
            t += "\r\n" + "	<option>1</option>";
            t += "\r\n" + "	<option>2</option>";
            t += "\r\n" + "	<option>3</option>";
            t += "\r\n" + "	<option>4</option>";
            t += "\r\n" + "	<option>5</option>";
            t += "\r\n" + "	<option>6</option>";
            t += "\r\n" + "	<option>7</option>";
            t += "\r\n" + "	<option>8</option>";
            t += "\r\n" + "	<option>9</option>";
            t += "\r\n" + "	<option>10</option>";
            t += "\r\n" + "	<option>11</option>";
            t += "\r\n" + "	<option>12</option>";
            t += "\r\n" + "	<option>13</option>";
            t += "\r\n" + "	<option>14</option>";
            t += "\r\n" + "	<option>15</option>";
            t += "\r\n" + "	<option>16</option>";
            t += "\r\n" + "	<option>17</option>";
            t += "\r\n" + "	<option>18</option>";
            t += "\r\n" + "	<option>19</option>";
            t += "\r\n" + "	<option>20</option>";
            t += "\r\n" + "	</select></p>";
            t += "\r\n" + "	<fieldset style=\"padding: 2\">";
            t += "\r\n" + "	<legend>Days to Start Timer (Timer is off if no days are checked) </legend>";


            if (ZoneTimer.SDays.Mon)
                t += "\r\n" + "	Mon <input type=\"checkbox\" name=\"Mon\" value=\"ON\" checked>";
            else
                t += "\r\n" + "	Mon <input type=\"checkbox\" name=\"Mon\" value=\"ON\">";

            if (ZoneTimer.SDays.Tue)
                t += "\r\n" + "	Tue <input type=\"checkbox\" name=\"Tue\" value=\"ON\" checked>";
            else
                t += "\r\n" + "	Tue <input type=\"checkbox\" name=\"Tue\" value=\"ON\">";

            if (ZoneTimer.SDays.Wed)
                t += "\r\n" + "	Wed <input type=\"checkbox\" name=\"Wed\" value=\"ON\" checked>";
            else
                t += "\r\n" + "	Wed <input type=\"checkbox\" name=\"Wed\" value=\"ON\">";

            if (ZoneTimer.SDays.Thu)
                t += "\r\n" + "	Thu <input type=\"checkbox\" name=\"Thu\" value=\"ON\" checked>";
            else
                t += "\r\n" + "	Thu <input type=\"checkbox\" name=\"Thu\" value=\"ON\">";
            t += "\r\n" + "<p></p>";
            if (ZoneTimer.SDays.Fri)
                t += "\r\n" + "	Fri <input type=\"checkbox\" name=\"Fri\" value=\"ON\" checked>";
            else
                t += "\r\n" + "	Fri <input type=\"checkbox\" name=\"Fri\" value=\"ON\">";

            if (ZoneTimer.SDays.Sat)
                t += "\r\n" + "	Sat <input type=\"checkbox\" name=\"Sat\" value=\"ON\" checked>";
            else
                t += "\r\n" + "	Sat <input type=\"checkbox\" name=\"Sat\" value=\"ON\">";

            if (ZoneTimer.SDays.Sun)
                t += "\r\n" + "	Sun <input type=\"checkbox\" name=\"Sun\" value=\"ON\" checked></fieldset><p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            else
                t += "\r\n" + "	Sun <input type=\"checkbox\" name=\"Sun\" value=\"ON\"></fieldset><p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";


            t += "\r\n" + "	<input type=\"submit\" value=\"Save\" name=\"Timer\"></p>";
            t += "\r\n" + "	<hr>";
            t += "\r\n" + "	<p>&nbsp;</p>";
            t += "\r\n" + "</form>";

            t += "\r\n" + "<form method=\"Get\" action=\"settings.html\">";
            t += "\r\n" + "	<h1>Set Clock</h1>";
            t += "\r\n" + "	<p>Time Now: " + DateTime.UtcNow + "</p>";
            t += "\r\n" + "	<p></p>";
            t += "\r\n" + "	<legend>Hours to Adjust Clock to Local Time:</legend>";
            t += "\r\n" + "        <select name=\"Hours\"  ";
            t += "\r\n" + "	<option value=" + ZoneTimer.TimeOffSet.ToString() + ">Select</option>";
            t += "\r\n" + "	<option value=\"1\">1</option>";
            t += "\r\n" + "	<option value=\"-1\">-1</option>";
            t += "\r\n" + "	<option value=\"2\">2</option>";
            t += "\r\n" + "	<option value=\"-2\">-2</option>";
            t += "\r\n" + "	<option value=\"3\">3</option>";
            t += "\r\n" + "	<option value=\"-3\">-3</option>";
            t += "\r\n" + "	<option value=\"4\">4</option>";
            t += "\r\n" + "	<option value=\"-4\">-4</option>";
            t += "\r\n" + "	<option value=\"5\">5</option>";
            t += "\r\n" + "	<option value=\"-5\">-5</option>";
            t += "\r\n" + "	<option value=\"6\">6</option>";
            t += "\r\n" + "	<option value=\"-6\">-6</option>";
            t += "\r\n" + "	<option value=\"7\">7</option>";
            t += "\r\n" + "	<option value=\"-7\">-7</option>";
            t += "\r\n" + "	<option value=\"8\">8</option>";
            t += "\r\n" + "	<option value=\"-8\">-8</option>";
            t += "\r\n" + "	<option value=\"9\">9</option>";
            t += "\r\n" + "	<option value=\"-9\">-9</option>";
            t += "\r\n" + "	<option value=\"10\">10</option>";
            t += "\r\n" + "	<option value=\"-10\">-10</option>";
            t += "\r\n" + "	</select></p>";
            t += "\r\n" + "<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";

            t += "\r\n" + "	<input type=\"submit\" value=\"Save\" name=\"OffSet\"></p><hr>";
            t += "\r\n" + "</form>";

            t += "\r\n" + "</body>";
            t += "\r\n" + "</html>";
            t += "\r\n\r\n";

            return t;
        }
        /// <summary>
        /// icon converted to hex 
        /// Converted online from http://tomeko.net/online_tools/file_to_hex.php?lang=en
        /// Convert to byte array
        /// </summary>
        /// <returns></returns>
        public static byte[] faviconpage()
        {
            byte[] favicon = {0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0x10, 0x10, 0x00, 0x00, 0x01, 0x00, 0x20, 0x00, 0x68, 0x04,
0x00, 0x00, 0x16, 0x00, 0x00, 0x00, 0x28, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00, 0x00, 0x20, 0x00,
0x00, 0x00, 0x01, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x12, 0x0B,
0x00, 0x00, 0x12, 0x0B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFD, 0xFD, 0xFF, 0xFE, 0xFD, 0xFD, 0xFF, 0xFE, 0xFD,
0xFC, 0xFF, 0xFE, 0xFD, 0xFD, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFE, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFD,
0xFD, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xE3, 0xD7, 0xD0, 0xFF, 0x97, 0x65, 0x41, 0xFF, 0x92, 0x65,
0x47, 0xFF, 0xE5, 0xDC, 0xD7, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFE, 0xFD, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xB8, 0x7A, 0x3F, 0xFF, 0xC7, 0x76, 0x0E, 0xFF, 0xA3, 0x53,
0x00, 0xFF, 0x90, 0x60, 0x41, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFE, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xF9, 0xF7, 0xF7, 0xFF, 0xD6, 0x96, 0x46, 0xFF, 0xFF, 0xCD, 0x59, 0xFF, 0xDC, 0x91,
0x25, 0xFF, 0x94, 0x5A, 0x2F, 0xFF, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE,
0xFD, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF0, 0xDC, 0xC3, 0xFF, 0xE1, 0xA6, 0x4F, 0xFF, 0xBF, 0x7F,
0x36, 0xFF, 0xDB, 0xC9, 0xBD, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFD, 0xFD, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFC, 0xFB, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xE0, 0xC5, 0xAC, 0xFF, 0xED, 0xDA, 0xC5, 0xFF, 0xFA, 0xFD, 0xFF, 0xFF, 0xF9, 0xFC,
0xFF, 0xFF, 0xF3, 0xE3, 0xC4, 0xFF, 0xE9, 0xD4, 0xB3, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFD,
0xFB, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFD, 0xFC, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF2, 0xEA,
0xE3, 0xFF, 0xC0, 0x62, 0x0A, 0xFF, 0xD6, 0x7C, 0x0B, 0xFF, 0xEB, 0xB6, 0x62, 0xFF, 0xEE, 0xBD,
0x65, 0xFF, 0xF1, 0xAC, 0x15, 0xFF, 0xEF, 0xB0, 0x1D, 0xFF, 0xF9, 0xF4, 0xED, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFE, 0xFD, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFE, 0xFE, 0xFD, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xDE, 0xCF, 0xC8, 0xFF, 0xF7, 0xF5,
0xF6, 0xFF, 0xEF, 0xCE, 0xA6, 0xFF, 0xD9, 0x85, 0x1B, 0xFF, 0xE1, 0x83, 0x00, 0xFF, 0xED, 0x97,
0x02, 0xFF, 0xF7, 0xB8, 0x2C, 0xFF, 0xFF, 0xEF, 0xB7, 0xFF, 0xF4, 0xF3, 0xF4, 0xFF, 0xE5, 0xD9,
0xCB, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFD, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFD, 0xFB,
0xFA, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xDC, 0xC9, 0xBD, 0xFF, 0x9A, 0x3C, 0x00, 0xFF, 0xC1, 0x86,
0x54, 0xFF, 0xF2, 0xF1, 0xF1, 0xFF, 0xFB, 0xFA, 0xFA, 0xFF, 0xF5, 0xE5, 0xD2, 0xFF, 0xF7, 0xE8,
0xD3, 0xFF, 0xFB, 0xFA, 0xFA, 0xFF, 0xEC, 0xE9, 0xF1, 0xFF, 0xE1, 0xBE, 0x69, 0xFF, 0xE8, 0xBA,
0x25, 0xFF, 0xF1, 0xE6, 0xCE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFD, 0xFB, 0xFF, 0xFD, 0xFC,
0xFC, 0xFF, 0xF3, 0xF2, 0xF3, 0xFF, 0xF5, 0xED, 0xE6, 0xFF, 0xBC, 0x75, 0x34, 0xFF, 0xB1, 0x4C,
0x00, 0xFF, 0xC3, 0x6B, 0x12, 0xFF, 0xE1, 0xAB, 0x62, 0xFF, 0xF2, 0xD1, 0x99, 0xFF, 0xF2, 0xD6,
0xA0, 0xFF, 0xEB, 0xC3, 0x7A, 0xFF, 0xED, 0xB3, 0x2D, 0xFF, 0xFD, 0xC6, 0x15, 0xFF, 0xFF, 0xE3,
0x69, 0xFF, 0xFE, 0xFC, 0xF0, 0xFF, 0xF0, 0xEC, 0xEE, 0xFF, 0xFD, 0xFD, 0xFD, 0xFF, 0xC5, 0xAC,
0x9E, 0xFF, 0x81, 0x3D, 0x10, 0xFF, 0xD5, 0xC2, 0xB7, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xD6, 0xAC,
0x86, 0xFF, 0xC3, 0x6C, 0x18, 0xFF, 0xCF, 0x6B, 0x00, 0xFF, 0xE0, 0x7F, 0x01, 0xFF, 0xEB, 0x93,
0x00, 0xFF, 0xF4, 0xA4, 0x04, 0xFF, 0xF9, 0xBA, 0x2B, 0xFF, 0xFD, 0xE1, 0x9B, 0xFF, 0xFC, 0xFF,
0xFF, 0xFF, 0xE2, 0xD2, 0xB8, 0xFF, 0xDE, 0xB6, 0x47, 0xFF, 0xEA, 0xDB, 0xB9, 0xFF, 0xC6, 0xAA,
0x95, 0xFF, 0x7E, 0x31, 0x00, 0xFF, 0x8C, 0x3B, 0x03, 0xFF, 0xBD, 0x94, 0x76, 0xFF, 0xF2, 0xF3,
0xF6, 0xFF, 0xF7, 0xF8, 0xFA, 0xFF, 0xEB, 0xD9, 0xCC, 0xFF, 0xE9, 0xCA, 0xAB, 0xFF, 0xEE, 0xCF,
0xAC, 0xFF, 0xF4, 0xE2, 0xCE, 0xFF, 0xF7, 0xF4, 0xFB, 0xFF, 0xEA, 0xE8, 0xF1, 0xFF, 0xD9, 0xBE,
0x81, 0xFF, 0xF1, 0xCB, 0x3E, 0xFF, 0xFF, 0xE1, 0x51, 0xFF, 0xFB, 0xEC, 0xBE, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xD8, 0xC3, 0xB3, 0xFF, 0x9C, 0x54, 0x18, 0xFF, 0x9C, 0x3F, 0x00, 0xFF, 0xAC, 0x59,
0x11, 0xFF, 0xCF, 0x99, 0x60, 0xFF, 0xEB, 0xCD, 0xA3, 0xFF, 0xF5, 0xE2, 0xC0, 0xFF, 0xF5, 0xE3,
0xC2, 0xFF, 0xEE, 0xD6, 0xAA, 0xFF, 0xE3, 0xBC, 0x6D, 0xFF, 0xE7, 0xB3, 0x28, 0xFF, 0xFB, 0xD2,
0x28, 0xFF, 0xFF, 0xE3, 0x5F, 0xFF, 0xFD, 0xF2, 0xCF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFD,
0xFC, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF4, 0xED, 0xE8, 0xFF, 0xCB, 0xA0, 0x7A, 0xFF, 0xB9, 0x6A,
0x20, 0xFF, 0xBE, 0x5B, 0x00, 0xFF, 0xD1, 0x6C, 0x00, 0xFF, 0xE2, 0x85, 0x00, 0xFF, 0xEC, 0x97,
0x00, 0xFF, 0xF3, 0xA5, 0x02, 0xFF, 0xFB, 0xB4, 0x0D, 0xFF, 0xFF, 0xD0, 0x41, 0xFF, 0xFD, 0xE9,
0x9B, 0xFF, 0xFE, 0xFA, 0xEF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFD, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFE, 0xFD, 0xFC, 0xFF, 0xFE, 0xFE, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF6, 0xF1,
0xEE, 0xFF, 0xE4, 0xCA, 0xB5, 0xFF, 0xDF, 0xB2, 0x86, 0xFF, 0xE3, 0xAE, 0x6E, 0xFF, 0xEA, 0xB8,
0x70, 0xFF, 0xF2, 0xCA, 0x8C, 0xFF, 0xF6, 0xDF, 0xBB, 0xFF, 0xFB, 0xF7, 0xF1, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFF, 0xFF, 0xFF, 0xFD, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, };

            return favicon;
        }

    }
}
