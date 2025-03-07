using System;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent; //‡@“G‚ª©“®‚Å“®‚­‚½‚ß‚É•K—v
    private float _distance; //‡AƒvƒŒƒCƒ„[‚Æ“G‚Ì‹——£‚ğŠi”[‚·‚é•Ï”
    private GameObject _goal; //‚±‚ê‚ÉƒvƒŒƒCƒ„[‚ğŠi”[

    void Start()
    {
        //œpœj
        nextGoal();

        //’ÇÕ
        agent = GetComponent<NavMeshAgent>();@//‡@
        _goal = GameObject.Find("player");
    }


    /// <summary>
    /// œpœj
    /// </summary>
    void nextGoal()
    {
        var randomPos = new Vector3(UnityEngine.Random.Range(0, 30), 0, UnityEngine.Random.Range(0, 30));
        agent.destination = randomPos;
    }

    void Update()
    {
        //‡A“ñÒŠÔ‚Ì‹——£‚ğŒvZ‚µ‚Äfloat@ˆê’è’l‚¢‚©‚É‚È‚ê‚Î’ÇÕ
        _distance = Vector3.Distance(transform.position, _goal.transform.position);

        if (_distance < 5)
        {
            agent.destination = _goal.transform.position; //‡@
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

    /// <summary>
    /// Õ“Ë”»’è
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) //‘ÎÛ‚ªƒvƒŒƒCƒ„[‚Ìê‡
        {
            KnockBack();
        }
    }

    /// <summary>
    /// “G‚ÌƒmƒbƒNƒoƒbƒN
    /// </summary>
    void KnockBack()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(-transform.forward * 2f, ForceMode.VelocityChange);
    }
}