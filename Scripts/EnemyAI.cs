using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyAI : MonoBehaviour
{ 
    public Animator anim;
    AIPath aipath;
    public GameObject projpref;
    public Transform firingpoint;
    void Start()
    {
        aipath = GetComponent<AIPath>();
        aipath.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            Attack();
        }
 
    }
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            aipath.enabled = true;
        }
        Attack();
    }*/
    private void Attack()
    {
        
        //anim.SetTrigger("Attack");
        //GameObject proj = Instantiate(projpref, firingpoint.position , Quaternion.identity);
        //Destroy(proj,10f);
    }

    /*
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        CharacterStats player = hitInfo.GetComponent<CharacterStats>();
        if(player!=null)
        {
            player.TakeDamage(10);
            FindObjectOfType<AudioManager>().PlayPlayerSound("PlayerHit");
        }
    }
    
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance =3f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    
    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnpathComplete);
        }
    }
    void OnpathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    private void Update()
    {
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+90));
    }
    void FixedUpdate()
    {
        if(path == null)
            return;
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if(distance<nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
    */
}
