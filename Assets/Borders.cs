using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
 public GameObject object_;
 
 public Vector3[] frustumCorners;
 public Vector3 big_vector;
 public float angel;
 public float[] screen_x_borders = new float[2];
 public float[] screen_y_borders = new float[2];
 public Vector2 screen_borders;
 public Vector2 border_offset;
 void Start() {
     var camera = GetComponent<Camera>();
     Vector3[] frustumCorners = new Vector3[4];
     camera.CalculateFrustumCorners(new Rect(0, 0, 1, 1), camera.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, frustumCorners);
 
     Vector3 big_vector=frustumCorners[2]-transform.position;
 
     angel = (float)(System.Math.Atan(big_vector.x / big_vector.z));
 
     Debug.Log("angel1: " + (-angel  * 180 / System.Math.PI));
     Debug.Log("angel2: " + transform.rotation.eulerAngles.y );
     Debug.Log("angel3: " + (angel + transform.rotation.y) * 180 / System.Math.PI);
 
 
     Vector2 cur_object_angels = new Vector2(0,0);
     cur_object_angels.y = (transform.rotation.eulerAngles.y > 180) ? transform.rotation.eulerAngles.y - 360 : transform.rotation.eulerAngles.y;
     cur_object_angels.x = (transform.rotation.eulerAngles.x > 180) ? transform.rotation.eulerAngles.x - 360 : cur_object_angels.x;
     cur_object_angels *= (float)System.Math.PI / 180;
 
     screen_x_borders[0] = (float)System.Math.Tan(angel + cur_object_angels.y) * System.Math.Abs(transform.position.z)+transform.position.x;
 
     screen_x_borders[1] = (float)System.Math.Tan(-angel + cur_object_angels.y) * System.Math.Abs(transform.position.z) + transform.position.x;
 
     screen_borders.x = screen_x_borders[0] - screen_x_borders[1];
 
 
     angel = (float)(System.Math.Atan(big_vector.y / big_vector.z));
 
     screen_y_borders[0] = (float)System.Math.Tan(angel + cur_object_angels.x) * System.Math.Abs(transform.position.z + transform.rotation.x) + transform.position.y;
 
     screen_y_borders[1] = (float)System.Math.Tan(-angel + cur_object_angels.x) * System.Math.Abs(transform.position.z + transform.rotation.x) + transform.position.y;
 
     screen_borders.y = screen_y_borders[0] - screen_y_borders[1];
 
     border_offset = new Vector2(screen_x_borders[0]-screen_borders.x/2 ,screen_y_borders[0] - screen_borders.y / 2 - transform.position.y );
 
     screen_borders /= 2;
     
     object_.transform.position = new Vector3(screen_borders.x+border_offset.x, screen_borders.y+border_offset.y+transform.position.y, 0);
 }
}