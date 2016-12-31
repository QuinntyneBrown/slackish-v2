export const extendCssAsync = (options: { nativeHTMLElement: HTMLElement, cssObject: Object }) => {
    return new Promise(resolve => {
        Object.assign(options.nativeHTMLElement.style, options.cssObject);
        resolve();
    })    
}