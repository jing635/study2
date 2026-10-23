using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.ShowPanel<bkimage>();
        UIManager.Instance.ShowPanel<LoginPanel>();
        AudioManager.Instance.PlayMusic("bk1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
