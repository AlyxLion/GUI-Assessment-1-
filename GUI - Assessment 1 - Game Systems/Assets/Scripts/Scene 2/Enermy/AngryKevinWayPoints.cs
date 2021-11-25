using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AngryKevinWayPoints : GradientHealth
{
    public enum AIStates
    {
        Patrol,
        Seek,
        Attack,
        Die
    }
    public AIStates state;
   // public Transform target;
    public Transform player;
    public Transform WayPointParent;
    public Transform[] wayPoints;
    public int curWaypoint, difficulty;
    public NavMeshAgent agent;
    public float walkSpeed, runSpeed, attackRange, attackSpeed, SightRange, baseDamage;
    public Animator anim;
    public bool isDead;
    public float distanceToPoint, changePoint;
    public float stoppingDistance;
    public override void Start()
    {
        base.Start();
        //Get waypoints array from wayp[oint parent
        wayPoints = WayPointParent.GetComponentsInChildren<Transform>();
        //Get navMeshAgent from self
        agent = GetComponent<NavMeshAgent>();
        //Set speed of agent
        agent.speed = walkSpeed;
        //Get animator from self
        anim = GetComponent<Animator>();
        //set target waypoint
        curWaypoint = 1;
        //Set Patrol as default
        Patrol();
    }
    public override void Update()
    {
        base.Update();
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);
        anim.SetBool("Attack", false);

        Patrol();
        Seek();
        Attack();
        Die();
    }
    void Patrol()
    {
        //DO NOT CONTINUE IF NOW WAYPOINTS, dead, player in range
        if (wayPoints.Length <= 0 || Vector3.Distance(player.position, transform.position) <= SightRange || isDead)
        {
            return;
        }
        state = AIStates.Patrol;
        anim.SetBool("Walk", true);
        //Set agent to target
        agent.destination = wayPoints[curWaypoint].position;
        distanceToPoint = Vector3.Distance(transform.position, wayPoints[curWaypoint].position);
        //are we at the waypoint
        if (distanceToPoint <= changePoint)
        {
            //if so go to next  waypoint
            if (curWaypoint < wayPoints.Length - 1)
            {
                curWaypoint++;
            }
            //if at end of patrol go to start
            else
            {
                curWaypoint = 1;
            }
        }
        agent.speed = walkSpeed;

    }
    void Seek()
    {
        //if player is out of our sight range or inside our attack range
        if (Vector3.Distance(player.position, transform.position)>SightRange || Vector3.Distance(player.position, transform.position)< attackRange || isDead)
        {
            //stop seeking
            return;
        }
        //set AI state
        state = AIStates.Seek;
        //set animation
        anim.SetBool("Run", true);
        agent.stoppingDistance = stoppingDistance;
        //Change speed??? up to you
        agent.speed = runSpeed;
        //target is player
        agent.destination = player.position;
    }
    //This method (function/behavior) can be overridden by any class that inherits from this class
    public virtual void Attack()
    {
        //if player in attach range attach 
        if (Vector3.Distance(player.position, transform.position)>attackRange || isDead || PlayerHandler.isDead)
        {
            return;
        }
        agent.stoppingDistance = stoppingDistance;
        agent.speed = 0;
        //Set AU state
        state = AIStates.Attack;
        //Set animation
        anim.SetBool("Attack", true);
    }
    void Die()
    {
        //if we are alive
        if (attributes[0].currentValue > 0 || isDead)
        {
            //dont run this
            return;
        }
        ///set AU state
        state = AIStates.Die;
        //Set animation
        anim.SetTrigger("Die");
        //is dead
        isDead = true;
        //stop moving

        //DropLoot..not yet
    }
}


