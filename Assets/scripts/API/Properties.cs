using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{

    public string Folder;
    public int LogKeepDays;
    public int LogLevel;
    public string LogFolder;


    public static string _folder;
    public static int _logKeepDays;
    public static int _logLevel;
    public static string _logFolder;

    void Awake()
    {
        _folder = Folder;
        _logKeepDays = LogKeepDays;
        _logLevel = LogLevel;
        _logFolder = LogFolder;
    }

    public void InitPropertiest()
    {
        _folder = Folder;
        _logKeepDays = LogKeepDays;
        _logLevel = LogLevel;
        _logFolder = LogFolder;
    }
}
