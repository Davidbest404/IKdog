using UnityEngine;

public class ProceduralSteps : MonoBehaviour
{
    [SerializeField] StepsController bodyController;
    [SerializeField] HingeJoint hipJoint;
    [SerializeField] HingeJoint kneeJoint;
    [SerializeField] HingeJoint ankleJoint;
    [SerializeField] float hipAmplitude = 30f;
    [SerializeField] float kneeAmplitude = 45f;
    [SerializeField] float ankleAmplitude = 25f;
    [SerializeField] bool isLeadingLeg = true;

    void FixedUpdate()
    {
        float phaseOffset = isLeadingLeg ? 0f : Mathf.PI;
        float currentPhase = bodyController.GlobalPhase + phaseOffset;
        float hipTarget = Mathf.Sin(currentPhase) * hipAmplitude;
        float swingPhase = Mathf.Sin(currentPhase);
        float kneeTarget = 0f;
        if (swingPhase > 0f) kneeTarget += swingPhase * kneeAmplitude;
        float ankleTarget = Mathf.Cos(currentPhase) * ankleAmplitude;
        SetJointTarget(hipJoint, hipTarget);
        SetJointTarget(kneeJoint, kneeTarget);
        SetJointTarget(ankleJoint, ankleTarget);
    }

    void SetJointTarget(HingeJoint joint, float targetAngle)
    {
        JointSpring spring = joint.spring;
        spring.targetPosition = targetAngle;
        joint.spring = spring;
    }
}