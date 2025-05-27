using UnityEngine;
using UnityEngine.UIElements;

public class AgentManager : MonoBehaviour
{
    GameObject [] agents;
    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("AI");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                foreach (GameObject a in agents)
                {
                    a.GetComponent<AiController>().agent.SetDestination(hit.point);
                }
            }
        }
    }
}
