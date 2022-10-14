using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{

    public GameObject prefab;
    public HingeJoint2D hook;
    public int link;
    public GameObject Weight;
    // Start is called before the first frame update
    void Start()
    {
        GeneratingRope();
    }

    // Update is called once per frame
    
    void GeneratingRope()
    {
        for(int i =0; i < link; i++)
        {

           GameObject Link.instantiate(link.prefab.transform );

        }                        
    }
}
