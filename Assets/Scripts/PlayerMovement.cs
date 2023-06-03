using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 velocityModifier;
    Rigidbody2D rb;
    Animator anim;
    float horizontalMovementInput;
    float oldVelX=0;
    [SerializeField] float drag=0;
    [SerializeField] bool isGrounded;
    [SerializeField] float speed;
    [SerializeField] float jumpspeed;
    [SerializeField] float gravityModifier=1;
    public Sprite headRed,headBlue,eyeLeftRed,eyeLeftBlue,eyeRightRed,eyeRightBlue;
    public SpriteRenderer head,eyeLeft,eyeRight;
    public int polarity=1;
    public Vector2 temp;
    

    // Start is called before the first frame update
    void Start()
    {
        rb=gameObject.GetComponent<Rigidbody2D>();
        anim=gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(rb.velocity.x>0 && gameObject.transform.rotation.y==0)
        {
            transform.rotation=Quaternion.Euler(0,180,0);
        }
        if(rb.velocity.x<0 && gameObject.transform.rotation.y!=0)
        {
              
            transform.rotation= Quaternion.Euler(0,0,0);
        }
        horizontalMovementInput=Input.GetAxisRaw("Horizontal");
        if(velocityModifier.x!=0)
        {
            
            rb.velocity=new Vector2(oldVelX+horizontalMovementInput*speed+velocityModifier.x*Time.deltaTime,rb.velocity.y+velocityModifier.y*Time.deltaTime);
            oldVelX=rb.velocity.x-horizontalMovementInput*speed;
        }
        else
        {
            if (oldVelX>0)
            {
                oldVelX=Mathf.Clamp(oldVelX-drag*Time.deltaTime,0,oldVelX);
            }
            else
            {
                oldVelX=Mathf.Clamp(oldVelX+drag*Time.deltaTime,oldVelX,0);
            }
            
            rb.velocity=new Vector2(oldVelX+horizontalMovementInput*speed,rb.velocity.y+velocityModifier.y*Time.deltaTime);
            oldVelX=rb.velocity.x-horizontalMovementInput*speed;

        }

        anim.SetFloat("xmove",Mathf.Abs(rb.velocity.x));
        anim.SetFloat("oldxmove",Mathf.Abs(oldVelX));


        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity=new Vector2(rb.velocity.x,rb.velocity.y+jumpspeed);
            anim.SetTrigger("Jump");
        }

        if(!isGrounded && velocityModifier==Vector2.zero &&rb.velocity.y<0)
        {
            rb.velocity=new Vector2(rb.velocity.x,rb.velocity.y+Physics2D.gravity.y*(gravityModifier-1)*Time.deltaTime);
        }
        if(Input.GetButtonDown("Fire1"))
        {
            if(polarity==1)
            {
                polarity=-1;
                head.sprite=headBlue;
                eyeLeft.sprite=eyeLeftBlue;
                eyeRight.sprite=eyeRightBlue;
            }
            else
            {
                polarity=1;
                head.sprite=headRed;
                eyeLeft.sprite=eyeLeftRed;
                eyeRight.sprite=eyeRightRed;
            
            }
        }
        temp=velocityModifier;
        
    }

    


    
    public void ChangeVelocityModifier(Vector2 newv)
    {
        
        
        velocityModifier=newv;
        
    }

    public void GroundedSwitch(bool grounded)
    {
        isGrounded=grounded;
    }


}
