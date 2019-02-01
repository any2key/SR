using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSettings {
   public PlaneInputSettings PlaneInput;

}

public class PlaneInputSettings
{
    public KeyCode Gas { get; set; }
    public KeyCode Brake { get; set; }
    public KeyCode LeftRoll { get; set; }
    public KeyCode RightRoll { get; set; }
    public KeyCode LeftYaw { get; set; }
    public KeyCode RightYaw { get; set; }
    public KeyCode UpPitch { get; set; }
    public KeyCode DownPitch { get; set; }
    public KeyCode Evacuation { get; set; }
    public KeyCode Fire1 { get; set; }
    public KeyCode Fire2 { get; set; }
}

public class OutsideInput
{

}

