using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
    
{
    public float Speed;
    public GameManager manager;

    float h;
    float v;
    bool isHorizonMove;
    Vector3 dirVec;
    GameObject scanObject;


    Rigidbody2D rigid;

    void Awake() 
    { 
        rigid = GetComponent<Rigidbody2D>(); 
    }

    void Update() 
    {
        h = manager.isAction ? 0 :  Input.GetAxisRaw("Horizontal"); 
        v = manager.isAction ? 0 :  Input.GetAxisRaw("Vertical");

        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");

        if (hDown || vUp) isHorizonMove = true;
        else if (vDown || hUp) isHorizonMove = false;

        //direc
        if (vDown && v == 1) dirVec = Vector3.up;
        else if (vDown && v == -1) dirVec = Vector3.down;
        else if (hDown && h == -1) dirVec = Vector3.left;
        else if (hDown && h == 1) dirVec = Vector3.right;

        //scan obj
        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            //Debug.Log("This is : " + scanObject.name);
            manager.Action(scanObject);
        }

    }

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.linearVelocity = moveVec * Speed;
        //rigid.linearVelocity = new Vector2(h*4, v*4) ;
        Debug.DrawRay(rigid.position,dirVec*0.7f,new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec , 0.7f, LayerMask.GetMask("Object"));
        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }
}
