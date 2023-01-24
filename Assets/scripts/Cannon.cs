using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Cannon : MonoBehaviour {

    [SerializeField] private float _force;
    [SerializeField] private Prediction _projection;
    [SerializeField] private Ball _realBallPrefab;
    [SerializeField] private Ball _simulationBallPrefab;
    [SerializeField] private Transform _ballSpawn;
    [SerializeField] private Transform _mousePosition;
    [Range(0f, 1f)]
    [SerializeField] private float _mouseWheelSpeed;
    private Vector2 velocity;
    private Vector2 direction;
    public int LeftBalls;

    static public bool canShoot = true;

    [SerializeField] private faceLookMouse faceLookMouse;

    private void Start()
    {
        LeftBalls = 10;

        faceLookMouse.SetPositonToLook(_mousePosition);
    }

    private void Update() 
    {
        if (canShoot)
        {
            faceLookMouse.SetPositonToLook(_mousePosition);

            if (LeftBalls > 0)
            {
                direction = (_mousePosition.position - _ballSpawn.position).normalized;
                velocity = direction * _force;

                _projection.SimulatreTrajectory(_simulationBallPrefab,_ballSpawn.transform.position, velocity);
                HandleControls();

                _mousePosition.position += new Vector3(Input.mouseScrollDelta.y * _mouseWheelSpeed, 0, 0);
            }
        }

        if (Input.GetKeyUp("r"))
        {
            Restart();
        }
    }

    private void HandleControls()
    {
        if (Input.GetMouseButton(0) && LeftBalls > 0) 
        {
            faceLookMouse.SetPositonToLook(_realBallPrefab.transform);
            _realBallPrefab.transform.position = _ballSpawn.transform.position;
            _realBallPrefab.Init(velocity, false);
            canShoot = false;
            LeftBalls--; 
            TextManager.SetBalls(LeftBalls);

            //string positions = $"X = {_mousePosition.position.x} Y = {_mousePosition.position.y}";
            //positions.CopyToClipboard();
            //TextManager.SendText(positions);

        }
    }

    void Restart()
    {
        canShoot = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddBall(int value=1)
    {
        LeftBalls+=value;
        TextManager.SetBalls(LeftBalls);
        TextManager.SendText("+1 ball!");
    }


}