export const loadStyle = (css, selector) => {
    function addStyleTagToHead() {
        var style = document.createElement("style");
        style.setAttribute("data-selector", selector)
        style.appendChild(document.createTextNode(css));
        document.head.appendChild(style);
    }

    if (document.readyState === "complete" || document.readyState === 'interactive') {
        addStyleTagToHead();
    }
    else {
        function onDocumentLoad() {
            addStyleTagToHead();
            window.removeEventListener("DOMContentLoaded", onDocumentLoad);
        }
        window.addEventListener("DOMContentLoaded", onDocumentLoad);
    }
}