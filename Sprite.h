#pragma once
#include "GameObject.h"
#include <raylib.h>
#include <string>
#include "FileUtils.h"
#include "DisplayUtils.h"

struct Sprite : public GameObject{
	Texture2D image;

	void init(RenderTexture2D dis, std::string path) {
		display = dis;
		image = Images::load(path);
		pos[0] = 0;
		pos[1] = 0;
	}

	void render() {
		blit(image, pos, WHITE, display.texture.height);
	}

	void update() {
		render();
	}
};
