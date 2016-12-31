export function Logger<TFunction extends Function>(target: TFunction): TFunction {
    let newConstructor: Function = function () {
        console.log("Creating new instance");
    }

    newConstructor.prototype = Object.create(target.prototype);
    newConstructor.prototype.constructor = target;
    return <TFunction>newConstructor;

}