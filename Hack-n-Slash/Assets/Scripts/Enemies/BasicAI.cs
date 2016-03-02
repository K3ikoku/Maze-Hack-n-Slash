using UnityEngine;
using System.Collections;

public class BasicAI : MonoBehaviour
{
        public NavMeshAgent agent;
    private NavMeshAgent charater;
    public enum State
        {
            Patrol,
            Chase
        }

        public State state;
        private bool alive;

        public GameObject[] waypoints;
        private int waypointInd = 0;
        public float patrolSpeed = 0.5f;

        public float chaseSpeed = 1f;
        public GameObject target;
        

    // Use this for initialization
    void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            charater = GetComponent<NavMeshAgent>();

            agent.updatePosition = true;
            agent.updateRotation = false;

            state = BasicAI.State.Patrol;

            alive = true;

            StartCoroutine("FSM");
        }

        IEnumerator FSM()
        {
            while (alive)
            {
                switch (state)
                {
                    case State.Patrol:
                        Patrol();
                        break;
                    case State.Chase:
                        Chase();
                        break;
                }
                yield return null;
            }
        }

        void Patrol()
        {
            agent.speed = patrolSpeed;
            if (Vector3.Distance (this.transform.position, waypoints[waypointInd].transform.position) >= 2)
            {
                agent.SetDestination(waypoints[waypointInd].transform.position);
                charater.Move(agent.desiredVelocity);
            }
            else if (Vector3.Distance (this.transform.position, waypoints[waypointInd].transform.position) <= 2)
            {
                waypointInd += 1;
                if (waypointInd > waypoints.Length)
                {
                    waypointInd = 0;
                }
            }
            else
            {
                charater.Move(Vector3.zero);
            }
        }

        void Chase()
        {
            agent.speed = chaseSpeed;
            agent.SetDestination(target.transform.position);
            charater.Move(agent.desiredVelocity);

        }

        void OnTriggerEnter (Collider coll)
        {
            if (coll.tag == "Player")
            {
                state = BasicAI.State.Chase;
                target = coll.gameObject;
            }
        }
    }











