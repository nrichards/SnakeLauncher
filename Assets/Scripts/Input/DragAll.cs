using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows mouse movement of game objects with a given layer
/// 
/// See https://www.youtube.com/watch?v=izag_ZHwOtM
/// </summary>
public class DragAll : MonoBehaviour
{
	private Transform dragging = null;
	private Rigidbody2D dragBody = null;
	private Vector3 offset;
	[SerializeField] private LayerMask moveableLayers;
	[SerializeField] private bool MoveRigidbody;
	
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, float.PositiveInfinity, moveableLayers);
			
			if (hit) {
				dragging = hit.transform;
				offset = dragging.position - mouseWorldPos;
				dragBody = hit.rigidbody;
			}
		} else if (Input.GetMouseButtonUp(0)) {
			dragging = null;
			dragBody = null;
		}
		
		if (dragging != null) {
			var dragPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
			if (MoveRigidbody && dragBody != null) {
				dragBody.MovePosition(dragPosition);
			} else {
				dragging.position = dragPosition;
			}
		}
	}
}
