using System;
using System.Diagnostics;
using System.Collections.Generic;


public class Vital
{
    #region Data Members
    string name;
    float lower_limit;
    float upper_limit;
    #endregion

    #region Constructors 
    public Vital (string nname, float lower_limit, float upper_limit)
    {
        this.name = name;
        this.lower_limit = lower_limit;
        this.upper_limit = upper_limit;
    }
    #endregion

    #region Methods
    /*
    public int check_in_range(float val)
    {
        // it checks if the value provided is in rage of the vital 
        // returns if the value is high , low or falls in range
        // 1 --- high
        // 0 --- OK
        // -1 --- low

        if (val < lower_limit)
        {
            return -1;
        }
        else if (val >=lower_limit && val <= upper_limit)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
    */
    public bool isOk(float val)
    {
        if (val >= lower_limit && val <= upper_limit)
        {
            return true;
        }
        return false;
    }
    #endregion
}

public class VitalsDict
{
    Dictionary<string, Vital> dict = new Dictionary<string, Vital>();
    
    public VitalsDict()
    {
        Vital bpm = new Vital("BPM", 70.00f,150.00f);
        Vital RespoRate = new Vital("RespoRate", 30.00f, 95.00f);
        Vital Spo2 = new Vital("Spo2", 90.00f, 101.00f);
        dict.Add("BPM", bpm);
        dict.Add("RESPORATE", RespoRate);
        dict.Add("SPO2", Spo2);
    }

    public Vital getVital(string name)
    {
        return dict[name];
    }
}
class Checker
{
    static VitalsDict dict=new VitalsDict();

    static bool vitalsAreOk(float bpm, float spo2, float respRate) {
        return (isVitalOk(bpm, "bpm") && isVitalOk(spo2, "spo2")&& isVitalOk(respRate, "resporate"));
    }

    static bool isVitalOk(float test_val, string name)
    {
        name = name.ToUpper();
        Vital vit = dict.getVital(name);
        /*
        if (vit.check_in_range(test_val) == 0)
        {
            return true;
        }
        return false;
        */
        return vit.isOk(test_val);
    }

    static void ExpectTrue(bool expression) {
        if(!expression) {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }
    static void ExpectFalse(bool expression) {
        if(expression) {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }
    static int Main() {
        ExpectTrue(vitalsAreOk(100, 95, 60));
        ExpectFalse(vitalsAreOk(40, 91, 92));


        Console.WriteLine("All ok");
        return 0;
    }
}
