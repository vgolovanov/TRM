// This Class module was derived from code written by Laurent Ellerbach for .netmf


// This Class module was written by Laurent Ellerbach in C#
// https://blogs.msdn.microsoft.com/laurelle/
// David Weaver translated it to VB with minor changes

/// <summary>

/// ''' Get the Parameters from URL

/// ''' </summary>
using System;

namespace NF.IrrigationController.ESP32
{
public class Param
{
    public const char ParamSeparator = '&';

    public const char ParamStart = '?';

    public const char ParamEqual = '=';

    public string Name
    {
        get
        {
            return m_Name;
        }

        set
        {
            m_Name = value;
        }
    }

    private string m_Name;

    public string Value
    {
        get
        {
            return m_Value;
        }

        set
        {
            m_Value = value;
        }
    }

    private string m_Value;

    public static Param[] DecryptParam(String Parameters)
    {
        Param[] retParams = null;

        int i = Parameters.IndexOf(ParamStart);

        int j = i;

        int k;

        if (i >= 0)
        {

            // look at the number of = and ;
            while ((i < Parameters.Length) || (i == -1))
            {
                j = Parameters.IndexOf(ParamEqual, i);

                if (j > i)
                {

                    // first param!
                    if (retParams == null)
                    {
                        retParams = new Param[1];

                        retParams[0] = new Param();
                    }
                    else
                    {
                        Param[] rettempParams = new Param[retParams.Length + 1];

                        retParams.CopyTo(rettempParams, 0);

                        rettempParams[rettempParams.Length - 1] = new Param();

                        retParams = new Param[rettempParams.Length - 1 + 1];

                        rettempParams.CopyTo(retParams, 0);
                    }

                    k = Parameters.IndexOf(ParamSeparator, j);

                    retParams[retParams.Length - 1].Name = Parameters.Substring(i + 1, j - i - 1);


                    if (k == j)
                        retParams[retParams.Length - 1].Value = "";
                    else if (k > j)
                        retParams[retParams.Length - 1].Value = Parameters.Substring(j + 1, k - j - 1);
                    else
                        retParams[retParams.Length - 1].Value = Parameters.Substring(j + 1, Parameters.Length - j - 1);

                    if (k > 0)
                        i = Parameters.IndexOf(ParamSeparator, k);
                    else
                        i = Parameters.Length;
                }
                else
                    i = -1;
            }
        }

        return retParams;
    }
}

}
