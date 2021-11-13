using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	[SerializeField] private float delay = 0.5f;
	[SerializeField] private GameObject bullet;
	GameObject projectile;
	private float lastTime;

	// Update is called once per frame    
	private void Update()
	{
		if (Time.time - lastTime > delay)
		{
			//NOT USING OBJ POOL
			//if (Input.GetKey(KeyCode.Space))
			//	SpawnBomb();


			//USING OBJ POOL
			if(Input.GetKey(KeyCode.Space))
				SpawnBombFromPool();
		}
	}

    //NOT USING OBJ POOL
    private void SpawnBomb()
    {
        lastTime = Time.time;
        Vector3 position = transform.position;
        var projectile = Instantiate(bullet, position, Quaternion.identity);
    }

    //USING OBJ POOL
    private void SpawnBombFromPool()
	{
		lastTime = Time.time;
		Vector3 position = transform.position;
		projectile = BasicPool.Instance.GetFromPool();
		projectile.transform.position = position;
		projectile.GetComponent<Rigidbody>().velocity = transform.forward * 20;
	}


}