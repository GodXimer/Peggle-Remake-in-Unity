//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class Prediction : MonoBehaviour
//{
//    private Scene _simulationScene;
//    private PhysicsScene2D _physicsScene;
//    [SerializeField] private Transform _obstaclesParent;
//    public Dictionary<string, GameObject> Obstacles;

//    private void Start()
//    {
//        Obstacles = new Dictionary<string, GameObject>();
//        CreatePhysicScene();
//    }

//    public void CreatePhysicScene()
//    {
//        _simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics2D));
//        _physicsScene = _simulationScene.GetPhysicsScene2D();

//        randomName actualRandomNameScript;
//        SpriteRenderer sprRender;

//        foreach (Transform obj in _obstaclesParent)
//        {
//            var ghostObj = Instantiate(obj.gameObject, obj.transform.position, obj.transform.rotation);
//            actualRandomNameScript = ghostObj.GetComponent<randomName>();
//            sprRender = ghostObj.GetComponent<SpriteRenderer>();

//            if (actualRandomNameScript != null) actualRandomNameScript.IsGhost = true;
//            if (sprRender != null) sprRender.enabled = false;

//            SceneManager.MoveGameObjectToScene(ghostObj, _simulationScene);

//            Obstacles[ghostObj.name] = ghostObj;
//        }
//    }

//    [SerializeField] private LineRenderer _lr;
//    [SerializeField] private int _maxPhysicsFrameIterations = 100;
//    public void SimulatreTrajectory(Ball ballPrefab, Vector2 pos, Vector2 vel)
//    {
//        var ghostObj = Instantiate(ballPrefab, pos, Quaternion.identity); //very bad 
//        ghostObj.GetComponent<SpriteRenderer>().enabled = false;
//        SceneManager.MoveGameObjectToScene(ghostObj.gameObject, _simulationScene);

//        ghostObj.Init(vel, true);

//        _lr.positionCount = _maxPhysicsFrameIterations;

//        for (int i = 0; i < _maxPhysicsFrameIterations; i++)
//        {
//            _physicsScene.Simulate(Time.fixedDeltaTime);
//            _lr.SetPosition(i, ghostObj.transform.position);
//        }

//        Destroy(ghostObj.gameObject); //very bad
//    }
//}
