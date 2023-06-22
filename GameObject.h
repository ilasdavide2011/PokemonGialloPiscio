#pragma once
#include <raylib.h>
#include <vector>
#include "Script.h"

struct GameObject {
	RenderTexture2D display;
	std::vector<Script> scripts;
	bool scripted;
	void addScript(Script s) {
		scripts.push_back(s);
		if (!scripted) scripted = true;
	}
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