using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCuttor : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null && hit.collider.tag == "Link")
            {
                Destroy(hit.collider.gameObject);
                Destroy(hit.transform.parent.gameObject,2f);
            }
        }       
    }
}
