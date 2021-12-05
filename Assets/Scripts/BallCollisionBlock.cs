using UnityEngine;
using System.Collections;

public class BallCollisionBlock : MonoBehaviour 
{
    [SerializeField]private GameObject gameClearMgr;
    [SerializeField]private GameClearMgr gcm;
    private int brockDurability = 2;
    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Ball") 
        {
            brockDurability--;
        }
        if(brockDurability == 0)
        {
            Destroy(this.gameObject);
            gcm.blockQuantity--;
        }
    }
}