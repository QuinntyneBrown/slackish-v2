import { Ruler } from "./ruler";
import { Space } from "./space";
import { translateXY } from "./translate-xy";

export class Position {

    private static _instance;

    public static get Instance() {
        this._instance = this._instance || new this();
        return this._instance;
    }

    constructor(
        private _ruler: Ruler = Ruler.Instance,
        private _space: Space = Space.Instance,
        private _translateXY: any = translateXY) { }

    public somewhere = (a: HTMLElement, b: HTMLElement, space: number, directionPriorityList: Array<string>) => {
        return new Promise(resolve => {
            resolve();
        });        
    }

    public above = (a: HTMLElement, b: HTMLElement, space: number) => Promise.all([this._ruler.measure(a), this._ruler.measure(b)])
        .then(resultsArray => {
            const aRectangle = resultsArray[0];
            const bRectangle = resultsArray[1];
            this._translateXY(b, aRectangle.centerX - bRectangle.radiusX, aRectangle.bottom + space);
        });

    public below = (a: HTMLElement, b: HTMLElement, space: number) => {
        return Promise.all([this._ruler.measure(a), this._ruler.measure(b)]).then(resultsArray => {
            var aRectangle = resultsArray[0];
            var bRectangle = resultsArray[1];
            this._translateXY(b, aRectangle.centerX - bRectangle.radiusX, aRectangle.bottom + space);
        });
    }

    public left = (a: HTMLElement, b: HTMLElement, space: number) => {
        return Promise.all([this._ruler.measure(a), this._ruler.measure(b)]).then(resultsArray => {
            var aRectangle = resultsArray[0];
            var bRectangle = resultsArray[1];
            this._translateXY(b, aRectangle.centerX - bRectangle.radiusX, aRectangle.bottom + space);
        });        
    }

    public right = (a: HTMLElement, b: HTMLElement, space: number) => {
        return Promise.all([this._ruler.measure(a), this._ruler.measure(b)]).then(resultsArray => {
            var aRectangle = resultsArray[0];
            var bRectangle = resultsArray[1];
            this._translateXY(b, aRectangle.centerX - bRectangle.radiusX, aRectangle.bottom + space);
        });   
    }    
}