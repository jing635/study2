using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.ShowPanel<GameLoddyPanel>();
        AudioManager.Instance.PlayMusic("bk2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
