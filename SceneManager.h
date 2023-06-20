#pragma once
#include "Scene.h"

class SceneManager {
	Scene currentScene;
	RenderTexture2D display;
public:
	void changeScene(Scene s) {
		currentScene = s;
		currentScene.update();
	}
	void init(RenderTexture2D dis) {
		display = dis;
		currentScene.init(display);
	}
	
	void update() {
		currentScene.update();
	}
};
