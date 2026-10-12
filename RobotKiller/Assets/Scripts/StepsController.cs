using UnityEngine;

public class StepsController : MonoBehaviour
{
    [SerializeField] float stepLength = 1.5f;
    float _globalPhase = 0f;
    float _lastPosZ;
    public float GlobalPhase => _globalPhase;
    void Start() => _lastPosZ = transform.position.z;

    void FixedUpdate()
    {
        float deltaZ = transform.position.z - _lastPosZ;
        _lastPosZ = transform.position.z;
        float phaseDelta = (deltaZ / stepLength) * Mathf.PI * 2f;
        _globalPhase -= phaseDelta;
        if (_globalPhase > Mathf.PI * 2f) _globalPhase -= Mathf.PI * 2f;
        if (_globalPhase < 0f) _globalPhase += Mathf.PI * 2f;
    }
}
