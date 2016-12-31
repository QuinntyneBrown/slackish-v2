export var setOpacityAsync = (options: { nativeHTMLElement: HTMLElement, opacity: string }) => {
    return new Promise(resolve => {
        if (options.nativeHTMLElement) {
            options.nativeHTMLElement.style.opacity = options.opacity;
            options.nativeHTMLElement.addEventListener('transitionend', removeListenerAndResolve, false);
        }
        function removeListenerAndResolve() {
            options.nativeHTMLElement.removeEventListener('transitionend', removeListenerAndResolve);
            resolve();
        }        
    });    
}   