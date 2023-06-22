#pragma once
#include <raylib.h>
#include "Scene.h"
#include "AnimatedSprite.h"
#include "Sprite.h"

struct IntroScene : public Scene {

	Sprite logo;
	AnimatedSprite pika;

	void init(RenderTexture2D dis) {
		display = dis;
		pika.init("./pikaAnimation.json", display);
		pika.repeating = false;
		pika.setPos(426/2-pika.getFrames()[0].width/3, 240/2-pika.getFrames()[2].height/3);
		logo.init(display, "./data/images/logo.png");
		logo.setPos(426/2-logo.image.width/3, 240/2-logo.image.height/3);
	}

	void update() {
		BeginTextureMode(display);
		ClearBackground(BLACK);
		
		logo.render();

		if (!logo.visible) pika.update();

		EndTextureMode();
	}
};
