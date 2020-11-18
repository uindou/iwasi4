using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using System.Threading;
using UnityEngine;

public class IwashiController : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 moveDirection;
    public float rotateAngle;
    public float d_theta;
    public float speed;
    public float boostSpeed;
    public float my_force;
    private bool isOnFloor;
    public bool survival_mode;
    private bool is_already_entered;
    public GameObject boostEffect;

    private GameObject floor;
    private FloorManager floorManager;

    private int hp;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        isOnFloor = true;
        is_already_entered = false;
        hp = 2;

    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Floor" && isOnFloor)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Rigidbody rb = this.GetComponent<Rigidbody> (); 
                Vector3 force = new Vector3 (0.0f, my_force, 0.0f); 
                rb.AddForce (force, ForceMode.Impulse);
                isOnFloor = false;
                is_already_entered = true;
            }

        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (is_already_entered)
        {
            is_already_entered = false;
            if (other.gameObject.tag != "Floor")
            {
                if (survival_mode)
                {
                    GameOver();
                }
            }
            else
            {
                floor = other.gameObject;
                floorManager = floor.GetComponent<FloorManager>();
                floorManager.WaterLanding();
                isOnFloor = true;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = this.transform.localPosition;
        Vector3 currentRotation = this.transform.localRotation.eulerAngles;
        float tempY;

        // 前に移動
        // this.transform.localPosition += new Vector3(0, 0, speed);

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


        if (Input.GetKey(KeyCode.DownArrow)){
            boostEffect.SetActive(true);
            this.transform.localPosition += new Vector3(0, 0, boostSpeed);
        }
        else {
            boostEffect.SetActive(false);
            this.transform.localPosition += new Vector3(0, 0, speed);
        }

        tempY = Mathf.Clamp(tempY, -rotateAngle, rotateAngle);
        currentRotation.y = tempY;
        this.transform.localRotation = Quaternion.Euler(currentRotation);
    }

    void GameOver()
    {
        SceneManager.LoadScene("Title");
    }

}
