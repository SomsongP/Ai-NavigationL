using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.AI;
using System.Collections.Generic;
using System.Collections;
public class AgentManager : MonoBehaviour
{

    List<NavMeshAgent> agents = new List<NavMeshAgent>();
    IEnumerator coroutine;
    void Start()
    {
        
        GameObject[] a = GameObject.FindGameObjectsWithTag("AI");
        foreach(GameObject go in a)
        {
            agents.Add(go.GetComponent<NavMeshAgent>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                foreach (NavMeshAgent a in agents)
                {
                    a.SetDestination(hit.point);
                }
            }
        }
        coroutine = RanWalk(20f);
        StartCoroutine(coroutine);
        
    }
    private IEnumerator RanWalk(float time)
    {
        Vector3 randomPosition = new Vector3(
    Random.Range(-100f, 100f),
    0f,
    Random.Range(-100f, 100f));
        while (true)
        {
            yield return new WaitForSeconds(time);
            foreach (NavMeshAgent a in agents)
            {
                a.SetDestination(randomPosition);
                Debug.Log("RUnto" + randomPosition);
            }
        }
     }
}
