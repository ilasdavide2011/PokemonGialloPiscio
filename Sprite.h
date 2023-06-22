#pragma once
#include "GameObject.h"
#include <raylib.h>
#include <string>
#include "FileUtils.h"
#include "DisplayUtils.h"

struct Sprite : public GameObject{
	Texture2D image;
	bool visible;

	void init(RenderTexture2D dis, std::string path) {
		display = dis;
		image = Images::load(path);
		pos[0] = 0;
		pos[1] = 0;
		if (scripted) {
			for (int i = 0; i < scripts.size(); i++) {
				scripts[i].init(this);
			}
		}
	}

	void render() {
		if (scripted) {
			for (int i = 0; i < scripts.size(); i++) {
				scripts[i].update();
			}
		}
		if (visible) blit(image, pos, WHITE, display.texture.height);
	}

	void update() {
		render();
	}
};
