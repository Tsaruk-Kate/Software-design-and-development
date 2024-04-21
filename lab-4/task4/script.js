// Клас, що визначає загальну стратегію завантаження зображень
class ImageLoadingStrategy {
    loadImage(href) {
        const img = document.createElement("img");
        img.src = href;
        img.onerror = () => {
            console.error("Failed to load image:", href);
        };
        return img;
    }
}
// Підклас стратегії завантаження зображень з файлової системи
class FileSystemImageStrategy extends ImageLoadingStrategy {}

// Підклас стратегії завантаження зображень з мережі
class NetworkImageStrategy extends ImageLoadingStrategy {
    loadImage(href) {
        const img = document.createElement("img");
        img.onload = () => {
            document.body.appendChild(img);
        };
        img.onerror = () => {
            console.error("Failed to load image:", href);
        };
        img.src = href;
    }
}

// Клас, який представляє зображення та використовує певну стратегію для його завантаження
class Image {
    constructor(strategy) {
        this.strategy = strategy;
    }

    // Метод для завантаження зображення
    loadImage(href) {
        if (!this.strategy) {
            console.error("No image loading strategy provided.");
            return;
        }
        const img = this.strategy.loadImage(href);
        document.body.appendChild(img);
    }
}
// Створення об'єктів для конкретних стратегій завантаження
const fileSystemImageStrategy = new FileSystemImageStrategy();
const networkImageStrategy = new NetworkImageStrategy();

// Створення об'єктів зображень і використання різних стратегій для їх завантаження
const image1 = new Image(fileSystemImageStrategy);
const image2 = new Image(networkImageStrategy);

// Завантаження зображень за допомогою створених об'єктів
image1.loadImage("/img/Zhytomyr.jpg");
image2.loadImage("https://sion-tour.com/wp-content/uploads/2018/06/karpati_beregite-1-870x480.jpg");