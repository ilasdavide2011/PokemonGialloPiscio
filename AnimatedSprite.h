#pragma once
#include <raylib.h>
#include "GameObject.h"
#include "DisplayUtils.h"
#include "FileUtils.h"
#include <string>
#include "nlohmann/json.hpp"
#include <vector>

class AnimatedSprite : public GameObject {
	std::vector<Texture2D> frames;
	int frameNum;
	int frameCounter;
	int delay;
	int delayC;
	nlohmann::json json;
	std::vector<std::string> actions;
	std::string currentAction;
public:
	bool repeating;
	bool visible;
	void changeAction(std::string action) {
		currentAction = action;
		frameNum = json["actions"][currentAction]["frame num"];
		frames.resize(frameNum);
		for (int i = 0; i < frameNum; i++) {
			frames[i] = (Images::load((std::string)json["actions"][currentAction]["path"] + std::to_string(i) + ".png"));
		}
		delay = json["actions"][currentAction]["delay"];
	}

	void setPos(float x, float y) {
		pos[0] = x;
		pos[1] = y;
	}

	std::vector<Texture2D> getFrames() {
		return frames;
	}

	void init(std::string path, RenderTexture2D dis) {
		currentAction = "idle";
		json = Json::read(path);
		frameNum = json["actions"][currentAction]["frame num"];
		frames.resize(frameNum);
		for (int i = 0; i < frameNum; i++) {
			frames[i] = (Images::load((std::string)json["actions"][currentAction]["path"] + std::to_string(i) + ".png"));
		}
		delay = json["actions"][currentAction]["delay"];
		delayC = 0;
		frameCounter = 0;
		display = dis;
		setPos(0, 0);
		visible = true;
		repeating = true;
	}

	void update() {
		if (visible == true) {
			blit(frames[frameCounter], pos, WHITE, display.texture.height);
			delayC++;
			if (delayC >= delay) {
				if (frameCounter == frameNum-1) {
					if (repeating == true) frameCounter = 0;
					if (!repeating) visible = false;
				}
				else {
					frameCounter += 1;
				}

				delayC = 0;
			}
		}
	}
};
