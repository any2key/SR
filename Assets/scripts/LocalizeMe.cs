using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizeMe : MonoBehaviour {

    private Text text;

	void Start () {
        text = GetComponent<Text>();
        text.text = Game.localization["settings"];
        Game.settings.SettingsChanged += SetText;
    }

    void SetText()
    {
        text.text = Game.localization["settings"];
    }

    void OnDestroy()
    {
        Game.settings.SettingsChanged -= SetText;
    }
}
