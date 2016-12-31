import { environment } from "../environment";

export function Log() {    
    return (target, propertyKey, descriptor) => {        
        var originalMethod = descriptor.value;
        descriptor.value = function (...args: any[]) {            
            if (!environment.production) {
                console.log(`${propertyKey} : ${JSON.stringify(args[0])}`);
            }
            return originalMethod.apply(this, args);
        }
        return descriptor;
    }

}