using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prospector : MonoBehaviour {
	public Transform drawPile;

	void Start () {
		
	}

	public void DeckReady() {
		PositionCards ();
	}

	void PositionCards() {
		var cards = Deck.deck.cards;
		int c = 0;

		float step = 2.0f;

		// Top Layer
		for (int i = 0; i < 10; i++) {
			cards [c].transform.position = new Vector3 (-9.0f + i * step, transform.position.y, transform.position.z + 0.3f);
			cards [c].GetComponent<SpriteRenderer> ().sortingOrder = 4;
			c++;
		}

		// 2nd Layer
		for (int i = 0; i < 9; i++) {
			cards [c].transform.position = new Vector3 (-8.0f + i * step, transform.position.y - 1, transform.position.z + 0.2f);
			cards [c].GetComponent<SpriteRenderer> ().sortingOrder = 3;
			cards [c].coveredBy.Add (cards[i]);
			cards [c].coveredBy.Add (cards[i + 1]);
			c++; 
		}

		// 3rd Layer
		float offset = -7.0f;
		int coverOffset = 0;
		for (int i = 0; i < 6; i++) {
			cards [c].transform.position = new Vector3 (offset, transform.position.y - 2, transform.position.z + 0.1f);
			cards [c].GetComponent<SpriteRenderer> ().sortingOrder = 2;

			cards [c].coveredBy.Add (cards[10 + coverOffset]);
			cards [c].coveredBy.Add (cards[10 + 1 + coverOffset]);

			if (i % 2 == 1) {
				offset += 2 * step;
				coverOffset += 2;
			} else {
				offset += step;
				coverOffset += 1;
			}
			c++;
		}

		// 4th Layer
		for (int i = 0; i < 3; i++) {
			cards [c].transform.position = new Vector3 (-6.0f + i * 6, transform.position.y - 3, transform.position.z);
			cards [c].GetComponent<SpriteRenderer> ().sortingOrder = 1;
			cards [c].coveredBy.Add (cards[19 + 2 * i]);
			cards [c].coveredBy.Add (cards[19 + 1 + 2 * i]);
			c++;
		}

		// Draw pile
		while(c != cards.Count) {
			cards [c].transform.position = drawPile.position;
			c++;
		}
	}
	
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray.origin, ray.direction, out hit, 2000.0f, LayerMask.GetMask ("Card"))) {
				Card card = hit.collider.gameObject.GetComponent<Card> ();
			}
		}
	}
}
