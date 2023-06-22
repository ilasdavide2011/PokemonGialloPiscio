#pragma once
#include "engine.h"
#include <string>
#include <vector>

class Animation {
private:
	int framesNum;
	int currentFrame;
	std::vector<Texture2D> frames;
public:
	Animation(int framesTotal, std::string name) {
		framesNum = framesTotal;
		frames.resize(framesNum);
		currentFrame = 0;
		for (int i = 0; i < framesNum; i++) {
			Texture2D image = load_image("./data/images/animations/" + name + "/" + std::to_string(i) + ".png");
			frames.push_back(image);
		}
	}
	void play(RenderTexture display, float pp[2]) {
		blit(frames[0], pp, WHITE, display.texture.height);
	}
};
