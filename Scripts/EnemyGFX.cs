using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    Vector2 rotdirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        rotdirection = aiPath.desiredVelocity;
        transform.right = rotdirection;
    }
}
