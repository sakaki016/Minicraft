using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    public GameObject goal; //‚±‚ê‚ÉƒvƒŒƒCƒ„[‚ğŠi”[
    public NavMeshAgent agent; //‡@“G‚ª©“®‚Å“®‚­‚½‚ß‚É•K—v
    public float distance; //‡AƒvƒŒƒCƒ„[‚Æ“G‚Ì‹——£‚ğŠi”[‚·‚é•Ï”(distane=‹——£)


    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();@//‡@
        goal = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        //‡A“ñÒŠÔ‚Ì‹——£‚ğŒvZ‚µ‚Äfloat@ˆê’è’l‚¢‚©‚É‚È‚ê‚Î’ÇÕ‚·‚é
        distance = Vector3.Distance(transform.position, goal.transform.position);
        Debug.Log(distance);

        if (distance < 5)
        {
            agent.destination = goal.transform.position; //‡@
        }
    }
}
