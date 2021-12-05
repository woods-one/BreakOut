using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameClearMgr : MonoBehaviour
{
    public int blockQuantity;
    void Update()
    {
        if(blockQuantity == 0)
        {
　　　　　　　　SceneManager.LoadScene("Title");
        }
    }
}
