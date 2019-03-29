using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float startingSpeed = 0f;
    [SerializeField] float jumpingSpeed = 3f;
    [SerializeField] float fallingSpeed = 0.03f;
    Material myMaterial;
    [SerializeField] Vector2 offset;
    bool crash = false;
   
    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offset = new Vector2 (0f,startingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void Jump()
    {        
        if (Input.GetButtonDown("Jump")) offset.y = jumpingSpeed;
        if(!crash)offset.y -= fallingSpeed; 
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
        //TO DO: crash point
        if (offset.y < -15f)
        {
            crash = true;
            offset.y = 0f;
        }
    }
}
