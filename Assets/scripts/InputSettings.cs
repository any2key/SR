using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSettings
{
    public PlaneInputSettings PlaneInput;
    public OutsideInputSettings OtsideInput;

    public InputSettings()
    {
        PlaneInput = new PlaneInputSettings()
        {
            Gas = KeyCode.W,
            Brake=KeyCode.S,
            LeftRoll=KeyCode.A,
            RightRoll=KeyCode.D,
            LeftYaw=KeyCode.Q,
            RightYaw=KeyCode.E,
            UpPitch=KeyCode.DownArrow,
            DownPitch=KeyCode.UpArrow,
            Evacuation=KeyCode.G,
            Fire1=KeyCode.Space,
            Fire2=KeyCode.LeftShift
        };
        OtsideInput = new OutsideInputSettings()
        {
            Forward=KeyCode.W,
            Back=KeyCode.S,
            Jump=KeyCode.Space,
            Left=KeyCode.A,
            Right=KeyCode.D
        };
    }
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

public class OutsideInputSettings
{
    public KeyCode Forward { get; set; }
    public KeyCode Back { get; set; }
    public KeyCode Left { get; set; }
    public KeyCode Right { get; set; }
    public KeyCode Jump { get; set; }
}

