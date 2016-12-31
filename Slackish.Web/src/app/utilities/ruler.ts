import { Rectangle } from "./rectangle";

export class Ruler {

    private static _instance;

    public static get Instance() {
        this._instance = this._instance || new this();
        return this._instance;
    }

    constructor(private _document: Document = document, private _rectangle: Rectangle = Rectangle.Instance) { }

    public measure = (element: HTMLElement): Promise<Rectangle> => {
        return new Promise((resolve) => {
            if (this._document.body.contains(element)) {
                resolve(this._rectangle.newRectangle({ clientRect: element.getBoundingClientRect() }));
            } else {
                setTimeout(() => {
                    this._document.body.appendChild(element);
                    var clientRect = element.getBoundingClientRect();
                    element.parentNode.removeChild(element);
                    resolve(this._rectangle.newRectangle({ clientRect: clientRect }));
                }, 0);
            }
        });
    }
}