#pragma once
#include "Script.h"
#include <raylib.h>
#include "Sprite.h"

struct LogoScript : Script {
	int delay;
	bool delayEnded;
	Sprite* logo;
	void init(Sprite* s) {
		delay = 0;
		logo = s;
		delayEnded = false;
	}
	void update() {
		if (!delayEnded) delay += 1 * GetFrameTime();

		if (delay >= 5) {
			logo->visible = false;
			delayEnded = true;
		}
	}
};
