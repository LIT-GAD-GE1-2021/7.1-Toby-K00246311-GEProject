using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFollower : MonoBehaviour
{
    public Transform charPosition;
    private Vector3 camOffset = new Vector3(0, 4, -9);
    public Transform camPosition;
    public float followRate;
  

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void FixedUpdate()
    {
        Follow();
    }

   void Follow()
    {
        Vector3 targPosition = charPosition.position + camOffset;
        Vector3 followingPosition = Vector3.Lerp(camPosition.position, targPosition, followRate * Time.fixedDeltaTime);
        camPosition.position = followingPosition;
    }

}
        
