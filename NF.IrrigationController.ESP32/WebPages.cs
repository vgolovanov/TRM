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
}

}
