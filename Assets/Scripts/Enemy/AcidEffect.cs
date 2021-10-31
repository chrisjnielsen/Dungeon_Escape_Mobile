using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{

    //move right at 3 m per second
    //detect player and deal damage (IDamageable interface)
    //destroy this after 5 seconds
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.SpiderSound();
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * 3 * Time.deltaTime);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IDamageable hit = other.GetComponent<IDamageable>();
            if (hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }       
    }

}
