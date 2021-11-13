using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //NOT USING OBJ POOL
        //Destroy(gameObject);

        //USING OBJ POOL
        BasicPool.Instance.AddToPool(gameObject);
    }
}
