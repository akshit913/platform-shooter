using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PDollarGestureRecognizer;
public class Recognizer : MonoBehaviour
{
    public Vector3 hiddenPosition;
    public GameObject player;
    public GameObject tap;
    public Rigidbody playerRigidBody;
    public Texture tapDownTexture;
    public Texture movementHalf;
    public Texture shootingHalf;
    private Vector3 tapDownPoint;
    private Vector3 tapDragPoint;
    public float movementSense;
    public float jumpSense;
    public GameObject bullet;
    public GameObject leftBullet;
    public GameObject chargedShot;
    public GameObject throwObject;
    public int touchAreaOffset = 17;
    public GameObject tapDownPrefab;
    public GameObject tapDragGraphic;
    private List<Point> gesturePoints;

    private List<PDollarGestureRecognizer.Point> gesturePoints;
    private string message;
    private List<Gesture> trainingSet = new List<Gesture>();
    
    void Start()
    {
        TextAsset[] gesturesXml = Resources.LoadAll<TextAsset>("GestureSet/10-stylus-MEDIUM/");
		foreach (TextAsset gestureXml in gesturesXml)
		    trainingSet.Add(GestureIO.ReadGestureFromXML(gestureXml.text));
    }
    void Awake()
    {
        tapDragPoint = hiddenPosition;
        gesturePoints = new List<Point>();
    }

    void OnGUI () 
    {
        if(tapDownPoint != hiddenPosition) 
        {
            GUI.Box(new Rect(tapDownPoint.x - 10, Screen.height - tapDownPoint.y - 10, 20, 20), tapDownTexture);
        }
    }

    void Update()
    {
        /* Initial tap */
        int num = Input.touchCount;
        if(num > 0)
        {
            for(int i = 0;i < num;i++){
                Touch touch = Input.GetTouch(i);
                TouchPhase phase = touch.phase;
                if (phase == TouchPhase.Began)
                {
                    Vector3 temp = Input.mousePosition;
                    tapDownPoint = temp;
                    gesturePoints.Add(new Point(temp.x,temp.y,1));
                }

                /* Drag */
                else if (phase == TouchPhase.Moved)
                {

                    if(tapDownPoint != hiddenPosition)
                    {
                        tapDragPoint = Input.mousePosition;
                        gesturePoints.Add(new Point(tapDragPoint.x,tapDragPoint.y,1));

                        if(Mathf.Abs(tapDragPoint.x - tapDownPoint.x) > movementSense)
                        {
                            if(tapDragPoint.x > tapDownPoint.x)
                                player.transform.position += new Vector3(0.06f,0,0);
                            else
                                player.transform.position -= new Vector3(0.06f,0,0);
                        }
                    }
                }

                /* No tap */
                else 
                {
                    if(tapDownPoint != hiddenPosition)
                    {
                        /* Lower half = movement gesture */
                        if(tapDownPoint.y < (Screen.height / 2) - touchAreaOffset)
                        {
                            if(tapDragPoint.y - tapDownPoint.y > jumpSense)
                            {
                                if(tapDragPoint.x - tapDownPoint.x > jumpSense)
                                    playerRigidBody.AddForce(Vector3.right * 100.0f);
                                if(tapDownPoint.x - tapDragPoint.x > jumpSense)
                                    playerRigidBody.AddForce(Vector3.left * 100.0f);

                                playerRigidBody.AddForce(Vector3.up * 500.0f);
                            }
                            
                            if(tapDownPoint.y - tapDragPoint.y > jumpSense)
                            {
                                playerRigidBody.AddForce(Vector3.down * 500.0f);
                            }
                        }
                        /* Upper half = shooting gesture */
                        else
                        {
                            if(gesturePoints.Count > 30)
                            {
                                Point p = gesturePoints[gesturePoints.Count - 1];
                                
                            }
                            else
                            {
                                if(tapDownPoint.x < Screen.width / 2)
                                    Instantiate(leftBullet, new Vector3(player.transform.position.x - 1, player.transform.position.y, 1), new Quaternion(0, 0, 0, 1));
                                else
                                    Instantiate(bullet, new Vector3(player.transform.position.x + 1, player.transform.position.y, 1), new Quaternion(0, 0, 0, 1));
                            }
                        }
                        
                        Gesture candidate = new Gesture(gesturePoints.ToArray());
                        Result gestureResult = PointCloudRecognizer.Classify(candidate, trainingSet.ToArray());
                        message = gestureResult.GestureClass + " " + gestureResult.Score;
                        if(gestureResult.GestureClass == "D"){
                            Instantiate(leftBullet, new Vector3(player.transform.position.x - 1, player.transform.position.y, 1), new Quaternion(0, 0, 0, 1));
                            Instantiate(bullet, new Vector3(player.transform.position.x + 1, player.transform.position.y, 1), new Quaternion(0, 0, 0, 1));
                        }
                        Debug.Log(message);
                    }
                    tapDragPoint = hiddenPosition;
                    tapDownPoint = hiddenPosition;
                    gesturePoints.Clear();
                }
            }
        }
    }
}

// class Point
// {
//     public float x, y;
//     public int strokeID;
// }