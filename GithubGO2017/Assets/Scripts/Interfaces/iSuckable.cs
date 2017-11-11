using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iSuckable {

	void onSuck(Vector3 suckOrigin, float power);
	void onBlow(Vector3 blowOrigin, float power);

    void onFinishedInteraction();
}
