using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float RelizeTime = 0.5f;
    public float MaxDrageDistance = 2f;
    public Rigidbody2D rb;
    public Rigidbody2D hooked;
    private bool isPresed = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPresed)
        {
            Vector2 mousePus = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector3.Distance(mousePus, rb.position) > MaxDrageDistance)
                rb.position = hooked.position +(mousePus - hooked.position).normalized * MaxDrageDistance;
            else
                rb.position = mousePus;

        }

    }

    private void OnMouseDown()
    {
        isPresed = true;
        rb.isKinematic = true;
    }
    private void OnMouseUp()
    {
        isPresed = false;
        rb.isKinematic = false;
        StartCoroutine(Relize());
    }

    IEnumerator Relize()
    {
        yield return new WaitForSeconds(RelizeTime);
        GetComponent<SpringJoint2D>().enabled = false;
    }
}
