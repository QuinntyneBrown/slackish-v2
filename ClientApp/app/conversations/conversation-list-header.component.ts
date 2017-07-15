import {Component,Input,OnInit,ViewEncapsulation,ComponentFactoryResolver,ComponentFactory,ViewChild,ViewContainerRef} from "@angular/core";
import {PopoverComponent} from "../shared/components/popover.component";

@Component({
    templateUrl: "./conversation-list-header.component.html",
    styleUrls: ["./conversation-list-header.component.css"],
    selector: "ce-conversation-list-header",
})
export class ConversationListHeaderComponent {
    constructor(private _componentFactoryResolver: ComponentFactoryResolver) {
        this._componentFactory = _componentFactoryResolver.resolveComponentFactory(PopoverComponent);
    }

    @ViewChild('target', {read: ViewContainerRef})
    public target: ViewContainerRef;

    @Input()
    public username: string;

    @Input()
    public teamName: string;

    private _componentFactory: ComponentFactory<PopoverComponent>;

    public showPopover() {
        if (this.isPopoverVisible) {            
            this.target.clear();
            this.isPopoverVisible = false;
        } else {            
            this.target.createComponent(this._componentFactory);            
            this.isPopoverVisible = true;
        }
    }

    public isPopoverVisible: boolean = false;
}
