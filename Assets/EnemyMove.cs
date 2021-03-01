using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
	public float speed = 1.5f;
	public float rotateSpeed = 1f;
	public Transform target;
	Vector3 targetRelPos;
	Vector3 prevPos;

	void Start()
    {
		targetRelPos = Vector3.zero;
    }
	void Update()
	{
		prevPos = targetRelPos;
		targetRelPos = target.position - transform.position;//相対座標
		
		targetRelPos.y = 0;
		Rigidbody iwasirigid = GetComponent<Rigidbody>();
		if (targetRelPos.z < 10 && targetRelPos.z>-5)//近づいた時の処理
        {
			targetRelPos.z = 0;
			iwasirigid.AddForce(Vector3.back + targetRelPos.normalized);
			this.transform.rotation = Quaternion.LookRotation(targetRelPos-prevPos)* this.transform.rotation;

		}
        else
        {

			float dottigawa = Vector3.Dot(targetRelPos, transform.right);
			if (dottigawa < 0)
			{
				iwasirigid.AddTorque(-Vector3.up * rotateSpeed);
			}
			else if (dottigawa > 0)
			{
				iwasirigid.AddTorque(Vector3.up * rotateSpeed);
			}

			iwasirigid.velocity = transform.forward * speed;
		}
		

		

	}
}