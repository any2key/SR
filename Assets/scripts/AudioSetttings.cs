using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetttings  {

    private int _sound;
    public int Sound
    {
        get { return _sound; }
        set
        {
            if (value < 0)
                _sound = 0;
            else if (value > 100)
                _sound = 100;
            else _sound = value;
        }
    }

    private int _music;
    public int Music
    {
        get { return _music; }
        set
        {
            if (value < 0)
                _music = 0;
            else if (value > 100)
                _music = 100;
            else _music = value;
        }
    }
}
