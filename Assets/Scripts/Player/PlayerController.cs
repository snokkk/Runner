using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public void PickupCoin()
    {
        GameManager.instance.PlusCoin();
    }

    public void OnTriggerEnter(Collider obj)
    {
        if (obj.GetComponent<Collider>().tag == "Coin")
        {
            PickupCoin();
            Destroy(obj.gameObject);
        }

        if (obj.GetComponent<Collider>().tag == "Fin")
        {
            GameManager.instance.IsWinGame(true);
        }
    }

}
