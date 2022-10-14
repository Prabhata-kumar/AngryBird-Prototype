using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{

    public GameObject Linkprefab;
    public Rigidbody2D hook;
    public int links=7;
    public  Wait wait;
    // Start is called before the first frame update
    void Start()
    {
        GeneratingRope();
    }

    // Update is called once per frame
    
    void GeneratingRope()
    {
        Rigidbody2D priviousRB= hook;
        for(int i =0; i < links; i++)
        {

           GameObject link = Instantiate(Linkprefab,transform );
           HingeJoint2D joint= link.GetComponent<HingeJoint2D>();
            joint.connectedBody = priviousRB;

            if (i < links - 1)
            { 
                priviousRB = link.GetComponent<Rigidbody2D>();
            }
            else
            {
                wait.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
            }
        }                        
    }
}
