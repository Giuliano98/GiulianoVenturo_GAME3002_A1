using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_LaunchBall : MonoBehaviour
{
    
    public float launchPower = 600.0f;

    public float maxRangeLaunchPower = 350.0f;

    public Vector3 launchDirection;

    public float launchScalar;

    
    private Vector3 mouseInitPos;
    private Vector3 mouseFinalPos;
    private Vector3 diffPointPos;

    public GameObject ballInitPos;
    private Vector3 initPos;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        initPos = ballInitPos.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        GoToInitPos();
        rb.useGravity = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseInitPos = Input.mousePosition;
            mouseInitPos.z = 0;
        }

        if(Input.GetMouseButtonUp(0))
        {
            mouseFinalPos = Input.mousePosition;
            mouseFinalPos.z = 0;

            diffPointPos = mouseFinalPos - mouseInitPos;
            launchDirection = diffPointPos.normalized;

            launchScalar = Mathf.Min(diffPointPos.magnitude / maxRangeLaunchPower, 1.0f) ;
            
            rb.AddForce(launchDirection * launchPower * launchScalar);
            rb.useGravity = true; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            GoToInitPos();
        }
        if (other.gameObject.CompareTag("Platform"))
        {
            GoToInitPos();
        }
    }

    private void GoToInitPos()
    {
        rb.useGravity = false;
        rb.position = initPos;
        rb.velocity = Vector3.zero;
    }

}
