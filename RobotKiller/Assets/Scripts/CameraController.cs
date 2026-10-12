using UnityEngine;
using Unity.Cinemachine;
public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineCamera virtualCamera; 
    [SerializeField] float orbitSpeed; 
    CinemachineOrbitalFollow orbitalFollow;
    void Start()
    {
        virtualCamera = GetComponent<CinemachineCamera>();
        orbitalFollow = virtualCamera.GetComponent<CinemachineOrbitalFollow>();
    }
    void Update() => orbitalFollow.HorizontalAxis.Value += orbitSpeed * Time.deltaTime;
}
