#pragma once
#include <nlohmann/json.hpp>
#include <string>
#include <fstream>
#include <iostream>
#include <raylib.h>

namespace Json {

    nlohmann::json read(std::string path) {
        std::ifstream file(path);
        if (!file.is_open()) {
            std::cerr << "errore durante il caricamento del file" << std::endl;
            return 1;
        }
        nlohmann::json json;
        file >> json;
        file.close();
        return json;
    }
}

namespace Images {
    Texture2D loadText(std::string text) {
        Image img = ImageText(text.c_str(), 6, WHITE);
        ImageFlipVertical(&img);
        Texture2D texture = LoadTextureFromImage(img);
        UnloadImage(img);
        return texture;
    }

    Texture2D loadText(std::string text, int size) {
        Image img = ImageText(text.c_str(), size, WHITE);
        ImageFlipVertical(&img);
        Texture2D texture = LoadTextureFromImage(img);
        UnloadImage(img);
        return texture;
    }

    Texture2D load(std::string file) {
        Texture2D texture = LoadTexture(file.c_str());

        if (texture.height > 0) {
            Image image = LoadImage(file.c_str());
            ImageFlipVertical(&image);
            texture = LoadTextureFromImage(image);
            UnloadImage(image);
        }
        return texture;
    }
}
