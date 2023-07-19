using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            Debug.Log("more than one player manager");
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

}
