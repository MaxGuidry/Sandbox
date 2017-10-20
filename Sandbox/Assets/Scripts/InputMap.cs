using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class InputMap
{
    [Serializable]
    class SavableSettings
    {
        //public KeyCode sAttack;
        //public KeyCode sJump;
        //public KeyCode sInteract;
        //public KeyCode sMoveForward;
        //public KeyCode sMoveLeft;
        //public KeyCode sMoveRight;
        //public KeyCode sMoveBack;
    }

    //public static KeyCode Attack { get; set; }
    //public static KeyCode Jump { get; set; }
    //public static KeyCode Interact { get; set; }
    //public static KeyCode MoveForward { get; set; }
    //public static KeyCode MoveLeft { get; set; }
    //public static KeyCode MoveRight { get; set; }
    //public static KeyCode MoveBack { get; set; }
    public static Dictionary<string, KeyCode> KeyBinds;
    public static void SaveSettings()
    {

        //SavableSettings sets = new SavableSettings();
        //List<FieldInfo> savableprops = typeof(SavableSettings).GetFields().ToList();
        //PropertyInfo[] settingsprops = typeof(InputMap).GetProperties();
        //int i = 0;
        ////sets,settingsprops[i].GetValue(this,null),null
        //foreach (var propertyInfo in savableprops)
        //{
        //    propertyInfo.SetValue(sets, settingsprops[i].GetValue(null, null));
        //    i++;
        //}
        // List<string> keys = new List<string>(KeyBinds.Keys);
        // List<KeyCode> keyCodes = new List<KeyCode>(KeyBinds.Values);

        string Json = JsonUtility.ToJson(KeyBinds, true);
        //string codesJson = JsonUtility.ToJson(keyCodes, true);


        string path = Application.persistentDataPath;
        path = Application.dataPath + "/bin";

        if (!File.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        File.WriteAllText(path + "/settings" + ".json", Json);
    }

    public static void LoadSettings()
    {
        //List<string> keys = new List<string>();
        //List<KeyCode> keyCodes = new List<KeyCode>();


        // string keysJson = File.ReadAllText(Application.dataPath + "/bin/keysettings.json");
        // keys = JsonUtility.FromJson< List<string>>(keysJson);
        string Json = File.ReadAllText(Application.dataPath + "/bin/settings.json");
        KeyBinds = JsonUtility.FromJson<Dictionary<string, KeyCode>>(Json);
       
       

    }
    public static KeyCode WhatMouseButton(int i)
    {
        switch (i)
        {
            case 0:
                return KeyCode.Mouse0;
            case 1:
                return KeyCode.Mouse1;
            case 2:
                return KeyCode.Mouse2;
        }
        return KeyCode.None;
    }
    public static KeyCode WhatKeyCode(char c)
    {
        switch (c)
        {
            case 'a':
                return KeyCode.A;
            case 'b':
                return KeyCode.B;
            case 'c':
                return KeyCode.C;
            case 'd':
                return KeyCode.D;
            case 'e':
                return KeyCode.E;
            case 'f':
                return KeyCode.F;
            case 'g':
                return KeyCode.G;
            case 'h':
                return KeyCode.H;
            case 'i':
                return KeyCode.I;
            case 'j':
                return KeyCode.J;
            case 'k':
                return KeyCode.K;
            case 'l':
                return KeyCode.L;
            case 'm':
                return KeyCode.M;
            case 'n':
                return KeyCode.N;
            case 'o':
                return KeyCode.O;
            case 'p':
                return KeyCode.P;
            case 'q':
                return KeyCode.Q;
            case 'r':
                return KeyCode.R;
            case 's':
                return KeyCode.S;
            case 't':
                return KeyCode.T;
            case 'u':
                return KeyCode.U;
            case 'v':
                return KeyCode.V;
            case 'w':
                return KeyCode.W;
            case 'x':
                return KeyCode.X;
            case 'y':
                return KeyCode.Y;
            case 'z':
                return KeyCode.Z;
            case '0':
                return KeyCode.Alpha0;
            case '1':
                return KeyCode.Alpha1;
            case '2':
                return KeyCode.Alpha2;
            case '3':
                return KeyCode.Alpha3;
            case '4':
                return KeyCode.Alpha4;
            case '5':
                return KeyCode.Alpha5;
            case '6':
                return KeyCode.Alpha6;
            case '7':
                return KeyCode.Alpha7;
            case '8':
                return KeyCode.Alpha8;
            case '9':
                return KeyCode.Alpha9;

        }
        return KeyCode.None;

    }

    public static KeyCode SpecialKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            return KeyCode.Space;
        if (Input.GetKeyDown(KeyCode.F1))
            return KeyCode.F1;
        if (Input.GetKeyDown(KeyCode.F2))
            return KeyCode.F2;
        if (Input.GetKeyDown(KeyCode.F3))
            return KeyCode.F3;
        if (Input.GetKeyDown(KeyCode.F4))
            return KeyCode.F4;
        if (Input.GetKeyDown(KeyCode.F5))
            return KeyCode.F5;
        if (Input.GetKeyDown(KeyCode.F6))
            return KeyCode.F6;
        if (Input.GetKeyDown(KeyCode.F7))
            return KeyCode.F7;
        if (Input.GetKeyDown(KeyCode.F8))
            return KeyCode.F8;
        if (Input.GetKeyDown(KeyCode.F9))
            return KeyCode.F9;
        if (Input.GetKeyDown(KeyCode.F10))
            return KeyCode.F10;
        if (Input.GetKeyDown(KeyCode.F11))
            return KeyCode.F11;
        if (Input.GetKeyDown(KeyCode.F12))
            return KeyCode.F12;
        if (Input.GetKeyDown(KeyCode.LeftAlt))
            return KeyCode.LeftAlt;
        if (Input.GetKeyDown(KeyCode.RightAlt))
            return KeyCode.RightAlt;
        if (Input.GetKeyDown(KeyCode.RightShift))
            return KeyCode.RightShift;
        if (Input.GetKeyDown(KeyCode.LeftShift))
            return KeyCode.LeftShift;
        if (Input.GetKeyDown(KeyCode.Tab))
            return KeyCode.Tab;
        if (Input.GetKeyDown(KeyCode.Escape))
            return KeyCode.Escape;

        return KeyCode.None;


    }
}

