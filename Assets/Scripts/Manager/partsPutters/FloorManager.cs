using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;
using System.Threading.Tasks;

public class FloorManager : MonoBehaviour
{
    // Start is called before the first frame update

    public async Task WaterLanding()
    {
        Debug.Log("起動成功");
        double y = 0;
        double period =1;
        double tate = 3;
        int devide = 10;
        Vector3 nowPoint = this.transform.localPosition;
        for (int t = 0; t < devide; t++)
        {
            y = -tate * Math.Sin(Math.PI * period * t /  devide);
            this.transform.localPosition = nowPoint +  new Vector3(0, (float)y, 0);
            Debug.Log(this.transform.localPosition);
            await Task.Delay((int)period * 1000 / devide);
        }
        this.transform.localPosition = nowPoint;
        Debug.Log("終了");
    }


}
