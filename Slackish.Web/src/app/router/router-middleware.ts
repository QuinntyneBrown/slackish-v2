export abstract class RouterMiddleware {
    public abstract beforeViewTransition(options: RouteChangeOptions);
    public abstract onViewTransition(options: RouteChangeOptions):HTMLElement;
    public abstract afterViewTransition(options: RouteChangeOptions);
}