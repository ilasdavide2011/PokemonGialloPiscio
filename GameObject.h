#include <raylib.h>
#include <vector>

struct GameObject {
	RenderTexture2D display;
	float pos[2];
	std::vector<GameObject> childObjects;
	void update();
	void setPos(float x, float y) {
		pos[0] = x;
		pos[1] = y;
	}
	/*
	GameObject(float p[2], RenderTexture2D dis) {
		pos[0] = p[0];
		pos[1] = p[1];
		display = dis;
	}
	*/
};