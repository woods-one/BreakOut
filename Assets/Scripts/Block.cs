using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour 
{
    [SerializeField]private GameObject gameClearMgr;
    [SerializeField]private GameClearMgr gcm;
    void OnCollisionEnter(Collision collision) {
        //衝突判定
        if (collision.gameObject.tag == "Ball") {
            //相手のタグがBallならば、自分を消す
            Destroy(this.gameObject);
            gcm.blockQuantity--;
            Debug.Log(gcm.blockQuantity);
        }
    }
}