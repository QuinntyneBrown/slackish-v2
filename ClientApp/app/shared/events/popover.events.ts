export const popoverEvents = {
    USERNAME_CLICK:"[Popover] USERNAME CLICK"
}

export class PopoverEvent extends CustomEvent {
    constructor(eventName:string) {
        super(eventName, {
            bubbles: true,
            cancelable: true,
            composed: true,
            detail: { }
        } as CustomEventInit);
    }
}

export class LogOutClicked extends PopoverEvent {
    constructor() {
        super(popoverEvents.USERNAME_CLICK);

        alert("?");
    }
}
