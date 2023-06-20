#pragma once
#include <raylib.h>
#include "Scene.h"

struct IntroScene : public Scene {

	void init(RenderTexture2D dis) {
		display = dis;
	}

	void update() {
		BeginTextureMode(display);
		ClearBackground(WHITE);
		
		EndTextureMode();
	}
};
