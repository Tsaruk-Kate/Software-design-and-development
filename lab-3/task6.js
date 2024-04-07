const fs = require('fs');

class LightNode {
    constructor() {}

    calculateMemoryUsage() {
        let totalMemory = 0;

        if (this._children) {
            this._children.forEach(child => {
                totalMemory += child.calculateMemoryUsage();
            });
        }

        return totalMemory;
    }
}

class LightTextNode extends LightNode {
    constructor(text) {
        super();
        this._text = text;
    }

    calculateMemoryUsage() {
        return Buffer.byteLength(this._text, 'utf8');
    }
}

class LightElementNode extends LightNode {
    constructor(tagName, displayType, closingType, cssClasses) {
        super();
        this._tagName = tagName;
        this._displayType = displayType;
        this._closingType = closingType;
        this._cssClasses = cssClasses;
        this._children = [];
    }

    addChild(node) {
        this._children.push(node);
    }

    getOuterHtml() {
        let result = `<${this._tagName} class="${this._cssClasses.join(" ")}" display="${this._displayType}" closing="${this._closingType}">\n`;
        this._children.forEach(child => {
            result += `\t${child.getOuterHtml()}\n`;
        });
        if (this._closingType === "closing") {
            result += `</${this._tagName}>`;
        }
        return result;
    }

    getInnerHtml() {
        let result = "";
        this._children.forEach(child => {
            result += child.getInnerHtml();
        });
        return result;
    }

    calculateMemoryUsage() {
        let totalMemory = 0;

        this._children.forEach(child => {
            totalMemory += child.calculateMemoryUsage();
        });

        return totalMemory;
    }
}

function readBookText(filePath) {
    try {
        return fs.readFileSync(filePath, 'utf8');
    } catch (err) {
        console.error('Error reading the file:', err);
        return null;
    }
}

function transformTextToHTML(text) {
    const lines = text.split('\n');

    let html = '';
    lines.forEach((line, index) => {
        if (index === 0) {
            html += `<h1>${line.trim()}</h1>\n`;
        } else if (line.trim() === '') {
            return;
        } else if (line.trim().length < 20) {
            html += `<h2>${line.trim()}</h2>\n`;
        } else if (line.startsWith(' ')) {
            html += `<blockquote>${line.trim()}</blockquote>\n`;
        } else {
            html += `<p>${line.trim()}</p>\n`;
        }
    });

    html = `<div>\n${html}</div>`;
    return html;
}

const bookFilePath = 'C:\\ЖДТУ\\2 курс\\2 семестр\\Конструювання ПЗ\\pg1513.txt';
const bookText = readBookText(bookFilePath);

if (bookText) {
    const htmlMarkup = transformTextToHTML(bookText);
    console.log(htmlMarkup);

    const htmlTree = new LightElementNode("div", "block", "closing", ["container"]);

    const h1 = new LightElementNode("h1", "block", "closing", ["main-title"]);
    const h2 = new LightElementNode("h2", "block", "closing", ["sub-title"]);
    const p = new LightElementNode("p", "block", "closing", ["paragraph"]);

    const h1Text = "First Header";
    const h2Text = "Second Header";
    const pText = "Paragraph text";

    const textH1 = new LightTextNode(h1Text);
    const textH2 = new LightTextNode(h2Text);
    const textP = new LightTextNode(pText);

    h1.addChild(textH1);
    h2.addChild(textH2);
    p.addChild(textP);

    htmlTree.addChild(h1);
    htmlTree.addChild(h2);
    htmlTree.addChild(p);

    const memoryUsageBytes = htmlTree.calculateMemoryUsage();
    console.log(`Memory Usage: ${memoryUsageBytes} bytes`);
}