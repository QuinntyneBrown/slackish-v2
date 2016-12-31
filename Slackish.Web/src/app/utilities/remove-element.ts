export const removeElement = (options: { nativeHTMLElement: HTMLElement }) => {    
    if (options.nativeHTMLElement) {
        options.nativeHTMLElement.parentNode.removeChild(options.nativeHTMLElement);        
        delete options.nativeHTMLElement;
    }
}