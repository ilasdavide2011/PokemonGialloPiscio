#pragma once
#include <raylib.h>

void blit(Texture2D tex, float pos[2], Color color, int height) {
    DrawTexture(tex, pos[0], height - pos[1] - tex.height, color);
}

void blitScaled(Texture2D tex, float pos[2], Color color, int height, float scale) {
    Vector2 p = { pos[0], height - pos[1] - tex.height*scale };
    DrawTextureEx(tex, p, 0, scale, color);
}

void drawRectangle(float pos[2], RenderTexture display, float width, float height, Color color) {
    DrawRectangle(pos[0], (display.texture.height - pos[1]) - height, width, height, color);
}

