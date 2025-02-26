using System;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject goal; //‚±‚ê‚ÉƒvƒŒƒCƒ„[‚ğŠi”[
    public NavMeshAgent agent; //‡@“G‚ª©“®‚Å“®‚­‚½‚ß‚É•K—v
    public float distance; //‡AƒvƒŒƒCƒ„[‚Æ“G‚Ì‹——£‚ğŠi”[‚·‚é•Ï”(distane=‹——£)


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
        var randomPos = new Vector3(UnityEngine.Random.Range(0, 40), 0, UnityEngine.Random.Range(0, 40));
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
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("‚Ô‚Â‚©‚Á‚½‚æ");
        if (collision.gameObject.CompareTag("Player"))
        {
            dealDamage();
            _ = DelayAsync(destroyCancellationToken);
        }
    }

    void dealDamage()
    {
        Debug.Log("ƒ_ƒ[ƒWI");
        
    }

    private async ValueTask DelayAsync(CancellationToken token)
    {
        // X•bŠÔ‘Ò‚Â
        await Task.Delay(TimeSpan.FromSeconds(1), token);

        //ƒ_ƒ[ƒW‚ğ—^‚¦‚é
        dealDamage();
    }


}