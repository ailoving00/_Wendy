using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlaylist : MonoBehaviour
{
    [SerializeField]
    private string DoorSound;
    // Start is called before the first frame update
    void Start()
    {
        SoundManger.instance.PlaySound(DoorSound);
    }


}
