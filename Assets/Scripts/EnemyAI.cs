using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class EnemyAI : MonoBehaviour
{
    public GameObject goal; //‚±‚ê‚ÉƒvƒŒƒCƒ„[‚ğŠi”[
    public NavMeshAgent agent; //‡@“G‚ª©“®‚Å“®‚­‚½‚ß‚É•K—v
    public float distance; //‡AƒvƒŒƒCƒ„[‚Æ“G‚Ì‹——£‚ğŠi”[‚·‚é•Ï”(distane=‹——£)

    //public float jumpSpeed = 8f;
    //private float vSpeed = 0f;
    //private bool jump = false;


    void Start()
    {
        //œpœj
        nextGoal();

        //’ÇÕ
        agent = GetComponent<NavMeshAgent>();@//‡@
        goal = GameObject.Find("Player");

    }


    //œpœj
    void nextGoal()
    {
        var randomPos = new Vector3(Random.Range(0, 40), 0, Random.Range(0, 40));
        agent.destination = randomPos;
    }

    void Update()
    {
        //‡A“ñÒŠÔ‚Ì‹——£‚ğŒvZ‚µ‚Äfloat@ˆê’è’l‚¢‚©‚É‚È‚ê‚Î’ÇÕ
        distance = Vector3.Distance(transform.position, goal.transform.position);

        if (distance < 5)
        {
            agent.destination = goal.transform.position; //‡@
        }

        //œpœj

        if (agent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            if (agent.remainingDistance < 0.5f)
            {
                nextGoal();
            }
        }


        //if (jump)
        //{    // if should jump...
        //    vSpeed = jumpSpeed; // aplly jump speed
        //    jump = false; // only jump once!
        //}

    }

    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    Debug.Log("“G‚ª•Ç‚É‚Ô‚Â‚©‚Á‚½");
    //    // only check lateral collisions
    //    if (Mathf.Abs(hit.normal.y) < 0.5)
    //    {
    //        jump = true; // jump if collided laterally
    //    }
    //}
}