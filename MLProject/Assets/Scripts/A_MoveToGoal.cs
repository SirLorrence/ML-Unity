using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// needed to inherit from Agent classes
using Unity.MLAgents;  
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class A_MoveToGoal : Agent
{

    [SerializeField] private Transform _targetTransfrom;

     private float _reward = 1f;  
     private float _penality = -1f;


    // Start/resets the run
    public override void OnEpisodeBegin() {
        transform.position = Vector3.up;
    }
    
    // what data does it need to solve it
    public override void CollectObservations(VectorSensor sensor) {
        
        // Space Size is 6 = (2x Vec3) 
        sensor.AddObservation(transform.position); // player position
        sensor.AddObservation(_targetTransfrom.position); 
    }
    
    // assign logic
    public override void OnActionReceived(ActionBuffers actionBuffers) {
        // Debug.Log(actionBuffers.DiscreteActions[0]);
        float forwardVelocity = actionBuffers.ContinuousActions[0]; 
        float rightVelocity = actionBuffers.ContinuousActions[1]; 


        float speed = 5f;
        transform.position += new Vector3(forwardVelocity, 0, rightVelocity) * speed * Time.deltaTime;

    }

    // For manual debugging/testing
    public override void Heuristic(in ActionBuffers actionout) {
        ActionSegment<float> cActions = actionout.ContinuousActions;
        cActions[0] = Input.GetAxisRaw("Horizontal");
        cActions[1] = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Wall")) SetReward(_penality);
        if(other.CompareTag("Goal")) SetReward(_reward);
        EndEpisode(); // Ends the runs
    }
}
