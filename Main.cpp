#include "Renderer.h"
#include <raylib.h>
#include "MainScene.h"
#include "Scene.h"
#include "IntroScene.h"
#include <vector>

class Game {
	Renderer renderer;
	RenderTexture2D display;
	MainScene mainS;
	IntroScene introS;

	void update() {
		renderer.update();
		if (introS.active == true) introS.update();
		if (mainS.active == true) mainS.update();
	}
public:
	Game() {
		display = renderer.getDisplay();
		mainS.init(display);
		introS.init(display);
		introS.active = true;
	}

	void run() {
		while (!WindowShouldClose()) {
			update();
		}
		UnloadRenderTexture(renderer.getDisplay());
		CloseWindow();
	}
};

int main() {
	Game game;
	game.run();
	return 0;
}