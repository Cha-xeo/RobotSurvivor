using UnityEngine;
using UnityEngine.AI;
public class NPCMovement : MonoBehaviour 
{
    [SerializeField] private Transform targetGo;
    [SerializeField] private Transform _thisTranform;
    [SerializeField] private Animator _anime;
    [SerializeField] private Stats _stats;
    private NavMeshAgent navMeshAgent;
    private float TargetAngle => Mathf.Atan2(targetGo.position.x - _thisTranform.position.x, targetGo.position.z - _thisTranform.position.z) * Mathf.Rad2Deg;
    private Quaternion TargetRotaion => Quaternion.Euler(new Vector3(0, TargetAngle, 0));
    void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update (){
        // HeadForDestintation();
    }
    private void FixedUpdate() {
        FaceTarget();
        if (_stats.canMove)
        {
            _anime.SetBool("isRunning", true);
            HeadForDestintation();
        }
        else
        {
            _anime.SetBool("isRunning", false);
        }
    }
    private void HeadForDestintation () {
        Vector3 destination = targetGo.position;
        navMeshAgent.SetDestination (destination);
    }
    public void FaceTarget()
    {
        _thisTranform.rotation = TargetRotaion;
    }
}

