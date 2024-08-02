using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotString : MonoBehaviour
{
    public Transform leftpoint;
    public Transform rightpoint;
    public Transform centerpoint;
     LineRenderer StringShotString;



    // Start is called before the first frame update
    public void Start()
    {
        StringShotString = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        StringShotString.SetPositions(new Vector3[3] { leftpoint.position,centerpoint.position, rightpoint.position });
    }
}
