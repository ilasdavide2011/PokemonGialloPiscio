#pragma once
#include <raylib.h>

struct Scene {
	RenderTexture2D display;
	bool active = false;
	void init(RenderTexture2D dis) {
		display = dis;
	}
	void update() {}
};
