using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Users;

public class UserUtility : MonoBehaviour {
	void Start() {
		if (Application.platform == RuntimePlatform.XboxOne) {

			UsersManager.Create();
			User user = UsersManager.GetAppCurrentUser();
			Debug.Log(user);

		}
	}
}
