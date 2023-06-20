#include "Renderer.h"
#include <raylib.h>
#include "MainScene.h"
#include "Scene.h"
#include "IntroScene.h"
#include <vector>
#include "SceneManager.h"

class Game {
	Renderer renderer;
	RenderTexture2D display;
	MainScene mainS;
	IntroScene introS;
	SceneManager sceneManager;

	void update() {
		renderer.update();
		introS.update();
	}
public:
	Game() {
		display = renderer.getDisplay();
		sceneManager.changeScene(mainS);
		sceneManager.init(renderer.getDisplay());
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