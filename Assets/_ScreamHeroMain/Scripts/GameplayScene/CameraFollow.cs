using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private GameObject playerRef;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(playerRef.transform.position.x + offset.x, this.transform.position.y, playerRef.transform.position.z + offset.z);
        Vector3 smoothPosition = Vector3.Lerp(this.transform.position, desiredPosition, speed * Time.deltaTime);
        this.transform.position = smoothPosition;
    }
}
