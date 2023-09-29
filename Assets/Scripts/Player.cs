using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
       Move(); 
    }

    private void Move() {
        var deltaX = Input.GetAxis("Horizontal");
        var newYPos = transform.position.y + deltaX;

        transform.position = new Vector2(transform.position.x, newYPos);
    }
}
