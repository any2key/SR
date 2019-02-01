using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicSetttings
{

    private Resolution _resolution;
    public Resolution Resolution
    {
        get { return _resolution; }
        set
        {
            if (value.width < 800)
                _resolution.width = 800;
            else _resolution.width = value.width;

            if (value.height < 600)
                _resolution.height = 600;
            else _resolution.height = value.height;
        }
    }

    private QualitySettings _qlevel;
    public QualityLevel QLevel { get; set; }
    public ShadowResolution ShadowResolution { get; set; }
    public ShadowQuality ShadowQuality { get; set; }
    public AnisotropicFiltering AnisotropicFiltering { get; set; }
    public int AntiAliasing { get; set; }
    public int TextRes { get; set; }
    public int vSync;
}
