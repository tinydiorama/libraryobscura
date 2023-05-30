using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour, iDataPersistence
{
    public bool cutscene1Triggered;
    public bool mailboxInteract1;
    public void LoadData(GameData data)
    {
        this.mailboxInteract1 = data.initialMailbox;
        this.cutscene1Triggered = data.cutscene1triggered;
    }

    public void SaveData(ref GameData data)
    {
        data.initialMailbox = this.mailboxInteract1;
        data.cutscene1triggered = this.cutscene1Triggered;
    }
}
