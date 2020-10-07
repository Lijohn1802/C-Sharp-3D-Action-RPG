using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public static float moveSpeed = 20f;
    public Rigidbody rb;
    public Camera cam;
    public Camera maincam;
    Vector3 movement;
    Vector3 mousePos;
Vector2 mousePos2;
    public Animator anim;
    public Animator animshad;
    //public Item item;
    // Update is called once per frame
    private void Start()
    {
        //FindObjectOfType<AudioManager>().PlayPlayerSound("Music");
        //.instance.Add(item);
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = 0;
        movement.y = Input.GetAxisRaw("Vertical");
         Ray cameraRay = maincam.ScreenPointToRay(Input.mousePosition);
         Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
         float rayLength;
 
         if (groundPlane.Raycast(cameraRay, out rayLength))
         {
             Vector3 pointToLook = cameraRay.GetPoint(rayLength);
             Debug.DrawLine(cameraRay.origin, pointToLook, Color.cyan);
 
             transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
         }
        /*
        Vector3 mouse = Input.mousePosition;
        //mouse.y = 80;
        Vector3 mouseWorld = cam.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y,this.transform.position.y));
        Vector3 forward = mouseWorld - this.transform.position;
        this.transform.rotation = Quaternion.LookRotation(forward,Vector3.up);
       // mousePos = cam.ScreenToWorldPoint(pos);
             //  mousePos2 = maincam.ScreenToWorldPoint(pos);
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(movement.x != 0 || movement.y!=0)
        {
           // anim.SetBool("Walking",true);
            //animshad.SetBool("Walking",true);
        }
        if(movement.x == 0 && movement.y==0)
        {
            //anim.SetBool("Walking",false);
            //animshad.SetBool("Walking",false);
        }              */
    }
    public float angleoffset;

    public float playerangle;
    private void FixedUpdate()
    {        
        //if (!Input.GetKeyDown(KeyCode.Space))
        //{
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //}
        /*Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + playerangle;
        //rb.rotation = angle;
        rb.MoveRotation(Quaternion.Euler(90,0,angle));*/
    }
}
