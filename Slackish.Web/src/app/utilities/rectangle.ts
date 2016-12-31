interface IPoint {
    x: number,
    y: number
}

export class Rectangle {

    private static _instance;

    public static get Instance() {
        this._instance = this._instance || new this();
        return this._instance;
    }

    public newRectangle = (options: { clientRect?: ClientRect, left?: number, top?: number, height?: number, width?:number }) => {
        var instance = new Rectangle();
        if (options.clientRect) {
            instance.left = options.clientRect.left;
            instance.top = options.clientRect.top;
            instance.height = options.clientRect.height;
            instance.width = options.clientRect.width;
        } else {
            instance.left = options.left;
            instance.top = options.top;
            instance.height = options.height;
            instance.width = options.width;
        }
        return instance;
    }

    public left: number;

    public get right(): number { return this.left + this.width; }

    public top: number;

    public get bottom(): number { return this.top + this.height; }

    public height: number;

    public width: number;

    public get centerX(): number { return this.left + (this.width / 2); }

    public get centerY(): number { return this.top + (this.height / 2); }

    public get radiusX(): number { return this.width / 2; }

    public get radiusY(): number { return this.height / 2; }

    public get middle(): IPoint { return { x: this.centerX, y: this.centerY }; }
}