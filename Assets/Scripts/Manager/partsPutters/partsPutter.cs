using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class partsPutter : MonoBehaviour
{


    //ステージ生成時に呼び出されて、与えられたオブジェクトの子供になる石,木を配置する。削除はstage削除の責任
    public virtual void Init(Transform obj,bool isCenter)
    {
        
    }

    public virtual void makeStones(Transform obj)
    {
        
    }
    
    //地上の物体を生成するやつ。setObjがオブジェクト、setNumが設置する個数。
    public virtual void makeGroundParts( Transform obj,GameObject setObj,int setNum)
    {
        
    }

}
