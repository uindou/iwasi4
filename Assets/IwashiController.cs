using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IwashiController : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 moveDirection;
    public float rotateAngle;
    public float d_theta;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = this.transform.localPosition;
        Vector3 currentRotation = this.transform.localRotation.eulerAngles;
        float tempY;

        // 前に移動
        this.transform.localPosition += new Vector3(0, 0, speed);

        // オイラー角の範囲を[-180,180]に変換
        if (currentRotation.y <= 180f)
        {
            tempY = currentRotation.y;
        }
        else
        {
            tempY = currentRotation.y - 360f;
        }
        
        // 左に移動
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.localPosition += new Vector3(-1*moveSpeed, 0, 0);
            tempY -= d_theta;
 
        }
        // 右に移動
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.localPosition += new Vector3(moveSpeed, 0, 0);
            tempY += d_theta;

        }
        else
        {
            tempY += tempY >= 0 ? -d_theta * Mathf.Abs(tempY*0.1f) : d_theta * Mathf.Abs(tempY*0.1f);
        }


        tempY = Mathf.Clamp(tempY, -rotateAngle, rotateAngle);
        currentRotation.y = tempY;
        this.transform.localRotation = Quaternion.Euler(currentRotation);
            
    }
}
