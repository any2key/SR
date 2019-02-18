using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizeMe : MonoBehaviour {

    private Text text;
    public string key;
	void Start () {
        text = GetComponent<Text>();
        text.text = Game.localization[key];
        Game.settings.SettingsChanged += SetText;
    }

    void SetText()
    {
        text.text = Game.localization[key];
    }

    void OnDestroy()
    {
        Game.settings.SettingsChanged -= SetText;
    }
}
