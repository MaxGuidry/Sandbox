using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GameSettings : MonoBehaviour
{
    Event e;
    // Use this for initialization
    public static KeyCode Attack = KeyCode.Mouse0;
    public static KeyCode Jump = KeyCode.Space;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.F1))
            SaveSettings();
    }
    private void OnGUI()
    {
        e = Event.current;
    }
    class SavableSettings
    {
        public KeyCode Attack;
        public KeyCode Jump;
    }

    void SaveSettings()
    {

        SavableSettings sets = new SavableSettings();
        sets.Attack = Attack;
        sets.Jump = Jump;
        var json = JsonUtility.ToJson(sets, true);
        

        string path = Application.persistentDataPath;
        path = Application.dataPath;
        
        if (!File.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        File.WriteAllText(path  + "/bin/settings" + ".json", json);
    }
    public void AttackKey()
    {
        StartCoroutine(waitforKeypress());

    }
    IEnumerator waitforKeypress()
    {
        bool key = false;

        while (!key)
        {
            if (e == null)
                yield return null;
            if (e == null)
                continue;
            if (e.isKey)
            {
                key = true;
                Attack = WhatKeyCode(e.character);
                break;
            }
            if (e.isMouse)
            {
                if (e.type == EventType.MouseDown)
                {
                    key = true;
                    Attack = WhatMouseButton(e.button);
                    break;
                }
            }
            yield return null;
        }
        
       

    }
   KeyCode WhatMouseButton(int i)
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
    KeyCode WhatKeyCode(char c)
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
}


