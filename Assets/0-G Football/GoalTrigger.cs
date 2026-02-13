using UnityEngine;
using TMPro;

public class GoalTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Transform ballTransform;
    [SerializeField] private Transform shipTransform;

    private Rigidbody _ballRb;
    private Rigidbody _shipRb;
    private Vector3 _ballStart;
    private Vector3 _shipStart;
    private Quaternion _shipStartRot;
    private int _score;

    private void Awake()
    {
        _ballRb = ballTransform.GetComponent<Rigidbody>();
        _shipRb = shipTransform.GetComponent<Rigidbody>();
        _ballStart = ballTransform.position;
        _shipStart = shipTransform.position;
        _shipStartRot = shipTransform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ball")) return;

        _score++;
        UpdateScoreUI();
    //    ResetPositions();
    }

  /*  private void ResetPositions()
    {
        _ballRb.linearVelocity = Vector3.zero;
        _ballRb.angularVelocity = Vector3.zero;
        ballTransform.position = _ballStart;

        _shipRb.linearVelocity = Vector3.zero;
        _shipRb.angularVelocity = Vector3.zero;
        shipTransform.position = _shipStart;
        shipTransform.rotation = _shipStartRot;
    }
*/
    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"Goals: {_score}";
    }
}