#pragma once
#include <raylib.h>
#include <string>
#include <nlohmann/json.hpp>
#include "FileUtils.h"

class Renderer {
	int WIDTH;
	int HEIGHT;
	int scale;
	std::string title;
	RenderTexture2D display;
	nlohmann::json settings;
public:
	RenderTexture2D getDisplay() {
		return display;
	}

	Renderer() {
		settings = Json::read("./windowSettings.json");
		WIDTH = settings["width"];
		HEIGHT = settings["height"];
		scale = settings["scale"];
		title = settings["title"];
		InitWindow(WIDTH, HEIGHT, title.c_str());
		display = LoadRenderTexture(WIDTH / scale, HEIGHT / scale);
		if (settings["resizable"]) {
			SetWindowState(FLAG_WINDOW_RESIZABLE);
		}
		SetTargetFPS(settings["fps"]);
	}

	void update() {
		BeginDrawing();
		DrawTextureEx(display.texture, Vector2{ 0, 0 }, 0, scale, WHITE);
		EndDrawing();
	}
};
