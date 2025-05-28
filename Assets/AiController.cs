using UnityEngine;
using UnityEngine.AI;

public class AiController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    Animator anim;
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 2)
        {
            agent.SetDestination(target.transform.position);
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
        }
    }
}
