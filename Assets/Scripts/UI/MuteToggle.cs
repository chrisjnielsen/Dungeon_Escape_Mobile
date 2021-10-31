using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    public void ToggleSound(bool muted)
    {
        AudioManager.instance.MuteAll(muted);
    }
}
