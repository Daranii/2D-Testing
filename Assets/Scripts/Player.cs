using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // TO DO: Add data to save and load

    public void SavePlayer()
    {
        // TO DO: Get slot number from player prefs?
        SaveSystem.Save(this, 1);
    }

    public void LoadPlayer()
    {
        CharacterSaveData data = SaveSystem.Load(1);
    }
}
