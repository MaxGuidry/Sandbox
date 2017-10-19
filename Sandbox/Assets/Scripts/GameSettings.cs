using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    Event e;
    // Use this for initialization
    public static KeyCode Attack { get; set; }
    public static KeyCode Jump { get; set; }
    public static KeyCode Interact { get; set; }
    public Canvas menu;
    public GameObject ButtonPrefab;

    void Start()
    {
        Attack = KeyCode.Mouse0;
        Jump = KeyCode.Space;
        Interact = KeyCode.F;
        PropertyInfo[] settingsprops = typeof(GameSettings).GetProperties();
        
        int i = 5;
        foreach (var settingsprop in settingsprops)
        {
            if (settingsprop.PropertyType == typeof(KeyCode))
            {
                GameObject g = Instantiate(ButtonPrefab);
                g.transform.parent = menu.gameObject.transform;
                g.transform.position = Vector3.zero;
                RectTransform rt = g.GetComponent<RectTransform>();
               rt.position =
                    new Vector3(0, i * rt.sizeDelta.y, 0);
                
                i--;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {



    }

    void OnDisable()
    {
        SaveSettings();
    }
    private void OnGUI()
    {
        e = Event.current;
    }
    [Serializable]
    class SavableSettings
    {
        public KeyCode sAttack;
        public KeyCode sJump;
        public KeyCode sInteract;
    }

    void SaveSettings()
    {

        SavableSettings sets = new SavableSettings();
        List<FieldInfo> savableprops = typeof(SavableSettings).GetFields().ToList();
        PropertyInfo[] settingsprops = typeof(GameSettings).GetProperties();
        int i = 0;
        //sets,settingsprops[i].GetValue(this,null),null
        foreach (var propertyInfo in savableprops)
        {
            propertyInfo.SetValue(sets, settingsprops[i].GetValue(this, null));
            i++;
        }

        string json = JsonUtility.ToJson(sets, true);


        string path = Application.persistentDataPath;
        path = Application.dataPath;

        if (!File.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        File.WriteAllText(path + "/bin/settings" + ".json", json);
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


