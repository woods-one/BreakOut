using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour 
{
    [SerializeField]private GameObject gameClearMgr;
    [SerializeField]private GameClearMgr gcm;
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Ball") {
            Destroy(this.gameObject);
            gcm.blockQuantity--;
            Debug.Log(gcm.blockQuantity);
        }
    }
}