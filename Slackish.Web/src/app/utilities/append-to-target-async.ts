export const appendToTargetAsync = (options: { wait?: number, nativeHTMLElement: HTMLElement, target: HTMLElement }) => {    
    return new Promise(resolve => {
        options.target.appendChild(options.nativeHTMLElement);
        setTimeout(() => { resolve(); }, options.wait || 100);        
    });
}