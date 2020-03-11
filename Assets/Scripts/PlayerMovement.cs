using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    Vector2 targetPos;
    private Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        transform.position = new Vector3(0f, 0f, 0f);
        targetPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            targetPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (transform.position.x != targetPos.x)
        {
            anim.SetInteger("MoveY", 0);
            if (transform.position.x < targetPos.x)
            {
                Debug.Log("Move left");
                anim.SetInteger("MoveX", 1);
            }
            else
            {
                Debug.Log("Move right");
                anim.SetInteger("MoveX", -1);
            }
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetPos.x, transform.position.y), speed * Time.deltaTime);
        }
        else if (transform.position.y != targetPos.y)
        {
            anim.SetInteger("MoveX", 0);
            if (transform.position.y < targetPos.y)
            {
                Debug.Log("Move up");
                anim.SetInteger("MoveY", 1);
            }
            else
            {
                Debug.Log("Move down");
                anim.SetInteger("MoveY", -1);
            }
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, targetPos.y), speed * Time.deltaTime);
        }
        else
        {
            anim.SetInteger("MoveX", 0);
            anim.SetInteger("MoveY", 0);
        }
    }
}
