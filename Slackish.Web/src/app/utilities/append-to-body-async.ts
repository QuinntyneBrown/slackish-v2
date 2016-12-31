export const appendToBodyAsync = (options: { wait?: number, nativeElement: HTMLElement }) => {    
    return new Promise(resolve => {
        document.body.appendChild(options.nativeElement);
        setTimeout(() => { resolve(); }, options.wait || 100);        
    });
}