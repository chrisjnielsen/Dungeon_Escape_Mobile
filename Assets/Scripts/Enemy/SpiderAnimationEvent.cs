using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{

    private Spider _spider;

    // handle to spider

    private void Start()
    {
        _spider = transform.parent.GetComponent<Spider>();
        //assign handle to the spider
    }
    public void Fire()
    {
        //tell spider to fire
        //Debug.Log("Spider should fire");
        //use handle to tell attack method on spider
        _spider.Attack();
    }
    

}
