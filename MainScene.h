#pragma once
#include <raylib.h>
#include "Scene.h"
#include "AnimatedSprite.h"

struct MainScene : public Scene {
	void init(RenderTexture2D dis) {
		display = dis;
	}

	void update() {
		BeginTextureMode(display);
		ClearBackground(BLACK);

		EndTextureMode();
	}
};
