export const createElement = (html:string): HTMLElement => {
    let divElement = document.createElement("div")
    divElement.innerHTML = html;   
    return divElement.firstChild as HTMLElement;
}