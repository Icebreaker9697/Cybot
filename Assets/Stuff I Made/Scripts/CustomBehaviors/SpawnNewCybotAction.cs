using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections.Generic;
using UnityEngine.AI;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to move towards the given goal using a NavMeshAgent.
    /// </summary>
    [Action("Navigation/SpawnNewCybotAction")]
    [Help("Moves the game object towards a given target by using a NavMeshAgent")]
    public class SpawnNewCybotAction : GOAction
    {
        private FirstPersonController fpc;

        private UnityEngine.AI.NavMeshAgent navAgent;

        private Transform targetTransform;

        /// <summary>Initialization Method of MoveToGameObject.</summary>
        /// <remarks>Check if GameObject object exists and NavMeshAgent, if there is no NavMeshAgent, the default one is added.</remarks>
        public override void OnStart()
        {
            if (gameObject.GetComponent<NPCScript>().numSpawned < 10)
            {
                GameObject[] choices = GameObject.FindObjectOfType<RandomMap>().Cybots;
                List<GameObject> objects = GameObject.FindObjectOfType<RandomMap>().objects;
                Transform trans = GameObject.FindObjectOfType<RandomMap>().transform;

                GameObject toSpawn = choices[Random.Range(0, choices.Length)];
                Vector3 pos = new Vector3(Random.Range(-57.4f, 57.4f), 1.5f, Random.Range(-57.4f, 57.4f));
                GameObject go = Object.Instantiate(toSpawn, pos, Quaternion.identity);
                objects.Add(go);
                go.transform.SetParent(trans);
                go.GetComponent<NavMeshAgent>().speed = Random.Range(0, 7);
                go.GetComponent<NavMeshAgent>().acceleration = go.GetComponent<NavMeshAgent>().speed * 5;

                gameObject.GetComponent<NPCScript>().numSpawned++;
            }
        }

        /// <summary>Method of Update of MoveToGameObject.</summary>
        /// <remarks>Verify the status of the task, if there is no objective fails, if it has traveled the road or is near the goal it is completed
        /// y, the task is running, if it is still moving to the target.</remarks>
        public override TaskStatus OnUpdate()
        {
            return TaskStatus.COMPLETED;
        }
        /// <summary>Abort method of MoveToGameObject </summary>
        /// <remarks>When the task is aborted, it stops the navAgentMesh.</remarks>
        public override void OnAbort()
        {

#if UNITY_5_6_OR_NEWER
            if (navAgent != null)
                navAgent.isStopped = true;
#else
            if (navAgent!=null)
                navAgent.Stop();
#endif

        }
    }
}
